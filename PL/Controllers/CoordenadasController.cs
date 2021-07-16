using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class CoordenadasController : Controller
    {
        // GET: Coordenadas
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Coordenadas coordenadasModel = new ML.Coordenadas();

            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapiCoordenadas"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(urlAPI);
                    //Get
                    var responseTask = client.GetAsync("GetAll");
                    responseTask.Wait();
                    result.Objects = new List<object>();
                    var resultAPI = responseTask.Result;
                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                        var coordenadas = readTask.Result.Objects;
                        foreach (var resultItem in coordenadas)
                        {
                            ML.Coordenadas coordenadasItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Coordenadas>(resultItem.ToString());
                            result.Objects.Add(coordenadasItemList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            coordenadasModel.CoordenadasList = result.Objects;

            return View(coordenadasModel);
        }

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdCoordenada) //Add , Update
        {
            ML.Coordenadas coordenadas = new ML.Coordenadas();


            if (IdCoordenada == null)//Add
            {
                return View(coordenadas);
            }
            else //Update
            {
                ML.Result result = BL.Coordenadas.GetById(IdCoordenada.Value);

                if (result.Correct)
                {
                    coordenadas.IdCoordenada = ((ML.Coordenadas)result.Object).IdCoordenada;
                    coordenadas.Estante = ((ML.Coordenadas)result.Object).Estante;
                    coordenadas.Sala = ((ML.Coordenadas)result.Object).Sala;
                    coordenadas.Librero = ((ML.Coordenadas)result.Object).Librero;
                    coordenadas.Posicion = ((ML.Coordenadas)result.Object).Posicion;


                    return View(coordenadas);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }

        }
        public ActionResult Delete(int IdCoordenada)
        {
            ML.Result result = new ML.Result();
            using (var client = new HttpClient())
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapiCoordenadas"];
                client.BaseAddress = new Uri(urlAPI);
                //HttpDelete
                var deleteTask = client.DeleteAsync("Delete/" + IdCoordenada);
                deleteTask.Wait();
                var resultTask = deleteTask.Result;
                if (resultTask.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAll");
                }
                return RedirectToAction("GetAll");
            }
        }
    }
}