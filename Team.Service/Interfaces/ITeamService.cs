using Domain.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Team.Service.Interfaces
{
    public interface ITeamService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Team>>> GetTeams();
    }
}
