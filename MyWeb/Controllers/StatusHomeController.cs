using Microsoft.AspNetCore.Mvc;
using MyWeb.ApiController;
using MyWeb.BAL.Service;
using MyWeb.DAL.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace MyWeb.Controllers
{
    [Route("danhmuc")]
    [ApiController]
    public class DanhMucController : ApiCoreController
    {
        private readonly IDanhMucService _service;

        public DanhMucController(IDanhMucService service)
        {
            _service = service;
        }

        //Add
        [HttpPost("add")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [Consumes("application/json")]
        public async Task<ApiResponse> Add([FromBody] DanhMuc item)
        {
            try
            {
                var result = await _service.Add(item);

                if (result != null)
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
        public async Task<ApiResponse> Deleted(int Id)
        {
            try
            {
                await Task.Delay(0);
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
        public async Task<ApiResponse> Updated(DanhMuc item)
        {
            try
            {
                await Task.Delay(0);
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
        public async Task<ApiResponse> GetId(int id)
        {
            try
            {
                await Task.Delay(0);
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
        public async Task<ApiResponse> GetAll()
        {
            try
            {
                await Task.Delay(0);
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