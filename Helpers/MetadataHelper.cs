using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XrmToolBox;

namespace Quick_Translator
{
    internal class MetadataHelper
    {
        public static List<EntityMetadata> RetrieveAllEntities(IOrganizationService orgService)
        {
            List<EntityMetadata> entityMetadataList = new List<EntityMetadata>();

            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity
            };

            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)orgService.Execute(request);

            foreach (var entityMetadata in response.EntityMetadata)
            {
                if (entityMetadata.DisplayName?.UserLocalizedLabel != null
                    && (entityMetadata.IsCustomizable.Value || entityMetadata.IsManaged.Value == false))
                    entityMetadataList.Add(entityMetadata);
            }

            return entityMetadataList;
        }

        public static List<EntityMetadata> RetrieveCustomEntities(IOrganizationService orgService)
        {
            List<EntityMetadata> entityMetadataList = new List<EntityMetadata>();

            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity
            };

            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)orgService.Execute(request);

            foreach (var entityMetadata in response.EntityMetadata)
            {
                if (entityMetadata.DisplayName?.UserLocalizedLabel != null
                    && entityMetadata.IsCustomEntity.Value == true
                    && (entityMetadata.IsCustomizable.Value || entityMetadata.IsManaged.Value == false))
                    entityMetadataList.Add(entityMetadata);
            }

            return entityMetadataList;
        }

        public static List<EntityMetadata> RetrieveDefaultEntities(IOrganizationService orgService)
        {
            List<EntityMetadata> entityMetadataList = new List<EntityMetadata>();

            RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest
            {
                EntityFilters = EntityFilters.Entity
            };

            RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)orgService.Execute(request);

            foreach (var entityMetadata in response.EntityMetadata)
            {
                if (entityMetadata.DisplayName?.UserLocalizedLabel != null
                    && entityMetadata.IsCustomEntity.Value == false
                    && (entityMetadata.IsCustomizable.Value || entityMetadata.IsManaged.Value == false))
                    entityMetadataList.Add(entityMetadata);
            }

            return entityMetadataList;
        }

        public static List<FormMetadata> RetrieveFormMetadata(string entityLogicalName, IOrganizationService orgService)
        {
            var forms = DataHelper.GetEntityFormsByEntityLogicalName(entityLogicalName, orgService);

            var formMetadataList = new List<FormMetadata>();

            foreach (var form in forms)
            {
                var formMetadata = formMetadataList.FirstOrDefault(f => f.FormUniqueId == form.GetAttributeValue<Guid>("formidunique"));

                if (formMetadata == null)
                {
                    formMetadata = new FormMetadata
                    {
                        FormUniqueId = form.GetAttributeValue<Guid>("formidunique"),
                        Id = form.GetAttributeValue<Guid>("formid"),
                        Entity = entityLogicalName,
                        Names = new Dictionary<int, string>(),
                        Descriptions = new Dictionary<int, string>()
                    };
                    formMetadataList.Add(formMetadata);
                }

                RetrieveLocLabelsRequest request;
                RetrieveLocLabelsResponse response;

                // Names
                request = new RetrieveLocLabelsRequest
                {
                    AttributeName = "name",
                    EntityMoniker = new EntityReference("systemform", form.Id)
                };

                response = (RetrieveLocLabelsResponse)orgService.Execute(request);

                foreach (var locLabel in response.Label.LocalizedLabels)
                {
                    formMetadata.Names.Add(locLabel.LanguageCode, locLabel.Label);
                }
            }

            return formMetadataList;
        }

        public static void RetrieveFormComponentsMetadata(Entity form, int lcId, string entityLogicalName,
            List<FormFieldMetadata> formFieldMetadataList, List<FormSectionMetadata> formSectionMetadataList, List<FormTabMetadata> formTabMetadataList)
        {
            #region Form XML
            var formXMLString = form.GetAttributeValue<string>("formxml");
            var formXML = new XmlDocument();
            formXML.LoadXml(formXMLString);
            #endregion Form XML

            #region Extract Form Header
            var cellNodesHeader = formXML.DocumentElement.SelectNodes("header/rows/row/cell");

            foreach (XmlNode cellNode in cellNodesHeader)
            {
                ExtractFormFieldMetadata(cellNode, formFieldMetadataList, form, null, null, entityLogicalName, lcId);
            }
            #endregion Extract Form Header

            #region Extract Form Fields
            foreach (XmlNode tabNode in formXML.SelectNodes("//tab"))
            {
                var tabName = ExtractTabMetadata(tabNode, lcId, formTabMetadataList, form, entityLogicalName);

                foreach (XmlNode sectionNode in tabNode.SelectNodes("columns/column/sections/section"))
                {
                    var sectionName = ExtractSectionMetadata(sectionNode, lcId, formSectionMetadataList, form,
                        tabName, entityLogicalName);

                    #region Extract Labels
                    foreach (XmlNode labelNode in sectionNode.SelectNodes("rows/row/cell"))
                    {
                        ExtractFormFieldMetadata(labelNode, formFieldMetadataList, form, tabName, sectionName,
                            entityLogicalName, lcId);
                    }
                    #endregion Extract Labels
                }

                #endregion Extract Form Fields

                #region Extract Form Footer
                var cellNodes = formXML.DocumentElement.SelectNodes("footer/rows/row/cell");
                foreach (XmlNode cellNode in cellNodes)
                {
                    ExtractFormFieldMetadata(cellNode, formFieldMetadataList, form, null, null, entityLogicalName, lcId);
                }
                #endregion Extract Form Footer
            }
            return;
        }

        public static void RetrieveViewsMetadata(IOrganizationService orgService, List<ViewMetadata> viewMetadataList, int objectTypeCode)
        {
            var views = DataHelper.GetViewsByObjectTypeCode(objectTypeCode, orgService);

            foreach (var view in views)
            {
                var viewMetadata = viewMetadataList.FirstOrDefault(prm => prm.Id == view.Id);
                if (viewMetadata == null)
                {
                    viewMetadata = new ViewMetadata
                    {
                        Id = view.Id,
                        Entity = view.GetAttributeValue<string>("returnedtypecode"),
                        Type = view.GetAttributeValue<int>("querytype"),
                        Names = new Dictionary<int, string>(),
                        Descriptions = new Dictionary<int, string>()
                    };
                    viewMetadataList.Add(viewMetadata);
                }

                RetrieveLocLabelsRequest request = new RetrieveLocLabelsRequest
                {
                    AttributeName = "name",
                    EntityMoniker = new EntityReference("savedquery", view.Id)
                };

                RetrieveLocLabelsResponse response = (RetrieveLocLabelsResponse)orgService.Execute(request);

                var locLabelList = response.Label.LocalizedLabels.OrderByDescending(prm => prm.LanguageCode);
                foreach (var locLabel in locLabelList)
                {
                    viewMetadata.Names.Add(locLabel.LanguageCode, locLabel.Label);
                }

                request = new RetrieveLocLabelsRequest
                {
                    AttributeName = "description",
                    EntityMoniker = new EntityReference("savedquery", view.Id)
                };

                response = (RetrieveLocLabelsResponse)orgService.Execute(request);
                locLabelList = response.Label.LocalizedLabels.OrderByDescending(prm => prm.LanguageCode);
                foreach (var locLabel in locLabelList)
                {
                    viewMetadata.Descriptions.Add(locLabel.LanguageCode, locLabel.Label);
                }
            }
        }

        private static void ExtractFormFieldMetadata(XmlNode cellNode, List<FormFieldMetadata> formFieldMetadataList, Entity form, string tabName,
            string sectionName, string entityLogicalName, int lcId)
        {
            if (cellNode.Attributes == null)
                return;

            var cellIdAttr = cellNode.Attributes["id"];
            if (cellIdAttr == null)
                return;

            if (cellNode.ChildNodes.Count == 0)
                return;

            var controlNode = cellNode.SelectSingleNode("control");
            if (controlNode == null || controlNode.Attributes == null)
                return;

            var formFieldMetadata = formFieldMetadataList.FirstOrDefault(f => f.Id == new Guid(cellIdAttr.Value) && f.FormUniqueId == form.GetAttributeValue<Guid>("formidunique"));
            if (formFieldMetadata == null)
            {
                formFieldMetadata = new FormFieldMetadata
                {
                    Id = new Guid(cellIdAttr.Value),
                    Form = form.GetAttributeValue<string>("name"),
                    FormUniqueId = form.GetAttributeValue<Guid>("formidunique"),
                    FormId = form.GetAttributeValue<Guid>("formid"),
                    Tab = tabName,
                    Section = sectionName,
                    Entity = entityLogicalName,
                    Attribute = controlNode.Attributes["id"].Value,
                    Names = new Dictionary<int, string>()
                };
                formFieldMetadataList.Add(formFieldMetadata);
            }

            var labelNode = cellNode.SelectSingleNode("labels/label[@languagecode='" + lcId + "']");
            var labelNodeAttributes = labelNode?.Attributes;
            var labelDescription = labelNodeAttributes?["description"];

            if (formFieldMetadata.Names.ContainsKey(lcId))
            {
                return;
            }

            formFieldMetadata.Names.Add(lcId, labelDescription == null ? string.Empty : labelDescription.Value);
        }

        private static string ExtractTabMetadata(XmlNode tabNode, int lcId, List<FormTabMetadata> formTabMetadataList, Entity form,
            string entityLogicalName)
        {
            if (tabNode.Attributes == null || tabNode.Attributes["id"] == null)
                return string.Empty;

            var tabId = tabNode.Attributes["id"].Value;

            var tabLabelNode = tabNode.SelectSingleNode("labels/label[@languagecode='" + lcId + "']");
            if (tabLabelNode == null || tabLabelNode.Attributes == null)
                return string.Empty;

            var tabLabelDescAttr = tabLabelNode.Attributes["description"];
            if (tabLabelDescAttr == null)
                return string.Empty;

            var tabName = tabLabelDescAttr.Value;

            var formTabMetadata = formTabMetadataList.FirstOrDefault(f => f.Id == new Guid(tabId) && f.FormUniqueId == form.GetAttributeValue<Guid>("formidunique"));
            if (formTabMetadata == null)
            {
                formTabMetadata = new FormTabMetadata
                {
                    Id = new Guid(tabId),
                    FormUniqueId = form.GetAttributeValue<Guid>("formidunique"),
                    FormId = form.GetAttributeValue<Guid>("formid"),
                    Form = form.GetAttributeValue<string>("name"),
                    Entity = entityLogicalName,
                    Names = new Dictionary<int, string>()
                };
                formTabMetadataList.Add(formTabMetadata);
            }

            if (formTabMetadata.Names.ContainsKey(lcId))
            {
                return tabName;
            }

            formTabMetadata.Names.Add(lcId, tabName);
            return tabName;
        }

        public static string ExtractSectionMetadata(XmlNode sectionNode, int lcId, List<FormSectionMetadata> formSectionMetadataList, Entity form, string tabName, string entityLogicalName)
        {
            if (sectionNode.Attributes == null || sectionNode.Attributes["id"] == null)
                return string.Empty;
            var sectionId = sectionNode.Attributes["id"].Value;

            var sectionLabelNode = sectionNode.SelectSingleNode("labels/label[@languagecode='" + lcId + "']");
            if (sectionLabelNode == null || sectionLabelNode.Attributes == null)
                return string.Empty;

            var sectionNameAttr = sectionLabelNode.Attributes["description"];
            if (sectionNameAttr == null)
                return string.Empty;
            var sectionName = sectionNameAttr.Value;

            var formSectionMetadata = formSectionMetadataList.FirstOrDefault(f => f.Id == new Guid(sectionId) && f.FormUniqueId == form.GetAttributeValue<Guid>("formidunique"));
            if (formSectionMetadata == null)
            {
                formSectionMetadata = new FormSectionMetadata
                {
                    Id = new Guid(sectionId),
                    FormUniqueId = form.GetAttributeValue<Guid>("formidunique"),
                    FormId = form.GetAttributeValue<Guid>("formid"),
                    Form = form.GetAttributeValue<string>("name"),
                    Tab = tabName,
                    Entity = entityLogicalName,
                    Names = new Dictionary<int, string>()
                };
                formSectionMetadataList.Add(formSectionMetadata);
            }

            if (formSectionMetadata.Names.ContainsKey(lcId))
            {
                return sectionName;
            }

            formSectionMetadata.Names.Add(lcId, sectionName);
            return sectionName;
        }
    }
}
