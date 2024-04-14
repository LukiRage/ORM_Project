using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using IntegracjaSystemow8.Entities;
//using IntegracjaSystemow8.Model;
using ORM_Projekt.jwt_seed;
using ORM_Projekt.jwt_seed.Model;
using ORM_Projekt.jwt_seed.Entities;

namespace ORM_Projekt.jwt_seed.Services.Users
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest request);
        IEnumerable<User> GetUsers();
        User GetByUsername(string username);
        User GetById(int id);
        int GetUserCount();
    }
}
