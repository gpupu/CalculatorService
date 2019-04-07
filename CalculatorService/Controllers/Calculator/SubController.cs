using CalculatorService.Common;
using CalculatorService.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace CalculatorService.Controllers.Calculator
{
    public class SubController : ApiController
    {

        // POST calculator/<controller>
        [HttpPost]
        [ResponseType(typeof(SubResultModel))]
        public HttpResponseMessage Sub(HttpRequestMessage request, SubModel oSubstraction)
        {
            SubResultModel oResult;
            string sTrackingID = null;

            try
            {
                oResult = new SubResultModel();

                if (oSubstraction != null && oSubstraction.Subtrahend <= 0)
                {
                    // Operation is plus (+) because a less than zero value is expected as subtrahend
                    oResult.Difference = oSubstraction.Minuend + oSubstraction.Subtrahend;

                    // Once result has been calculated, checks if Tracking ID exists
                    // and in that case save operation and result
                    sTrackingID = CommonUtils.checkTrackingID(Request);
                    if (!string.IsNullOrEmpty(sTrackingID))
                    {
                        CommonUtils.saveToJournal(sTrackingID, oSubstraction, oResult);
                    }

                    return request.CreateResponse(HttpStatusCode.OK, oResult);
                }
                // In other case input is not valid
                else
                {
                    HttpError err = new HttpError("An invalid request has been received. This may mean the HTTP requests and/or the HTTP body may contains some errors which should be fixed.");
                    return request.CreateResponse(HttpStatusCode.BadRequest, err);
                }
            }
            catch (Exception ex)
            {
                // TODO: This exception should be logged somewhere
                // If something happens throws Internal Error
                HttpError err = new HttpError("An unexpected error condition was triggered which made impossible to fulfill the request. Please try again or contact support.");
                return request.CreateErrorResponse(HttpStatusCode.InternalServerError, err);
            }
        }
    }
}