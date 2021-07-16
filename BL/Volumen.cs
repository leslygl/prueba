using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Volumen
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    //query
                    var volumenList = context.VolumenGetAll().ToList();


                    if (volumenList.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in volumenList)
                        {
                            ML.Volumen volumenItem = new ML.Volumen();
                            volumenItem.NumeroVolumen = row.NumeroVolumen;
                            volumenItem.Titulo = row.Titulo;

                            result.Objects.Add(volumenItem);

                        }
                        result.Correct = true;
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }


            return result;
        }
       
        public static ML.Result GetById(int IdVolumen)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    //query
                    var Object = context.CoordenadasGetById(IdVolumen).FirstOrDefault();


                    if (Object != null)
                    {


                        ML.Volumen VolumenItem = new ML.Volumen();

                        VolumenItem.NumeroVolumen = Object.IdCoordenadas;
                        VolumenItem.Titulo = Object.Estante;


                        result.Object = VolumenItem;

                    }
                    result.Correct = true;
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }


            return result;

        }
        public static ML.Result Add(ML.Volumen volumen)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var query = context.VolumenAdd(volumen.NumeroVolumen, volumen.Titulo);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido guardar las coordenadas del libro";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Volumen volumen)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var query = context.VolumenUpdate(volumen.NumeroVolumen, volumen.Titulo);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "error al actualizar la ubicación del libro";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdVolumen)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var query = context.VolumenDelete(IdVolumen);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el registro";
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }

    }
}
