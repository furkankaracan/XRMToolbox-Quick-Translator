using McTools.Xrm.Connection;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Messages;

namespace Quick_Translator
{
    public partial class MainControl : PluginControlBase
    {
        #region variables

        private Settings mySettings;
        private List<int> lcIdList = new List<int>();
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

            LoadEntityMetada(true);
        }

        private void tcSelectedEntityTabs_TabIndexChanged(object sender, EventArgs e)
        {
            LoadEntityMetada(false);
        }

        private void LoadEntityMetada(bool indexChanged)
        {
            if (lvEntities?.SelectedIndices.Count < 1)
                return;

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

            var entityMetadata = response.EntityMetadata;

            if (tcSelectedEntityTabs.SelectedIndex == 0)
                MainControlBusiness.LoadAttributesTab(entityMetadata, dgvAttributes,indexChanged);
            else if (tcSelectedEntityTabs.SelectedIndex == 1)
                MainControlBusiness.LoadFormsTab(Service, entityMetadata.LogicalName, dgvForms,indexChanged);
            else if (tcSelectedEntityTabs.SelectedIndex == 2)
                MainControlBusiness.LoadFormFieldsTab(Service, entityMetadata.LogicalName, dgvFormFields,indexChanged, lcIdList);
        }

        private void MainControl_Load(object sender, EventArgs e)
        {
            RetrieveAvailableLanguagesRequest req = new RetrieveAvailableLanguagesRequest();
            var resp = (RetrieveAvailableLanguagesResponse)Service.Execute(req);
            var lcIds = (int[])resp.Results["LocaleIds"];
            lcIdList.AddRange(lcIds);

            MainControlBusiness.AddLanguageColumns(dgvAttributes, lcIds);
            MainControlBusiness.AddLanguageColumns(dgvForms, lcIds);
            MainControlBusiness.AddLanguageColumns(dgvFormFields, lcIds);
            MainControlBusiness.AddLanguageColumns(dgvViews, lcIds);
            MainControlBusiness.AddLanguageColumns(dgvBooleans, lcIds);
            MainControlBusiness.AddLanguageColumns(dgvPicklists, lcIds);
        }
    }
}