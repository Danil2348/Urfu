using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Service
{
    public interface IUserServices
    {
        Task<User> Authenticate(string username, string password);
    }
}
