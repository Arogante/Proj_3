using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Proj_3.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_3.DAL.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly AppDbContext _db;

        public TeamRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Team entity)
        {
            await _db.Teams.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(Team entity)
        {

            _db.Teams.Remove(entity);
            return true;
        }

        public async Task<Team> Get(int id)
        {
            return await _db.Teams.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Team>> GetAll()
        {
            return  await _db.Teams.ToListAsync();//throw new NotImplementedException();
        }

        public async Task<Team> GetByName(string name)
        {
            return await _db.Teams.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}
