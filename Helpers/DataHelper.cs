using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;


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
    }
}
