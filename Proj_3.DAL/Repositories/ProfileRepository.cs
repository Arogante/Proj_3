﻿using Domain.Entity;
using Proj_3.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_3.DAL.Repositories
{
    public class ProfileRepository : IBaseRepository<Profile>
    {
        private readonly AppDbContext _dbContext;

        public ProfileRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Create(Profile entity)
        {
            await _dbContext.Profiles.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<Profile> GetAll()
        {
            return _dbContext.Profiles;
        }

        public async Task Delete(Profile entity)
        {
            _dbContext.Profiles.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Profile> Update(Profile entity)
        {
            _dbContext.Profiles.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}
