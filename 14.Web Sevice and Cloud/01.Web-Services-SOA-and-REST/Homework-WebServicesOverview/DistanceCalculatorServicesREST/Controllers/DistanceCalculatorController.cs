namespace DistanceCalculatorServicesREST.Controllers
{
    using System;
    using System.Web.Http;

    using Models;

    public class DistanceCalculatorController : ApiController
    {
        // [Route("CalcDistance")]
        public IHttpActionResult CalcDistance(PointModel point)
        {
            int deltaX = point.StartPointX - point.EndPointX;
            int deltaY = point.StartPointY - point.EndPointY;
            return this.Ok(Math.Sqrt(deltaX * deltaX + deltaY * deltaY));
        }
    }
}