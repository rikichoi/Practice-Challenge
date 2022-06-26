using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Models
{
    public partial class TblPet
    {
        public TblPet()
        {
            TblTreatments = new HashSet<TblTreatment>();
        }
        public int Ownerid { get; set; }
        public string Petname { get; set; } = null!;
        public string? Type { get; set; }

        [JsonIgnore]
        public virtual ICollection<TblTreatment> TblTreatments { get; set; }
    }
}
