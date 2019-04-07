using CalculatorService.Common;
using CalculatorService.Common.Entities;
using CalculatorService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ValueProviders;

namespace CalculatorService.Controllers.Calculator
{
    public class JournalController : ApiController
    {

        [HttpPost]
        [Route("journal/query")]
        [ResponseType(typeof(JournalQueryOperationList))]
        public HttpResponseMessage Query([FromBody] JournalQuery oQuery)
        {
            JournalQueryOperationList oResult;

            try
            {
                if (oQuery != null && !string.IsNullOrEmpty(oQuery.Id))
                {
                    oResult = JournalAccess.GetJournal(oQuery.Id);
                    
                    return Request.CreateResponse(HttpStatusCode.OK, oResult);
                }
                // In other case input is not valid
                else
                {
                    HttpError err = new HttpError("An invalid request has been received. This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed.");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, err);
                }
            }
            catch (Exception ex)
            {
                // TODO: This exception should be logged somewhere
                // If something happens throws Internal Error
                HttpError err = new HttpError("An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support.");
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, err);
            }
        }

    }
}