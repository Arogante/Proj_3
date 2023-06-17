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
    public class TeamRepository : IBaseRepository<Domain.Entity.Team>
    {
        private readonly AppDbContext _db;

        public TeamRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Create(Team entity)
        {
            await _db.Teams.AddAsync(entity);
            _db.SaveChangesAsync();
        }

        public async Task Delete(Team entity)
        {

            _db.Teams.Remove(entity);
            _db.SaveChangesAsync();

        }

        public async Task<Team> Get(int id)
        {
            return await _db.Teams.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Team> GetAll()
        {
            return _db.Teams;
        }

        public async Task<Team> GetByName(string name)
        {
            return await _db.Teams.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<Team> Update(Team entity)
        {
            _db.Teams.Update(entity);
            _db.SaveChangesAsync();
            return entity;
        }
    }
}
