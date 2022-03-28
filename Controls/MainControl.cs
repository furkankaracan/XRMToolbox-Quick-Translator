using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Messages;

namespace Quick_Translator
{
    public partial class MainControl : PluginControlBase
    {
        #region variables

        private Settings mySettings;
        private List<int> lcIdList;
        private List<EntityMetadata> entityMetadataList;

        #endregion variables

        #region Constructor 
        public MainControl()
        {
            InitializeComponent();
        }

        #endregion Constructor

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        /// <summary>
        /// This event occurs when the plugin is closed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PluginControl_OnCloseTool(object sender, EventArgs e)
        {
            // Before leaving, save the settings
            SettingsManager.Instance.Save(GetType(), mySettings);
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            base.UpdateConnection(newService, detail, actionName, parameter);

            if (mySettings != null && detail != null)
            {
                mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
                LogInfo("Connection has changed to: {0}", detail.WebApplicationUrl);
            }
        }

        private void btnLoadEntities_Click(object sender, EventArgs e)
        {
            LoadEntities();
        }

        private void LoadEntities()
        {
            if (lvEntities.Items.Count > 0)
                lvEntities.Items.Clear();

            bool loadCustomEntities = cbCustomEntities.Checked;
            bool loadDefaultEntities = cbDefaultEntities.Checked;

            if (!loadCustomEntities && !loadDefaultEntities) return;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading entities...",
                Work = (bw, e) =>
                {
                    var lcIdRequest = new RetrieveProvisionedLanguagesRequest();
                    var lcIdResponse = (RetrieveProvisionedLanguagesResponse)Service.Execute(lcIdRequest);
                    lcIdList = lcIdResponse.RetrieveProvisionedLanguages.ToList();

                    if (loadCustomEntities && loadDefaultEntities)
                        e.Result = MetadataHelper.RetrieveAllEntities(Service);
                    else if (loadCustomEntities)
                        e.Result = MetadataHelper.RetrieveCustomEntities(Service);
                    else
                        e.Result = MetadataHelper.RetrieveDefaultEntities(Service);
                },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        string errorMessage = CrmExceptionHelper.GetErrorMessage(e.Error, true);
                        MessageBox.Show(this, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        entityMetadataList = (List<EntityMetadata>)e.Result;
                        FillEntitiesListView(entityMetadataList);
                    }
                }
            });
        }

        private void FillEntitiesListView(List<EntityMetadata> entityMetadatas)
        {
            foreach (EntityMetadata entityMetadata in entityMetadatas)
            {
                var item = new ListViewItem { Text = entityMetadata.LogicalName };
                item.SubItems.Add(entityMetadata.DisplayName?.UserLocalizedLabel?.Label);
                lvEntities.Items.Add(item);
            }
        }

        private void tbFind_KeyUp(object sender, KeyEventArgs e)
        {
            lvEntities.Items.Clear();

            if (string.IsNullOrEmpty(tbFind.Text))
            {
                FillEntitiesListView(entityMetadataList);
            }

            var filteredList = entityMetadataList.Where(prm => prm.LogicalName.Contains(tbFind.Text)).ToList();
            FillEntitiesListView(filteredList);
        }

        private void lvEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEntities.SelectedIndices.Count <= 0) return;

            LoadEntityMetada();
        }

        private void tcSelectedEntityTabs_TabIndexChanged(object sender, EventArgs e)
        {
            LoadEntityMetada();
        }

        private void LoadEntityMetada()
        {
            int selectedIndex = lvEntities.SelectedIndices[0];
            var filters = EntityFilters.Default;

            if (tcSelectedEntityTabs.SelectedIndex == (int)TabEnum.Form || tcSelectedEntityTabs.SelectedIndex == (int)TabEnum.Views)
                filters = EntityFilters.Entity;

            else if (tcSelectedEntityTabs.SelectedIndex == (int)TabEnum.Attributes
                || tcSelectedEntityTabs.SelectedIndex == (int)TabEnum.Picklists
                || tcSelectedEntityTabs.SelectedIndex == (int)TabEnum.Booleans)
                filters = EntityFilters.Attributes;

            var request = new RetrieveEntityRequest
            {
                LogicalName = lvEntities.Items[selectedIndex].Text,
                EntityFilters = filters
            };

            var response = (RetrieveEntityResponse)Service.Execute(request);


        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            AddLanguageColumns();
        }

        private void AddLanguageColumns()
        {
            RetrieveAvailableLanguagesRequest req = new RetrieveAvailableLanguagesRequest();
            var resp = (RetrieveAvailableLanguagesResponse)Service.Execute(req);
            var lcIds = (int[])resp.Results["LocaleIds"];

            foreach (int lcid in lcIds)
            {
                string languageLabel = LanguageCodeHelper.GetLanguageLabelByLCID(lcid);

                ListViewHelper.AddColumn(lvAttributes, languageLabel, 150);
                ListViewHelper.AddColumn(lvForms, languageLabel, 150);
                ListViewHelper.AddColumn(lvFormFields, languageLabel, 150);
                ListViewHelper.AddColumn(lvViews, languageLabel, 150);
                ListViewHelper.AddColumn(lvBooleans, languageLabel, 150);
                ListViewHelper.AddColumn(lvPicklists, languageLabel, 150);
            }
        }
    }
}