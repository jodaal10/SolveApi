//####################################################################
// Project:         Tech & Solve
// Author:          Jonathan Dávila A.
// DATA:            01/10/2019
// Comment:         interfaz encargada de invocar el positorio de data
//####################################################################
namespace Solve.DM.Calculate
{
    using Solve.DM.Database;
    using Solve.DM.Repository;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICalculateRepository: IBaseRepository<Auditoria>
    {
    }
}
