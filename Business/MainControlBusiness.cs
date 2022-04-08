using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System.Xml;
using System;
using System.Threading;

namespace Quick_Translator
{
    public class MainControlBusiness
    {
        public static void LoadAttributesTab(EntityMetadata entityMetadata, DataGridView dgvAttributes, bool entityChanged)
        {
            int rowIndex = 0;
            foreach (var attr in entityMetadata.Attributes.OrderBy(prm => prm.LogicalName))
            {
                if (attr.IsCustomizable.Value == false) continue;

                var labelList = new List<string>();
                labelList.Add(attr.LogicalName);

                foreach (var displayName in attr.DisplayName.LocalizedLabels)
                {
                    labelList.Add(displayName.Label);
                }

                dgvAttributes.Rows.Insert(rowIndex, labelList.ToArray());
                dgvAttributes.Rows[rowIndex].Tag = attr;
                rowIndex++;
            }
        }

        public static void LoadFormsTab(IOrganizationService orgService, string entityLogicalName, DataGridView dgvForms, bool entityChanged)
        {
            var formMetadataList = MetadataHelper.RetrieveFormMetadata(entityLogicalName, orgService);

            int rowIndex = 0;
            foreach (var formMetadata in formMetadataList)
            {
                var labelList = new List<string>();

                foreach (var formNames in formMetadata.Names)
                {
                    labelList.Add(formNames.Value);
                }

                dgvForms.Rows.Insert(rowIndex, labelList.ToArray());
                dgvForms.Rows[rowIndex].Tag = formMetadata;
                rowIndex++;
            }
        }

        public static void LoadFormFieldsTab(IOrganizationService orgService, string entityLogicalName, DataGridView dgvFormFields, bool entityChanged, List<int> lcIdList)
        {
            #region User Settings
            var setting = DataHelper.GetCurrentUserSettings(orgService);
            var userSettingLcid = setting.GetAttributeValue<int>("uilanguageid");
            var currentSetting = userSettingLcid;
            #endregion User Settings

            #region Metadata Variables
            var formFieldMetadataList = new List<FormFieldMetadata>();
            var formSectionMetadataList = new List<FormSectionMetadata>();
            var formTabMetadataList = new List<FormTabMetadata>();
            #endregion Metadata Variables

            int rowIndex = 0;

            foreach (var lcId in lcIdList)
            {
                if (currentSetting != lcId)
                {
                    UpdateUserSettings(orgService, setting, lcId);
                    currentSetting = lcId;
                    Thread.Sleep(2000);
                }

                var forms = DataHelper.GetEntityFormsByEntityLogicalName(entityLogicalName, orgService);
                forms = forms.OrderBy(prm => prm.GetAttributeValue<string>("name"));

                foreach (var form in forms)
                {
                    MetadataHelper.RetrieveFormComponentsMetadata(form, lcId, entityLogicalName, formFieldMetadataList, formSectionMetadataList, formTabMetadataList);
                }
            }

            if (userSettingLcid != currentSetting)
            {
                UpdateUserSettings(orgService, setting, userSettingLcid);
            }

            foreach (var formFieldMetadata in formFieldMetadataList)
            {
                var labelList = new List<string>();
                labelList.Add(formFieldMetadata.Form);
                labelList.Add(formFieldMetadata.Tab);
                labelList.Add(formFieldMetadata.Section);
                labelList.Add(formFieldMetadata.Attribute);

                foreach (var formFieldNames in formFieldMetadata.Names)
                {
                    labelList.Add(formFieldNames.Value);
                }

                dgvFormFields.Rows.Insert(rowIndex, labelList.ToArray());
                dgvFormFields.Rows[rowIndex].Tag = formFieldMetadata;
                rowIndex++;
            }
        }

        public static void LoadViewsTab(IOrganizationService orgService, EntityMetadata entityMetadata, DataGridView dgvViews, bool entityChanged, List<int> lcIdList)
        {
            var viewMetadaList = new List<ViewMetadata>();

            MetadataHelper.RetrieveViewsMetadata(orgService, viewMetadaList, entityMetadata.ObjectTypeCode.Value);
            viewMetadaList = viewMetadaList.OrderBy(prm => prm.Type).ToList();

            int rowIndex = 0;
            foreach (var viewMetadata in viewMetadaList)
            {
                var labelList = new List<string>();
                labelList.Add(ViewTypeHelper.GetViewTypeByTypeCode(viewMetadata.Type));

                foreach (var viewNames in viewMetadata.Names)
                {
                    labelList.Add(viewNames.Value);
                }

                dgvViews.Rows.Insert(rowIndex, labelList.ToArray());
                dgvViews.Rows[rowIndex].Tag = viewMetadata;
                rowIndex++;
            }
        }

        public static void LoadBooleansTab(IOrganizationService service, EntityMetadata entityMetadata, DataGridView dgvBooleans, bool entityChanged, List<int> lcIdList)
        {            
            int rowIndex = 0;
            foreach (var attribute in entityMetadata.Attributes.OrderBy(prm => prm.LogicalName))
            {
                if (attribute.AttributeType == null
                        || attribute.AttributeType.Value != AttributeTypeCode.Boolean
                        || !attribute.MetadataId.HasValue)
                    continue;

                var booleanAttributeMetadata = (BooleanAttributeMetadata)attribute;
                if (booleanAttributeMetadata.OptionSet?.IsGlobal ?? false)
                    continue;

                var labelList = new List<string>();
                labelList.Add(attribute.LogicalName);

                foreach (var lcId in lcIdList)
                {
                    if (booleanAttributeMetadata.OptionSet.FalseOption.Label != null)
                    {
                        var optionLabel = booleanAttributeMetadata.OptionSet.FalseOption.Label.LocalizedLabels.FirstOrDefault(l => l.LanguageCode == lcId);
                        if (optionLabel != null)
                        {
                            labelList.Add(optionLabel.Label);
                        }
                    }
                }

                foreach (var lcId in lcIdList)
                {
                    if (booleanAttributeMetadata.OptionSet.TrueOption.Label != null)
                    {
                        var optionLabel = booleanAttributeMetadata.OptionSet.FalseOption.Label.LocalizedLabels.FirstOrDefault(l => l.LanguageCode == lcId);
                        if (optionLabel != null)
                        {
                            labelList.Add(optionLabel.Label);
                        }
                    }
                }
                dgvBooleans.Rows.Insert(rowIndex, labelList.ToArray());
                dgvBooleans.Rows[rowIndex].Tag = attribute;
                rowIndex++;
            }
        }

        public static void LoadOptionSets(IOrganizationService service, EntityMetadata entityMetadata, DataGridView dgvPicklists, bool entityChanged, List<int> lcIdList)
        {
            int rowIndex = 0;
            foreach (var attribute in entityMetadata.Attributes.OrderBy(prm => prm.LogicalName))
            {
                if (attribute.AttributeType == null
                      || attribute.AttributeType.Value != AttributeTypeCode.Picklist
                      && attribute.AttributeType.Value != AttributeTypeCode.State
                      && attribute.AttributeType.Value != AttributeTypeCode.Status
                      && !(attribute is MultiSelectPicklistAttributeMetadata)
                      || !attribute.MetadataId.HasValue)
                    continue;

                OptionSetMetadata optionSetMetadata = null;

                switch (attribute.AttributeType.Value)
                {
                    case AttributeTypeCode.Picklist:
                        optionSetMetadata = ((PicklistAttributeMetadata)attribute).OptionSet;
                        break;

                    case AttributeTypeCode.State:
                        optionSetMetadata = ((StateAttributeMetadata)attribute).OptionSet;
                        break;

                    case AttributeTypeCode.Status:
                        optionSetMetadata = ((StatusAttributeMetadata)attribute).OptionSet;
                        break;

                    case AttributeTypeCode.Virtual:
                        optionSetMetadata = ((MultiSelectPicklistAttributeMetadata)attribute).OptionSet;
                        break;
                }

                if (optionSetMetadata.IsGlobal.Value)
                    continue;

                foreach (var option in optionSetMetadata.Options.OrderBy(o => o.Value))
                {
                    var labelList = new List<string>();
                    labelList.Add(attribute.LogicalName);

                    foreach (var lcId in lcIdList)
                    {
                        if (option.Label != null)
                        {
                            var optionLabel = option.Label.LocalizedLabels.FirstOrDefault(l => l.LanguageCode == lcId);
                            if (optionLabel != null)
                            {
                                labelList.Add(optionLabel.Label);
                            }
                        }
                    }

                    dgvPicklists.Rows.Insert(rowIndex, labelList.ToArray());
                    dgvPicklists.Rows[rowIndex].Tag = attribute;
                    rowIndex++;
                }
            }
        }

        public static void AddLanguageColumns(DataGridView dvg, int[] lcIds)
        {
            foreach (int lcid in lcIds)
            {
                string languageLabel = LanguageCodeHelper.GetLanguageLabelByLCID(lcid);
                DataGridViewHelper.AddColumn(dvg, languageLabel, 150);
            }
        }

        public static void UpdateUserSettings(IOrganizationService orgService, Entity setting, int lcId)
        {
            setting["localeid"] = lcId;
            setting["uilanguageid"] = lcId;
            setting["helplanguageid"] = lcId;
            orgService.Update(setting);
        }
    }
}
