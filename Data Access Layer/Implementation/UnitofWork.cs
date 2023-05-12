using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Data_Access_Layer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Extensions.Logging;

namespace Data_Access_Layer.Implementation
{
    public class UnitofWork : IUnitofWork
    {
        public readonly NagarroReaderDbContext _context;
        public readonly IHttpContextAccessor _httpContextAccessor;

        public UnitofWork(NagarroReaderDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return userId;
        }
        public Event Get(int id)
        {
            return _context.EventModels.Find(id);
        }
        public DbSet<Event> GetAll()
        {
            return _context.EventModels;
        }
        public DbSet<IdentityUser> GetEmail() { return _context.EmailModel; }
        public void Create(Event model)
        {
            _context.EventModels.Add(model);
        }
        public void Update(Event model)
        {
            _context.EventModels.Update(model);
        }
        public void Delete(int id)
        {
            _context.EventModels.Remove(Get(id));
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
