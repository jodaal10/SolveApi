//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            02/10/2019
// Comment:         objeto encargado de administrar la información 
//                  de respuesta
//####################################################################
namespace Solve.DT.Calculate
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DTRespuesta
    {
        public bool Resultado { get; set; }
        public string Mensaje { get; set; }
        public List<string> Case { get; set;}
    }
}
