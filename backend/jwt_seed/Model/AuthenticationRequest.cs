using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ORM_Projekt.jwt_seed.Model
{
    public class AuthenticationRequest
    {
        public AuthenticationRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
        [Required]
        public string Username
        {
            get; set;
        }
        [Required]
        public string Password
        {
            get; set;
        }
    }
}
