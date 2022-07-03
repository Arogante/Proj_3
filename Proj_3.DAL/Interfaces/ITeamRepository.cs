using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Proj_3.DAL.Interfaces
{
    public interface ITeamRepository:IBaseRepository<Team>
    {
        Task<Team> GetByName(string name);
    }
}
