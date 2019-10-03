//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         objeto encargado de administrar la información 
//                  de cantidad de objetos y pesos
//####################################################################
namespace Solve.DT.Calculate
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DTElemento
    {
        //cantidad de elementos dia
        public int cantidadElementos { get; set; }
        //peso elementos
        public List<int> pesos { get; set; }
    }
}
