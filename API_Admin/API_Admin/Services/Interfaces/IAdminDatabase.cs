using DataAccesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Admin.Services.Interfaces
{
    public interface IAdminDatabase
    {
        public Task<IList<Fan>> GetFans();
        public Task<IList<Creator>> GetCreators();
        public Task<bool> DeleteCreatorByName(string name);
        public Task<bool> DeleteFanByName(string name);
        public Task<bool> DeletePostById(long id);
    }
}
