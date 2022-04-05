using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;

namespace Quick_Translator
{
    public class DataHelper
    {
        public static Entity GetCurrentUserSettings(IOrganizationService service)
        {
            var qe = new QueryExpression("usersettings");
            qe.ColumnSet = new ColumnSet(new[] { "uilanguageid", "localeid" });
            qe.Criteria = new FilterExpression();
            qe.Criteria.AddCondition("systemuserid", ConditionOperator.EqualUserId);
            var settings = service.RetrieveMultiple(qe);

            return settings[0];
        }

        public static List<Entity> GetViewsByObjectTypeCode(int objectTypeCode, IOrganizationService orgService)
        {
            var queryByAttribute = new QueryByAttribute()
            {
                EntityName = "savedquery",
                ColumnSet = new ColumnSet("returnedtypecode", "querytype")
            };

            queryByAttribute.Attributes.Add("returnedtypecode");
            queryByAttribute.Values.Add(objectTypeCode);

            return orgService.RetrieveMultiple(queryByAttribute)?.Entities?.ToList();
        }

        public static IEnumerable<Entity> GetEntityFormsByEntityLogicalName(string entityLogicalName, IOrganizationService orgService)
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
    }
}
