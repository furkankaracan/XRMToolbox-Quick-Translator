using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System.Xml;
using System;

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
            int rowIndex = 0;

            foreach (var lcId in lcIdList)
            {
                var forms = MetadataHelper.RetrieveEntityForms(entityLogicalName, orgService);

                foreach (var form in forms)
                {
                    var formFieldMetadataList = MetadataHelper.RetrieveFormFields(form, lcId, entityLogicalName);

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
    }
}
