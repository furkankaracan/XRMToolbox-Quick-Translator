using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System.Xml;
using System;
using System.Threading;
using System.Data;
using Microsoft.Xrm.Sdk.Query;

namespace Quick_Translator
{
    public class MainControlBusiness
    {
        public static void LoadAttributesTab(EntityMetadata entityMetadata, DataGridView dgvAttributes)
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

        public static void LoadFormsTab(IOrganizationService orgService, string entityLogicalName, DataGridView dgvForms)
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

        public static void LoadFormFieldsTab(IOrganizationService orgService, string entityLogicalName, DataGridView dgvFormFields, List<int> lcIdList)
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

        public static void LoadViewsTab(IOrganizationService orgService, EntityMetadata entityMetadata, DataGridView dgvViews)
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

        public static void LoadBooleansTab(EntityMetadata entityMetadata, DataGridView dgvBooleans, List<int> lcIdList)
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

        public static void LoadOptionSets(EntityMetadata entityMetadata, DataGridView dgvPicklists, List<int> lcIdList)
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

        public static void AddLanguageColumns(DataGridView dgv, int[] lcIds)
        {
            foreach (int lcId in lcIds)
            {
                string languageLabel = LanguageCodeHelper.GetLanguageLabelByLCID(lcId);
                DataGridViewHelper.AddColumn(dgv, languageLabel, 150, lcId.ToString());
            }
        }

        public static void UpdateUserSettings(IOrganizationService orgService, Entity setting, int lcId)
        {
            setting["localeid"] = lcId;
            setting["uilanguageid"] = lcId;
            setting["helplanguageid"] = lcId;
            orgService.Update(setting);
        }

        public static void PublishChangedAttributeTranslations(DataGridView dgv, List<int> updatedRowIndexes)
        {
            List<AttributeMetadata> attributeMetadataList = GetChangedAttributeRows(dgv, updatedRowIndexes);

            foreach (var attributeMeatada in attributeMetadataList)
            {
                if (attributeMeatada.DisplayName.LocalizedLabels.All(prm => string.IsNullOrEmpty(prm.Label)) ||
                    attributeMeatada.IsRenameable.Value == false)
                {
                    continue;
                }
            }
        }

        public static void PublishChangedFormTranslations(DataGridView dgv, List<int> updatedRowIndexes)
        {
            List<SetLocLabelsRequest> requests = GetChangedFormRows(dgv, updatedRowIndexes);
        }

        public static void PublishChangedFormFieldTranslations(IOrganizationService orgService, DataGridView dgv, List<int> updatedRowIndexes)
        {
            GetChangedFormFields(orgService, dgv, updatedRowIndexes);
        }

        public static List<AttributeMetadata> GetChangedAttributeRows(DataGridView dgv, List<int> updatedRowIndexes)
        {
            List<AttributeMetadata> attributeMetadataList = new List<AttributeMetadata>();

            var columnCount = dgv.Columns.Count;

            foreach (var rowIndex in updatedRowIndexes)
            {
                AttributeMetadata tag = (AttributeMetadata)dgv.Rows[rowIndex].Tag;
                Microsoft.Xrm.Sdk.Label displayName = new Microsoft.Xrm.Sdk.Label();

                int columnIndex = 1;

                while (columnIndex < columnCount)
                {
                    var lcId = Convert.ToInt32(dgv.Columns[columnIndex].Name);
                    var label = (string)dgv[columnIndex, rowIndex].Value;

                    var translatedLabel = tag.DisplayName.LocalizedLabels.FirstOrDefault(prm => prm.LanguageCode == lcId);
                    if (translatedLabel == null)
                    {
                        translatedLabel = new LocalizedLabel(label, lcId);
                        tag.DisplayName.LocalizedLabels.Add(translatedLabel);
                    }
                    else
                    {
                        translatedLabel.Label = label;
                    }

                    columnIndex++;
                }

                attributeMetadataList.Add(tag);
            }

            return attributeMetadataList;
        }

        public static List<SetLocLabelsRequest> GetChangedFormRows(DataGridView dgv, List<int> updatedRowIndexes)
        {
            var columnCount = dgv.Columns.Count;
            List<SetLocLabelsRequest> requests = new List<SetLocLabelsRequest>();

            foreach (var rowIndex in updatedRowIndexes)
            {
                FormMetadata tag = (FormMetadata)dgv.Rows[rowIndex].Tag;
                var currentFormId = tag.Id;

                var request = new SetLocLabelsRequest
                {
                    EntityMoniker = new EntityReference("systemform", currentFormId),
                    AttributeName = "name"
                };

                var labels = new List<LocalizedLabel>();
                int columnIndex = 0;
                while (columnIndex < columnCount)
                {
                    var lcId = Convert.ToInt32(dgv.Columns[columnIndex].Name);
                    var label = (string)dgv[columnIndex, rowIndex].Value;

                    labels.Add(new LocalizedLabel(label, lcId));

                    columnIndex++;
                }

                request.Labels = labels.ToArray();
                requests.Add(request);
            }

            return requests;
        }

        public static void GetChangedFormFields(IOrganizationService orgService, DataGridView dgv, List<int> updatedRowIndexes)
        {
            var columnCount = dgv.Columns.Count;
            foreach (var rowIndex in updatedRowIndexes)
            {
                FormFieldMetadata tag = (FormFieldMetadata)dgv.Rows[rowIndex].Tag;

                var labelId =  "{" + tag.Id.ToString() + "}";
                var formId = tag.FormId;

                Entity form = new Entity();
                try
                {
                    form = orgService.Retrieve("systemform", formId, new ColumnSet(new[] { "formxml" }));
                }
                catch (Exception error) //lets not fail if the form is no more available in CRM
                {
                    //OnLog(new LogEventArgs($"{sheet.Name}: {formId}: {error.Message}"));

                    continue;   //form is not found so no need to process further.
                }

                var formXml = form.GetAttributeValue<string>("formxml");
                var docXml = new XmlDocument();
                docXml.LoadXml(formXml);

                var cellNode = docXml.DocumentElement.SelectSingleNode(string.Format("//cell[translate(@id,'ABCDEFGHIJKLMNOPQRSTUVWXYZ','abcdefghijklmnopqrstuvwxyz')='{0}']", labelId.ToLower()));
                if (cellNode != null)
                {
                    var columnIndex = 4;
                    while (columnIndex < columnCount)
                    {
                        var lcId = dgv.Columns[columnIndex].Name;
                        var label = (string)dgv[columnIndex, rowIndex].Value;

                        UpdateXmlNode(cellNode, lcId, label);

                        columnIndex++;
                    }
                }

                form["formxml"] = docXml.OuterXml;
            }
        }

        private static void UpdateXmlNode(XmlNode node, string lcId, string description)
        {
            var labelsNode = node.SelectSingleNode("labels");
            if (labelsNode == null)
            {
                labelsNode = node.OwnerDocument.CreateElement("labels");
                node.AppendChild(labelsNode);
            }

            var labelNode = labelsNode.SelectSingleNode(string.Format("label[@languagecode='{0}']", lcId));
            if (labelNode == null)
            {
                labelNode = node.OwnerDocument.CreateElement("label");
                labelsNode.AppendChild(labelNode);

                var languageAttr = node.OwnerDocument.CreateAttribute("languagecode");
                languageAttr.Value = lcId;
                labelNode.Attributes.Append(languageAttr);
                var descriptionAttr = node.OwnerDocument.CreateAttribute("description");
                labelNode.Attributes.Append(descriptionAttr);
            }

            labelNode.Attributes["description"].Value = description;
        }
    }
}
