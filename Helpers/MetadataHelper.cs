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
    }
}
