using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace TONYVU.WEB.API.ApiServices
{
    [RoutePrefix("api/HelperApi")]
    public class HelperApiController : ApiController
    {
        [Route("UploadFile/{type}")]
        public async Task<IHttpActionResult> UploadFile(string type)
        {
            try
            {
                var pathElevator = System.Web.Hosting.HostingEnvironment.MapPath("~/UploadFiles/Elevator");
                var pathAirConditioner = System.Web.Hosting.HostingEnvironment.MapPath("~/UploadFiles/AirConditioner");
                System.Web.HttpFileCollection fileCollection = System.Web.HttpContext.Current.Request.Files;
                if (fileCollection.Count < 1)
                {
                    return BadRequest();
                }

                //2 - Air Conditioner
                //1 - Elevator
                var pathCorrect = "";
                if (type == 2.ToString())
                {
                    pathCorrect = pathAirConditioner;
                }
                else
                {
                    pathCorrect = pathElevator;
                }
                for (int i = 0; i < fileCollection.Count; i++)
                {

                    System.Web.HttpPostedFile file = fileCollection[i];
                    if (!File.Exists(pathCorrect + Path.GetFileName(file.FileName)))
                    {
                        file.SaveAs(pathCorrect + Path.GetFileName(file.FileName));
                    }
                }
                return Ok(200);
            }
            catch (Exception exception)
            {
                throw null;
            }
        }
    }
}
