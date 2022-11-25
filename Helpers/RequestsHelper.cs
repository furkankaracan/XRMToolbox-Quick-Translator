using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Linq;


namespace Quick_Translator
{
    public class RequestsHelper
    {
        private static int SuccessCount;
        private static int FailureCount;
        private const int BulkCount = 10;
        private static ExecuteMultipleRequest request;

        public static void ExecuteMultiple(IOrganizationService service, int total, bool forceUpdate = false)
        {
            if (request == null) return;
            if (request.Requests.Count % BulkCount != 0 && !forceUpdate) return;
            try
            {
                var bulkResponse = (ExecuteMultipleResponse)service.Execute(request);

                if (bulkResponse.IsFaulted)
                {
                    FailureCount += bulkResponse.Responses.Count(r => r.Fault != null);
                    SuccessCount += request.Requests.Count - bulkResponse.Responses.Count;

                    foreach (var response in bulkResponse.Responses)
                    {
                        if (response.Fault != null)
                        {
                            string message;
                            var faultIndex = response.RequestIndex;
                            var faultRequest = request.Requests[faultIndex];

                            if (faultRequest is UpdateRequest ur)
                            {
                                message =
                                    $"Error while updating record {ur.Target.LogicalName} ({ur.Target.Id}): {response.Fault.Message}";
                            }
                            else if (faultRequest is UpdateAttributeRequest uar)
                            {
                                message =
                                    $"Error while updating attribute {uar.Attribute.LogicalName}: {response.Fault.Message}";
                            }
                            else if (faultRequest is UpdateRelationshipRequest urr)
                            {
                                message =
                                    $"Error while updating relationship {urr.Relationship.SchemaName}: {response.Fault.Message}";
                            }
                            else if (faultRequest is UpdateOptionSetRequest uosr)
                            {
                                message =
                                    $"Error while updating optionset {uosr.OptionSet.Name}: {response.Fault.Message}";
                            }
                            else if (faultRequest is UpdateOptionValueRequest uovr)
                            {
                                if (!string.IsNullOrEmpty(uovr.OptionSetName))
                                {
                                    message =
                                        $"Error while updating global optionset ({uovr.OptionSetName}) value ({uovr.Value}) label: {response.Fault.Message}";
                                }
                                else
                                {
                                    message =
                                        $"Error while updating option ({uovr.Value}) label for attribute {uovr.AttributeLogicalName} ({uovr.EntityLogicalName}): {response.Fault.Message}";
                                }
                            }
                            else if (faultRequest is SetLocLabelsRequest sllr)
                            {
                                message =
                                    $"Error while updating {sllr.AttributeName} of record {sllr.EntityMoniker.LogicalName} ({sllr.EntityMoniker.Id}): {response.Fault.Message}";
                            }
                            else
                            {
                                message = response.Fault.Message;
                            }
                        }
                    }
                }
                else
                {
                    SuccessCount += request.Requests.Count;
                }

                InitMultipleRequest();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public static void AddRequest(OrganizationRequest or)
        {
            if (request == null) InitMultipleRequest();

            request.Requests.Add(or);
        }

        private static void InitMultipleRequest()
        {
            request = new ExecuteMultipleRequest
            {
                Requests = new OrganizationRequestCollection(),
                Settings = new ExecuteMultipleSettings
                {
                    ContinueOnError = true,
                    ReturnResponses = false
                }
            };
        }
    }
}
