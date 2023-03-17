using Newtonsoft.Json;
using System;

namespace MyWeb.ApiController
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        public ResponseCodeEnums ResponseCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string UserMessage { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string InternalMessage { get; }

        public Object Data { get; set; }
        public string MessageCode { get; set; }

        public ApiResponse(int statusCode, ResponseCodeEnums responseCode = 0, string usermessage = null, string internalmessage = null)
        {
            StatusCode = statusCode;
            UserMessage = usermessage ?? GetDefaultUserMessageForStatusCode(statusCode);
            InternalMessage = internalmessage ?? GetDefaultInternalMessageForStatusCode(statusCode);
            ResponseCode = responseCode;
        }

        private static string GetDefaultUserMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Có lỗi xảy ra bạn vui lòng kiểm tra lại";

                case 500:
                    return "Có lỗi xảy ra bạn vui lòng kiểm tra lại";

                default:
                    return null;
            }
        }

        private static string GetDefaultInternalMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "Resource not found";

                case 500:
                    return "An unhandled error occurred";

                default:
                    return null;
            }
        }
    }
}
