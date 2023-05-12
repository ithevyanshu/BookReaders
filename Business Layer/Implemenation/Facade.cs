using System;
using System.Collections.Generic;
using System.Text;
using Business_Layer.Interface;
using Shared;

namespace Business_Layer.Implemenation
{
    public class Facade : IFacade
    {
        private readonly IRepository _repo;

        public Facade(IRepository repo)
        {
            _repo = repo;
        }
        public Event GetEvent()
        {
            return _repo.GetEvent();
        }

        public Event GetEvent(int id)
        {
            return _repo.GetEvent(id);
        }

        public List<Event> GetAllEvents()
        {
            return _repo.GetAllEvents;
        }

        public List<Event> GetMyEvents()
        {
            return _repo.GetMyEvents;
        }

        public void CreateEvent(Event eventModel)
        {
            _repo.CreateEvent(eventModel);
        }

        public void UpdateEvent(Event eventModel)
        {
            _repo.UpdateEvent(eventModel);
        }
        public void DeleteEvent(int id)
        {
            _repo.DeleteEvent(id);
        }

        public void Comment(int id, string commentAdded)
        {
            _repo.Comment(id,commentAdded);
        }
        public List<Event> GetInvitation()
        {
            return _repo.GetInvitation;
        }
    }
}
