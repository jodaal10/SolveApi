using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Solve.BM.Calculate;
using Solve.DM.Database;
using Solve.DT.Calculate;
using FluentValidation;
using Solve.DT.Utilities;
using FluentValidation.Results;

namespace Solve.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private IBMCalculate _ObjCalculate;

        public CalculateController(IBMCalculate Icalculate)
        {
            _ObjCalculate = Icalculate;
        }

        [HttpPost]
        [Route("CalculateTrip")]
        public ActionResult<DTRespuesta> CalculateTrip(DTViajeUsuario Elements)
        {
            DTCalculate Calcular = new DTCalculate();
            DTCalculateValidator calcularvalidator = new DTCalculateValidator();
            DTViajeUsuarioValidator reqval = new DTViajeUsuarioValidator();
            DTRespuesta Respuesta = new DTRespuesta();
            ValidationResult result = new ValidationResult();

            //Validar la informacion del request
            result = reqval.Validate(Elements);
            if (result.IsValid)
            {
                //Convertir la informacion del texto en una structura de datos
                Calcular = _ObjCalculate.infoTextToStructur(Elements);

                //validamos los datos
                result = calcularvalidator.Validate(Calcular);

                if (result.IsValid)
                {
                    //calcular los viajes segun la información recibida.
                    Respuesta = _ObjCalculate.CalculateCase(Calcular);
                    //Almacenamos auditoria de la ejecucion
                    _ObjCalculate.CrearAuditoria(Elements);
                }
                else
                {
                    Respuesta.Resultado = false;
                    foreach (var failure in result.Errors)
                    {
                        Respuesta.Mensaje += "Error fue: " + failure.ErrorMessage + "-> ";
                    }
                }
            }
            else
            {
                Respuesta.Resultado = false;
                foreach (var failure in result.Errors)
                {
                    Respuesta.Mensaje += "Error fue: " + failure.ErrorMessage + "-> ";
                }
            }

            return Respuesta;
        }


    }
}