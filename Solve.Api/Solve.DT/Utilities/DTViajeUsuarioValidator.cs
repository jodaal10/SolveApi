//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         Fluent validation class for DTViajeUsuario
//####################################################################
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Solve.DT.Calculate;


namespace Solve.DT.Utilities
{
    public class DTViajeUsuarioValidator : AbstractValidator<DTViajeUsuario>
    {
        public DTViajeUsuarioValidator() {
            RuleFor(DTViajeUsuario => DTViajeUsuario.usuario).NotNull().WithMessage("El campo usuario es obligatorio");
            RuleFor(DTViajeUsuario => DTViajeUsuario.usuario).NotEmpty().WithMessage("El campo usuario es obligatorio");
            RuleFor(DTViajeUsuario => DTViajeUsuario.info).NotNull().WithMessage("La información del archivo es obligatoria");
            RuleFor(DTViajeUsuario => DTViajeUsuario.info).NotEmpty().WithMessage("La información del archivo es obligatoria");
        }

    }
}
