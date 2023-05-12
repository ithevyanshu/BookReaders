using Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Layer.Interface
{
    public interface IFacade
    {
        Event GetEvent();
        Event GetEvent(int id);
        List<Event> GetAllEvents();
        List<Event> GetMyEvents();
        void CreateEvent(Event eventModel);
        void UpdateEvent(Event eventModel);
        void DeleteEvent(int id);
        void Comment(int id, string text);
        List<Event> GetInvitation();
    }
}
