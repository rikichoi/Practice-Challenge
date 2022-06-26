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

        public string Petname { get; set; } = null!;
        public int Ownerid { get; set; }
        public string? Type { get; set; }
        public virtual TblOwner Owner { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<TblTreatment> TblTreatments { get; set; }
    }
}
