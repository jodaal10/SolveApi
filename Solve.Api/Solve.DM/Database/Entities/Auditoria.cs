using System;
using System.Collections.Generic;

namespace Solve.DM.Database
{
    public partial class Auditoria
    {
        public int IdAuditoria { get; set; }
        public string Ejecutor { get; set; }
        public DateTime? FechaEjecucion { get; set; }
    }
}
