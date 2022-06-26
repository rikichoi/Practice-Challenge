using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Models
{
    public partial class TblOwner
    {
        public TblOwner()
        {
            TblPets = new HashSet<TblPet>();
        }
        public int Ownerid { get; set; }
        public string? Surname { get; set; }
        public string? Firstname { get; set; }
        public string? Phone { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool? Admin { get; set; }
        [JsonIgnore]
        public virtual ICollection<TblPet> TblPets { get; set; }
    }
}
