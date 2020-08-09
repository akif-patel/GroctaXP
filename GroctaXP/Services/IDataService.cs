using GroctaXP.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GroctaXP.Services
{
    interface IDataService
    {
        Task AddUser(User user);
    }
}
