namespace MyWeb.ApiController
{
    public class ApiOkResultResponse : ApiResponse
    {
        public object Data { get; set; }

        public ApiOkResultResponse(object data, string usermessage, string internalmessage)
           : base(200, ResponseCodeEnums.Success, usermessage, internalmessage)
        {
            Data = data;
        }
    }
}
