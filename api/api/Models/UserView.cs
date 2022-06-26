using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace api.Models
{
public class UserView
{    
    public UserView()
    {
        
    }
    public int Ownerid { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public Boolean Admin { get; set; }

    
}
}