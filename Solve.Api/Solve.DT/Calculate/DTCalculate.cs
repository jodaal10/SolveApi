//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         objeto encargado de adminsitrar la información del 
//                  calculo en general
//####################################################################
namespace Solve.DT.Calculate
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DTCalculate
    {
        //Constructor instanciar la lista de elementos
        public DTCalculate() { ElementosDia = new List<DTElemento>();}
        //Dias que tiene que trabajar
        public int dias { get; set; }
        //info elementos
        public List<DTElemento> ElementosDia { get; set; }
    }
}
