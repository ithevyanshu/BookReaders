using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using Business_Layer.Interface;
using Data_Access_Layer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using NagarroReader.Logger;
using Shared;

namespace NagarroReader.Controllers
{
    public class EventController : Controller
    {
        private readonly NagarroReaderDbContext _dbContext;
        private readonly IFactory _factory;
        public EventController
        (
            IFactory factory ,
            NagarroReaderDbContext context
        )
        {
            _factory = factory;
            _dbContext = context;
        }

        [LogException]
        public IActionResult Index()
        {
            var facade = _factory.CreateFacade();
            var eventModels = facade.GetAllEvents();
            return View(eventModels);
        }

        [LogException]
        [Authorize]
        public IActionResult MyEvent()
        {
            var facade = _factory.CreateFacade();
            var eventModels = facade.GetMyEvents();
            return View(eventModels);
        }

        [Authorize]
        public IActionResult Invitation()
        {
            var facade = _factory.CreateFacade();
            var eventList = facade.GetInvitation();
            return View(eventList);
        }

        [Authorize]
        public IActionResult CreateEvent()
        {
            var facade = _factory.CreateFacade();
            var eventModel = facade.GetEvent();
            return View(eventModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult CreateEvent(Event model)
        {
            if (ModelState.IsValid)
            {
                var facade = _factory.CreateFacade();
                facade.CreateEvent(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult ViewEvent(int id)
        {
            var Uid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var role = _dbContext.EmailModel?.FirstOrDefault(x => x.Id == Uid)?.PhoneNumber;
            _dbContext.EventModels.Find(id).Role = role;
            _dbContext.SaveChanges();
            var facade = _factory.CreateFacade();
            var eventModel = facade.GetEvent(id);
            return View(eventModel);
        }
        [Authorize]
        public IActionResult EditEvent(int id)
        {
            var facade = _factory.CreateFacade();
            var eventModel = facade.GetEvent(id);
            return View(eventModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditEvent(Event eventModel)
        {
            if (ModelState.IsValid)
            {
                var facade = _factory.CreateFacade();
                facade.UpdateEvent(eventModel);
                return RedirectToAction("Index");
            }
            return View(eventModel);
        }
        [Authorize]
        public IActionResult DeleteEvent(int id)
        {
            var facade = _factory.CreateFacade();
            facade.DeleteEvent(id);
            return RedirectToAction("MyEvent","Event");
        }
        [Authorize]
        [HttpPost]
        public IActionResult Comment(int eventId, [FromForm] string commentAdded)
        {
            var facade = _factory.CreateFacade();
            facade.Comment(eventId,commentAdded);
            return RedirectToAction("ViewEvent", new{id=eventId});
        }
    }
}