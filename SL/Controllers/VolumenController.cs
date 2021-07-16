using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class VolumenController : ApiController
    {
       
            // GET: api/Volumen
            [Route("api/Volumen/GetAll")]
            [HttpGet]
            public IHttpActionResult Get()
            {
                ML.Result result = BL.Volumen.GetAll();

                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, result);
                }
            }

            // GET: api/Volumen/5
            public string Get(int id)
            {
                return "value";
            }

            // POST: api/Coordenadas
            [Route("api/Volumen/Add")]
            [HttpPost]
            public IHttpActionResult Post([FromBody]ML.Volumen volumen)
            {
                ML.Result result = BL.Volumen.Add(volumen);
                if (result.Correct)
                {
                    return Ok(result);
                }

                else
                {
                    return Content(HttpStatusCode.BadRequest, result);
                }
            }

            // PUT: api/Volumen/5
            [Route("api/Volumen/Update/{IdVolumen}")]
            [HttpPut]
            public IHttpActionResult Post(int NumeroVolumen, [FromBody] ML.Volumen volumen)
            {
                volumen.NumeroVolumen = NumeroVolumen;
                ML.Result result = BL.Volumen.Update(volumen);
                if (result.Correct)
                {
                    return Ok(result);
                }

                else
                {
                    return Content(HttpStatusCode.BadRequest, result);
                }


            }

            // DELETE: api/Volumen/5
            [Route("api/Volumen/Delete/{IdVolumen}")]
            [HttpDelete]
            public IHttpActionResult Delete(int IdVolumen)
            {
                ML.Result result = BL.Volumen.Delete(IdVolumen);
                if (result.Correct)
                {
                    return Ok(result);
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, result);
                }
            }
        }
    
}
