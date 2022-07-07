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
using Domain.ViewModel.Team;

namespace Team.Service.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<IBaseResponse<Domain.Entity.Team>> GetTeam(int id)
        {
            var baseResponse = new BaseResponse<Domain.Entity.Team>();
            try
            {
                var team = await _teamRepository.Get(id);
                if (team == null)
                {
                    baseResponse.Description = "Команда не найдена";
                    baseResponse.StatusCode = StatusCode.TeamNotFound;
                    return baseResponse;
                }
                baseResponse.Data = team;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Domain.Entity.Team>
                {
                    Description = $"[GetTeam]:{ex.Message}"
                };

            }

        }
        public async Task<IBaseResponse<IEnumerable<Domain.Entity.Team>>> GetTeams()
        {
            var baseResponse = new BaseResponse<IEnumerable<Domain.Entity.Team>>();
            try
            {
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
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<Domain.Entity.Team>>
                {
                    Description = $"[GetTeams]:{ex.Message}"
                };

            }

        }
        public async Task<IBaseResponse<Domain.Entity.Team>> GetTeamByName(string name)
        {
            var baseResponse = new BaseResponse<Domain.Entity.Team>();
            try
            {
                var team = await _teamRepository.GetByName(name);
                if (team == null)
                {
                    baseResponse.Description = "Команда не найдена";
                    baseResponse.StatusCode = StatusCode.TeamNotFound;
                    return baseResponse;
                }
                baseResponse.Data = team;
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<Domain.Entity.Team>
                {
                    Description = $"[GetTeamByName]:{ex.Message}"
                };

            }

        }
        public async Task<IBaseResponse<bool>> DeleteTeam(int id)
        {
            var baseResponse = new BaseResponse<bool>();
            try
            {
                var team = await _teamRepository.Get(id);
                if (team == null)
                {
                    baseResponse.Description = "Команда не найдена";
                    baseResponse.StatusCode = StatusCode.TeamNotFound;
                    return baseResponse;
                }
                baseResponse.Data = await _teamRepository.Delete(team);
                return baseResponse;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    Description = $"[DeleteTeam]:{ex.Message}"
                };
            }
        }
        public async Task<IBaseResponse<TeamViewModel>> CreateTeam(TeamViewModel teamViewModel)
        {
            var baseResponse = new BaseResponse<TeamViewModel>();
            try
            {
                var team = new Domain.Entity.Team()
                {
                    Description = teamViewModel.Description,
                    CreationTime = DateTime.Now,
                    Name = teamViewModel.Name,
                    FinishedTasks = teamViewModel.FinishedTasks,
                    Points = teamViewModel.Points
                };
                await _teamRepository.Create(team);
            }
            catch (Exception ex)
            {
                return new BaseResponse<TeamViewModel>
                {
                    Description = $"[CreateTeam]:{ex.Message}"
                };
            }
            baseResponse.Data = teamViewModel;
             return baseResponse;
        }

        public async Task<IBaseResponse<Domain.Entity.Team>> EditTeam(int id, TeamViewModel model)
        {
            var baseResponse = new BaseResponse<Domain.Entity.Team>();
            try
            {
               var team=await _teamRepository.Get(id);
                if (team == null) {
                    baseResponse.StatusCode = StatusCode.TeamNotFound;
                    baseResponse.Description = "team not found";
                    return baseResponse;
                }
                team.Id = model.Id;
                team.Name = model.Name;
                team.Description = model.Description;
                team.CreationTime = model.CreationTime;
                team.FinishedTasks = model.FinishedTasks;
                team.Points = model.Points;
                _teamRepository.Update(team);
            }
            catch (Exception ex)
            {
                return new BaseResponse<Domain.Entity.Team>
                {
                    Description = $"[Edit]:{ex.Message}"
                };
            }
            //baseResponse.Data = teamViewModel;
            return baseResponse;
        }
    }
}
