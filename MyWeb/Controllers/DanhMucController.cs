using Microsoft.AspNetCore.Mvc;
using MyWeb.ApiController;
using MyWeb.BAL.Service;
using MyWeb.DAL.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MyWeb.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ApiCoreController
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        //Add
        [HttpPost("add")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public ApiResponse Add([FromBody] Category item)
        {
            try
            {
                var result = _service.Add(item);

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

        //Update
        [HttpPost("updated")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public ApiResponse Updated(Category item)
        {
            try
            {
                var result = _service.Update(item);

                if (result)
                {
                    return new ApiOkResultResponse(result, LanguageKey.UpdateSuccess, "");
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
                    return new ApiBadRequestResponse(ResponseCodeEnums.ErrorKey, LanguageKey.ErrorTryAgain, "");
                }

            }
            catch (Exception)
            {
                return new ApiBadRequestResponse(ResponseCodeEnums.ErrorTypeParams, LanguageKey.ErrorInputParams, "");
            }
        }

        //GET All Person
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
                    return new ApiBadRequestResponse(ResponseCodeEnums.ErrorKey, LanguageKey.ErrorTryAgain, "");
                }

            }
            catch (Exception)
            {
                return new ApiBadRequestResponse(ResponseCodeEnums.ErrorTypeParams, LanguageKey.ErrorInputParams, "");
            }
        }
    }
}