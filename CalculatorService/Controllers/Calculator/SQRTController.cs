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
    public class SQRTController : ApiController
    {
        [HttpPost]
        [Route("calculator/sqrt")]
        [ResponseType(typeof(SQRTResultModel))]
        public HttpResponseMessage Mult([FromBody] SQRTModel oSQRT)
        {
            SQRTResultModel oResult;
            string sTrackingID = null;

            try
            {
                oResult = new SQRTResultModel();

                if (oSQRT != null && oSQRT.Number > 0)
                {
                    // Operation is plus (+) because a less than zero value is expected as subtrahend
                    oResult.Square = (int)Math.Round(Math.Sqrt(Convert.ToDouble(oSQRT.Number)));

                    // Once result has been calculated, checks if Tracking ID exists
                    // and in that case save operation and result
                    sTrackingID = CommonUtils.checkTrackingID(Request);
                    if (!string.IsNullOrEmpty(sTrackingID))
                    {
                        CommonUtils.saveToJournal(sTrackingID, oSQRT, oResult);
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