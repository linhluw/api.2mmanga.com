using Microsoft.AspNetCore.Mvc;
using MyWeb.ApiController;
using MyWeb.BAL.Service;
using MyWeb.DAL.Models;
using System;
using System.Net;

namespace MyWeb.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ApiCoreController
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        //Create
        [HttpPost("create")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public ApiResponse Create([FromBody] User item)
        {
            try
            {
                var result = _service.CreateOrUpdate(item, string.IsNullOrEmpty(item.PK_UserId));

                if (result)
                {
                    return new ApiOkResultResponse(result, LanguageKey.InsertSuccess, "");
                }
                else
                {
                    return new ApiBadRequestResponse(ResponseCodeEnums.ErrorKey, LanguageKey.ErrorTryAgain, "");
                }

            }
            catch (Exception)
            {
                return new ApiBadRequestResponse(ResponseCodeEnums.ErrorTypeParams, LanguageKey.ErrorInputParams, "");
            }
        }

        //Delete
        [HttpPost("deleted")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public ApiResponse Deleted(string Id)
        {
            try
            {
                var result = _service.Delete(Id);

                if (result)
                {
                    return new ApiOkResultResponse(result, LanguageKey.DeleteSuccess, "");
                }
                else
                {
                    return new ApiBadRequestResponse(ResponseCodeEnums.ErrorKey, LanguageKey.ErrorTryAgain, "");
                }

            }
            catch (Exception)
            {
                return new ApiBadRequestResponse(ResponseCodeEnums.ErrorTypeParams, LanguageKey.ErrorInputParams, "");
            }
        }

        //GET ID
        [HttpGet("getid")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public ApiResponse GetId(string id)
        {
            try
            {
                var result = _service.GetById(id);

                if (result != null)
                {
                    return new ApiOkResultResponse(result, LanguageKey.GetSuccess, "");
                }
                else
                {
                    return new ApiBadRequestResponse(ResponseCodeEnums.ErrorKey, LanguageKey.GetFailed, "");
                }

            }
            catch (Exception)
            {
                return new ApiBadRequestResponse(ResponseCodeEnums.ErrorTypeParams, LanguageKey.ErrorInputParams, "");
            }
        }

        //GET All
        [HttpGet("getall")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public ApiResponse GetAll()
        {
            try
            {
                var result = _service.GetAll();

                if (result != null)
                {
                    return new ApiOkResultResponse(result, LanguageKey.GetSuccess, "");
                }
                else
                {
                    return new ApiBadRequestResponse(ResponseCodeEnums.ErrorKey, LanguageKey.GetFailed, "");
                }

            }
            catch (Exception)
            {
                return new ApiBadRequestResponse(ResponseCodeEnums.ErrorTypeParams, LanguageKey.ErrorInputParams, "");
            }
        }
    }
}