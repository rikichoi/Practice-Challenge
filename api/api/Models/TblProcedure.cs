using System;
using System.Collections.Generic;

namespace api.Models
{
    public partial class TblProcedure
    {
        public TblProcedure()
        {
            TblTreatments = new HashSet<TblTreatment>();
        }

        public int Procedureid { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<TblTreatment> TblTreatments { get; set; }
    }
}
