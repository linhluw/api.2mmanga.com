using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWeb.ApiController
{
    public class ApiBadRequestResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; }

        public ApiBadRequestResponse(ModelStateDictionary modelState)
            : base(400, ResponseCodeEnums.ErrorTypeParams)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }

            Errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }

        public ApiBadRequestResponse(IdentityResult identityResult)
           : base(400)
        {
            Errors = identityResult.Errors
                .Select(x => x.Code + " - " + x.Description).ToArray();
        }

        public ApiBadRequestResponse(ResponseCodeEnums responseCodeEnums, string usermessage, string internalmessage)
          : base(404, responseCodeEnums, usermessage, internalmessage)
        {
        }

        public ApiBadRequestResponse(object data, ResponseCodeEnums responseCodeEnums, string usermessage, string internalmessage)
         : base(400, responseCodeEnums, usermessage, internalmessage)
        {
            Data = data;
        }
    }
}
