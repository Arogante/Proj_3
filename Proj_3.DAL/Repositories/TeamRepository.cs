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

        public bool Create(Team entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Team Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Team> GetAll()
        {
            return _db.Teams.ToListAsync();
            throw new NotImplementedException();
        }

        public Team GetByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
