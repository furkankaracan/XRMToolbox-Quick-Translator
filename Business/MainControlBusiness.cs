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
        public static void LoadAttributesTab(EntityMetadata entityMetadata, DataGridView dgvAttributes, bool indexChanged)
        {
            if (!indexChanged)
            {
                if (dgvAttributes.Rows.Count > 0)
                    return;
            }
            else if (dgvAttributes.Rows.Count > 0)
                dgvAttributes.Rows.Clear();


            int rowIndex = 0;
            var attributes = entityMetadata.Attributes;
            attributes = attributes.OrderBy(prm => prm.LogicalName).ToArray<AttributeMetadata>();

            foreach (var attr in attributes)
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

        public static void LoadFormsTab(IOrganizationService orgService, string entityLogicalName, DataGridView dgvForms, bool indexChanged)
        {
            if (!indexChanged)
            {
                if (dgvForms.Rows.Count > 0)
                    return;
            }
            else if (dgvForms.Rows.Count > 0)
                dgvForms.Rows.Clear();

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

        public static void LoadFormFieldsTab(IOrganizationService orgService, string entityLogicalName, DataGridView dgvFormFields, bool indexChanged, List<int> lcIdList)
        {
            if (!indexChanged)
            {
                if (dgvFormFields.Rows.Count > 0)
                    return;
            }
            else if (dgvFormFields.Rows.Count > 0)
                dgvFormFields.Rows.Clear();

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

                var forms = MetadataHelper.RetrieveEntityForms(entityLogicalName, orgService);
                forms = forms.OrderBy(prm => prm.GetAttributeValue<string>("name"));

                foreach (var form in forms)
                {
                    MetadataHelper.RetrieveFormFields(form, lcId, entityLogicalName, formFieldMetadataList, formSectionMetadataList, formTabMetadataList);
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
