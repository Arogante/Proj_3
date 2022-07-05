using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Team.Service.Interfaces;
using Domain.Entity;
using Proj_3.DAL.Interfaces;
using Domain.Response;
using Domain.Enum;

namespace Team.Service.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<IBaseResponse<IEnumerable<Domain.Entity.Team>>> GetTeams()
        {
            var baseResponse = new BaseResponse<IEnumerable<Domain.Entity.Team>>();
            try {
                var teams = await _teamRepository.GetAll();
                if (teams.Count == 0)
                {
                    baseResponse.Description = "Найдено 0 элементов";
                    baseResponse.StatusCode = StatusCode.OK;
                }
                baseResponse.Data = teams;
                baseResponse.StatusCode = StatusCode.OK;
                return baseResponse;
            }
            catch (Exception ex) {
                return new BaseResponse<IEnumerable<Domain.Entity.Team>>
                {
                    Description = $"[GetTeams]:{ex.Message}"
                };
            
            }
        
        }
        
    }
}
