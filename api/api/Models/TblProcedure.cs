using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        [JsonIgnore]

        public virtual ICollection<TblTreatment> TblTreatments { get; set; }
    }
}
