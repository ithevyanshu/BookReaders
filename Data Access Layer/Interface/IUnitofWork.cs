using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Interface
{
    public interface IUnitofWork
    {
        string GetId();
        Event Get(int id);
        DbSet<Event> GetAll();
        DbSet<IdentityUser> GetEmail();
        void Create(Event model);
        void Update(Event model);
        void Delete(int id);
        void Save();
    }
}
