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
    public class DTCalculateValidator: AbstractValidator<DTCalculate>
    {
        public DTCalculateValidator() {
            RuleFor(DTCalculate => DTCalculate.dias).NotEmpty().WithMessage("Número de días es obligatorio");
            RuleFor(DTCalculate => DTCalculate.dias).InclusiveBetween(1, 500).WithMessage("Número de días debe estar entre 1 y 500");
            RuleFor(DTCalculate => DTCalculate.ElementosDia).NotNull().WithMessage("Los elementos de los días son boligatorios");
            RuleForEach(DTCalculate => DTCalculate.ElementosDia).SetValidator(new DTElementoValidator());
        }
    }
}
