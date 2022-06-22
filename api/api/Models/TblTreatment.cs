using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class TblTreatment
    {
        public int Ownerid { get; set; }
        public string Petname { get; set; } = null!;
        public int Procedureid { get; set; }
        public DateTime Date { get; set; }
        public string? Notes { get; set; }
        public string? Payment { get; set; }

        public virtual TblProcedure Procedure { get; set; } = null!;
        public virtual TblPet TblPet { get; set; } = null!;
    }
}
