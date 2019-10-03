//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         Clase encargada del negocio de la aplicacion
//####################################################################
namespace Solve.BM.Calculate
{
    using Solve.DM.Calculate;
    using Solve.DM.Database;
    using Solve.DT.Calculate;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BMCalculate: IBMCalculate
    {
        private ICalculateRepository _objCalculateRepository;

        public BMCalculate(ICalculateRepository CalculateRepository)
        {
            _objCalculateRepository = CalculateRepository;
        }

        /// <summary>
        /// Se encarga de convertir la informacion del archivo de texto
        /// en una estructura de datos para trabajar en la aplicación
        /// </summary>
        /// <returns></returns>
        public DTCalculate infoTextToStructur(DTViajeUsuario objinfo) {
            try
            {
                DTCalculate ObjCalcular = new DTCalculate();

                //Convertir la informacion del archivo en la estructura deseada.
                var infoarchivo = objinfo.info.Split('\n');

                //Identificar numero de dias
                ObjCalcular.dias = Int32.Parse(infoarchivo[0]);

                //Calcular elementos por dia
                for (int i = 1; i < infoarchivo.Length - 1; i++)
                {
                    DTElemento ElementoDia = new DTElemento();
                    //Identificar cantidad de elementos por dia
                    ElementoDia.cantidadElementos = Int32.Parse(infoarchivo[i]);
                    List<int> Pesos = new List<int>();
                    //Identificar peso de los elementos
                    for (int b = 1; b <= ElementoDia.cantidadElementos; b++)
                    {
                        i = i + 1;
                        Pesos.Add(Int32.Parse(infoarchivo[i]));
                    }
                    ElementoDia.pesos = Pesos;
                    ObjCalcular.ElementosDia.Add(ElementoDia);
                }

                return ObjCalcular;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Se encarga de analizar los datos y darle una respuesta
        /// </summary>
        /// <param name="ObjCalculate"></param>
        /// <returns></returns>
        public DTRespuesta CalculateCase(DTCalculate ObjCalculate) {
            DTRespuesta Respuesta = new DTRespuesta();
            try
            {
                //calcular el case para cada dia
                int i = 1;
                List<string> cases = new List<string>();
                foreach (DTElemento item in ObjCalculate.ElementosDia)
                {
                    decimal pesobolsa = 50;
                    int pesodia = item.pesos.Sum();
                    int pesopromedio = pesodia / item.cantidadElementos;
                    decimal itemPesoMax = item.pesos.Max();
                    int viajes = 0;

                    if (itemPesoMax >= pesobolsa)
                    {
                        int restante = 0;
                        foreach (int peso in item.pesos)
                        {
                            if (peso >= pesobolsa)
                            {
                                viajes = viajes + 1;
                            }
                            else {
                                restante = restante + 1;
                            }
                        }
                        viajes = viajes + (restante / 2);
                    }
                    else {
                        viajes = item.cantidadElementos/ (int)Math.Round(pesobolsa / itemPesoMax) ; 
                    }

                    string Case = "Case #" + i + ": " + viajes+"  \n";
                    i = i + 1;
                    cases.Add(Case);
                }
                Respuesta.Resultado = true;
                Respuesta.Case = cases;

                return Respuesta;
            }
            catch (Exception ex)
            {
                Respuesta.Resultado = false;
                Respuesta.Mensaje = ex.Message;
                return Respuesta;
            }
        }

        /// <summary>
        /// Metodo encargado de registar en base de datos 
        /// la ejecución del programa.
        /// </summary>
        /// <param name="ObjElement"></param>
        /// <returns>bool</returns>
        public bool CrearAuditoria(DTViajeUsuario ObjElement) {
            try
            {
                Auditoria Auditoria = new Auditoria();
                Auditoria.Ejecutor = ObjElement.usuario;
                Auditoria.FechaEjecucion = DateTime.Now;
                //Invocamos repository
                _objCalculateRepository.Create(Auditoria);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
