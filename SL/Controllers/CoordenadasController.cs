using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class CoordenadasController : ApiController
    {
        // GET: api/Coordenadas
        [Route("api/Coordenadas/GetAll")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ML.Result result = BL.Coordenadas.GetAll();
            
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // GET: api/Coordenadas/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Coordenadas
        [Route("api/Coordenadas/Add")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ML.Coordenadas coordenadas)
        {
            ML.Result result = BL.Coordenadas.Add(coordenadas);
            if (result.Correct)
            {
                return Ok(result);
            }

            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // PUT: api/Coordenadas/5
        [Route("api/Coordenadas/Update/{IdCoordenada}")]
        [HttpPut]
        public IHttpActionResult Post(int IdCoordenada, [FromBody] ML.Coordenadas coordenadas)
        {
            coordenadas.IdCoordenada = IdCoordenada;
            ML.Result result = BL.Coordenadas.Update(coordenadas);
            if (result.Correct)
            {
                return Ok(result);
            }

            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }


        }

        // DELETE: api/Coordenadas/5
        [Route("api/Coordenadas/Delete/{IdCoordenada}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdCoordenada)
        {
            ML.Result result = BL.Coordenadas.Delete(IdCoordenada);
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
