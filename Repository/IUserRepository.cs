using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Urfu.Models;

namespace Urfu.Repository
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
    }
}
