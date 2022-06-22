using System;
using System.Collections.Generic;

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
        public int? Phone { get; set; }

        public virtual ICollection<TblPet> TblPets { get; set; }
    }
}
