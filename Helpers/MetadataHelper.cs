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

        public static IEnumerable<Entity> RetrieveEntityForms(string entityLogicalName, IOrganizationService orgService)
        {
            var query = new QueryExpression("systemform")
            {
                ColumnSet = new ColumnSet(true),
                Criteria = new FilterExpression()
                {
                    Conditions =
                    {
                        new ConditionExpression("objecttypecode", ConditionOperator.Equal, entityLogicalName),
                        new ConditionExpression("type", ConditionOperator.In, new[]{2,6,7})
                    }
                }
            };

            return orgService.RetrieveMultiple(query).Entities;
        }

        public static List<FormMetadata> RetrieveFormMetadata(string entityLogicalName, IOrganizationService orgService)
        {
            var forms = RetrieveEntityForms(entityLogicalName, orgService);

            var formMetadataList = new List<FormMetadata>();

            foreach (var form in forms)
            {
                var formXMLString = form.GetAttributeValue<string>("formxml");
                var formXML = new XmlDocument();
                formXML.LoadXml(formXMLString);

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
    }
}
