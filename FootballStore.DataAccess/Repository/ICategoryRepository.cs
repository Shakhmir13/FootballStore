﻿using FootballStore.DataAccess.ViewModels;
using FootballStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballStore.DataAccess.Repository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
