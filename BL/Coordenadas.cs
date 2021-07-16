using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Coordenadas
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    //query
                    var coordenadasList = context.CoordenadasGetAll().ToList();


                    if (coordenadasList.Count > 0)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in coordenadasList)
                        {
                            ML.Coordenadas coordenadasItem = new ML.Coordenadas();
                            coordenadasItem.IdCoordenada = row.IdCoordenadas;
                            coordenadasItem.Estante = row.Estante;
                            coordenadasItem.Sala = row.Sala;
                            coordenadasItem.Librero = row.Librero;
                            coordenadasItem.Posicion = row.Posicion.Value;
                            
                            result.Objects.Add(coordenadasItem);

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
        public static ML.Result GetById(int IdCoordenada)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    //query
                    var coordenadasObject = context.CoordenadasGetById(IdCoordenada).FirstOrDefault();


                    if (coordenadasObject != null)
                    {


                        ML.Coordenadas coordenadasItem = new ML.Coordenadas();

                        coordenadasItem.IdCoordenada = coordenadasObject.IdCoordenadas;
                        coordenadasItem.Estante = coordenadasObject.Estante;
                        coordenadasItem.Sala = coordenadasObject.Sala;
                        coordenadasItem.Librero = coordenadasObject.Librero;
                        coordenadasItem.Posicion = coordenadasObject.Posicion.Value;



                        result.Object = coordenadasItem;

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
        public static ML.Result Add(ML.Coordenadas coordenadas)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var query = context.CoordenadasAdd(coordenadas.Estante,coordenadas.Sala,coordenadas.Librero,coordenadas.Posicion);

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
        public static ML.Result Update(ML.Coordenadas coordenadas)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var query = context.CoordenadasUpdate(coordenadas.IdCoordenada, coordenadas.Estante, coordenadas.Sala, coordenadas.Librero, coordenadas.Posicion);

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
        public static ML.Result Delete(int IdCoordenada)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.BibliotecaEntities context = new DL.BibliotecaEntities())
                {
                    var query = context.CoordenadasDelete(IdCoordenada);

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
