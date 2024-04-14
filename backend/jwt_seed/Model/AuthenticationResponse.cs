using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ORM_Projekt.jwt_seed.Entities;
//using IntegracjaSystemow8.Entities;

namespace ORM_Projekt.jwt_seed.Model
{
    public class AuthenticationResponse
    {
        public int Id
        {
            get; set;
        }
        public string Username
        {
            get; set;
        }
        public string Token
        {
            get; set;
        }
        public AuthenticationResponse()
        {

        }
        public AuthenticationResponse(User user, string token)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
        }
    }
}
