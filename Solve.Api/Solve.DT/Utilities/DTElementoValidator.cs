//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         Fluent validation class for DTCalculate
//####################################################################
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Solve.DT.Calculate;

namespace Solve.DT.Utilities
{
    public class DTElementoValidator: AbstractValidator<DTElemento>
    {

        public DTElementoValidator() {
            RuleFor(DTElemento => DTElemento.cantidadElementos).NotEmpty().WithMessage("Número de elementos a cargar por día es obligatorio");
            RuleFor(DTElemento => DTElemento.cantidadElementos).InclusiveBetween(1, 100).WithMessage("Número de elementos a cargar por día debe estar entre 1 y 100");
            RuleForEach(DTElemento => DTElemento.pesos).NotNull().WithMessage("El peso {CollectionIndex} de los elementos es obligatorio");
            RuleForEach(DTElemento => DTElemento.pesos).InclusiveBetween(1,100).WithMessage("El peso {CollectionIndex} de los elementos debe estar entre 1 y 100");
        }

    }
}
