using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace MyWeb.ApiController
{
    public abstract class ApiCoreController : ControllerBase
    {
        private readonly ILogger<ApiCoreController> _logger;

        public ApiCoreController()
        {
        }

        public ApiCoreController(ILogger<ApiCoreController> logger)
        {
            _logger = logger;
        }

        protected bool IsValidOperation()
        {
            return true;
        }

        protected new ApiResponse Response(object result = null)
        {
            if (IsValidOperation())
            {
                return new ApiOkResultResponse(result, "", "");
            }

            return new ApiBadRequestResponse(ResponseCodeEnums.ErrorKey, "Có lỗi sảy ra khi thực hiện", "");
        }

        protected new IActionResult Response(object result = null, string usermessage = "Lấy dữ liệu thành công", string internalmessage = "Thành công")
        {
            return Ok(new ApiOkResultResponse(result, usermessage, internalmessage));
        }

        protected BadRequestObjectResult ErrorResponse(string usermessage = "Cập nhật dữ liệu không thành công!", string internalmessage = "Dữ liệu đầu vào không đúng")
        {
            return BadRequest(new ApiBadRequestResponse(ResponseCodeEnums.ErrorTypeParams, usermessage, internalmessage));
        }

        protected void NotifyModelStateErrors()
        {
            var erros = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            //_mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected void AddIdentityErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                NotifyError(result.ToString(), error.Description);
            }
        }
    }
}
