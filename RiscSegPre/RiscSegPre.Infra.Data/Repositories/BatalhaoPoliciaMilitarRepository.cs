﻿using RiscSegPre.Domain.Entities;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;

namespace RiscSegPre.Infra.Data.Repositories
{
    public class BatalhaoPoliciaMilitarRepository
        : BaseRepository<BatalhaoPoliciaMilitar>, IBatalhaoPoliciaMilitarRepository
    {
        private readonly DataContext context;

        public BatalhaoPoliciaMilitarRepository(DataContext context)
            : base(context)
        {
            this.context = context;
        }
    }
}