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
        public static void LoadAttributesTab(EntityMetadata entityMetadata, DataGridView dgvAttributes)
        {
            if (dgvAttributes.Rows.Count > 0)
                return;

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

        public static void LoadFormsTab(IOrganizationService orgService, string entityLogicalName, DataGridView dvgForms)
        {
            if (dvgForms.Rows.Count > 0)
                return;

            var formMetadataList = MetadataHelper.RetrieveFormMetadata(entityLogicalName, orgService);

            int rowIndex = 0;
            foreach (var formMetadata in formMetadataList)
            {
                var labelList = new List<string>();

                foreach (var formNames in formMetadata.Names)
                {
                    labelList.Add(formNames.Value);
                }

                dvgForms.Rows.Insert(rowIndex, labelList.ToArray());
                dvgForms.Rows[rowIndex].Tag = formMetadata;
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
    }
}
