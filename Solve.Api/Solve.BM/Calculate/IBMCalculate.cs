//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         interfaz encargada de exponer la capa de negocio
//####################################################################
namespace Solve.BM.Calculate
{
    using Solve.DM.Database;
    using Solve.DT.Calculate;
    using System;
    using System.Collections.Generic;
    using System.Text;


    public interface IBMCalculate
    {
        bool CrearAuditoria(DTViajeUsuario ObjElement);
        DTCalculate infoTextToStructur(DTViajeUsuario objinfo);
        DTRespuesta CalculateCase(DTCalculate ObjCalculate);
    }
}
