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
    public class MultController : ApiController
    {
        [HttpPost]
        [Route("calculator/mult")]
        [ResponseType(typeof(MultResultModel))]
        public HttpResponseMessage Mult([FromBody] MultModel oMult)
        {
            int iResult = 1;
            MultResultModel oResult;
            string sTrackingID = null;

            try
            {
                oResult = new MultResultModel();

                if (oMult != null && oMult.Factors != null && oMult.Factors.Length > 1)
                {
                    foreach (int val in oMult.Factors)
                    {
                        iResult *= val;
                    }
                    oResult.Product = iResult;

                    // Once result has been calculated, checks if Tracking ID exists
                    // and in that case save operation and result
                    sTrackingID = CommonUtils.checkTrackingID(Request);
                    if (!string.IsNullOrEmpty(sTrackingID))
                    {
                        CommonUtils.saveToJournal(sTrackingID, oMult, oResult);
                    }

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