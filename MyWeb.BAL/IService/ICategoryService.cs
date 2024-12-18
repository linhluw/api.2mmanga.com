﻿using MyWeb.DAL.Models;

namespace MyWeb.BAL.Service
{
    public interface ICategoryService : IBaseService<Category>
    {
        Category GetByName(string name);
    }
}