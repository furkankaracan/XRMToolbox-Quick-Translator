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

namespace Quick_Translator
{
    public partial class MainControl : PluginControlBase
    {
        #region variables

        private Settings mySettings;
        private List<int> lcIdList;

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
                    if(e.Error != null)
                    {
                        string errorMessage = CrmExceptionHelper.GetErrorMessage(e.Error, true);
                        MessageBox.Show(this, errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        foreach (EntityMetadata entityMetadata in (List<EntityMetadata>)e.Result)
                        {
                            var item = new ListViewItem { Text = entityMetadata.LogicalName, Tag = e };
                            item.SubItems.Add(entityMetadata.DisplayName?.UserLocalizedLabel?.Label);
                            lvEntities.Items.Add(item);
                        }
                    }
                }
            });
        }
    }
}