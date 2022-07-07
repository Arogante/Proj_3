using Domain.Response;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ViewModel.Team;

namespace Team.Service.Interfaces
{
    public interface ITeamService
    {
        Task<IBaseResponse<IEnumerable<Domain.Entity.Team>>> GetTeams();
        Task<IBaseResponse<Domain.Entity.Team>> GetTeam(int id);
        Task<IBaseResponse<TeamViewModel>> CreateTeam(TeamViewModel teamViewModel);
        Task<IBaseResponse<bool>> DeleteTeam(int id);
        Task<IBaseResponse<Domain.Entity.Team>> GetTeamByName(string name);
        Task<IBaseResponse<Domain.Entity.Team>> EditTeam(int id, TeamViewModel model);

    }
}
