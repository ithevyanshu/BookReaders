using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Interface
{
    public interface IRepository
    {
        public Event GetEvent();
        public Event GetEvent(int id);
        public List<Event> GetMyEvents { get; }
        public List<Event> GetAllEvents { get; }
        public void CreateEvent(Event eventModel);
        public void UpdateEvent(Event eventModel);
        public void DeleteEvent(int id);
        public void Comment(int id, string commentAdded);
        public List<Event> GetInvitation { get; }
    }
}
