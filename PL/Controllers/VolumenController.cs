using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class VolumenController : Controller
    {
        // GET: Volumen
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Volumen volumenModel = new ML.Volumen();

            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapiVolumen"];
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

                        var volumen = readTask.Result.Objects;
                        foreach (var resultItem in volumen)
                        {
                            ML.Volumen volumenItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Volumen>(resultItem.ToString());
                            result.Objects.Add(volumenItemList);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            volumenModel.VolumenList = result.Objects;

            return View(volumenModel);
        }

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdVolumen) //Add , Update
        {
            ML.Volumen volumen = new ML.Volumen();


            if (IdVolumen == null)//Add
            {
                return View(volumen);
            }
            else //Update
            {
                ML.Result result = BL.Volumen.GetById(IdVolumen.Value);

                if (result.Correct)
                {
                    volumen.NumeroVolumen = ((ML.Volumen)result.Object).NumeroVolumen;
                    volumen.Titulo= ((ML.Volumen)result.Object).Titulo;
                  


                    return View(volumen);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }

        }
        public ActionResult Delete(int IdVolumen)
        {
            ML.Result result = new ML.Result();
            using (var client = new HttpClient())
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["URLapiVolumen"];
                client.BaseAddress = new Uri(urlAPI);
                //HttpDelete
                var deleteTask = client.DeleteAsync("Delete/" + IdVolumen);
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