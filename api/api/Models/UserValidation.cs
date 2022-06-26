using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Models
{
public class UserValidation
{    
    public UserValidation()
    {
        
    }
    public Boolean UserValid { get; set; }
    public Boolean AdminStatus { get; set; }

    public int OwnerID { get; set; }
    
}
}