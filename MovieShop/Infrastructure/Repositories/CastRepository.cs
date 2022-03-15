﻿using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CastRepository: EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Cast> GetById(int id)
        {
            //we need to use Include method

            //include navigation property
            var castDetails = await _dbContext.Casts.Include(c => c.MovieCasts).ThenInclude(c => c.Movie)
                .FirstOrDefaultAsync(c => c.Id == id);
            return castDetails;
        }

    }
}
