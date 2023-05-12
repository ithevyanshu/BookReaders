using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business_Layer.Interface;
using Data_Access_Layer.Interface;
using Shared;

namespace Business_Layer.Implemenation
{
    public class Repository : IRepository
    {
        private readonly IUnitofWork _unitOfWork;

        public Repository(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Event GetEvent()
        {
            var userId = _unitOfWork.GetId();
            var viewModel = new Event
            {
                UserId = userId
            };
            return viewModel;
        }
        public Event GetEvent(int id)
        {
            Event eventModel = _unitOfWork.Get(id);
            return eventModel;
        }
        public List<Event> GetAllEvents
        {
            get
            {
                List<Event> eventModels = _unitOfWork.GetAll().OrderBy(x => x.Date).ToList();
                return eventModels;
            }
        }
        public List<Event> GetMyEvents
        {
            get
            {
                var id = _unitOfWork.GetId();
                List<Event> eventModels = _unitOfWork.GetAll().Where(x => x.UserId == id).OrderBy(x => x.Date).ToList();
                return eventModels;
            }
        }
        public void CreateEvent(Event eventModel)
        {
            _unitOfWork.Create(eventModel);
            _unitOfWork.Save();
        }
        public void UpdateEvent(Event eventModel)
        {
            var dbEventModel = _unitOfWork.Get(eventModel.EventId);
            dbEventModel.Title = eventModel.Title;
            dbEventModel.Date = eventModel.Date;
            dbEventModel.Location = eventModel.Location;
            dbEventModel.StartTime = eventModel.StartTime;
            dbEventModel.Duration = eventModel.Duration;
            dbEventModel.Description = eventModel.Description;
            dbEventModel.OtherDetails = eventModel.OtherDetails;
            dbEventModel.Type = eventModel.Type;
            dbEventModel.InviteByEmail = eventModel.InviteByEmail;
            _unitOfWork.Update(dbEventModel);
            _unitOfWork.Save();
        }
        public List<Event> GetInvitation
        {
            get
            {
                var invitation = _unitOfWork.GetAll().ToList();
                var id = _unitOfWork.GetId();
                var userEmail = _unitOfWork.GetEmail()?.FirstOrDefault(x => x.Id == id)?.Email;
                var eventList = new List<Event>();
                foreach (var invite in invitation)
                {
                    if (!string.IsNullOrWhiteSpace(invite.InviteByEmail) && invite.InviteByEmail.Contains(userEmail))
                    {
                        eventList.Add(invite);
                    }
                }

                return eventList;
            }
        }
        public void DeleteEvent(int id)
        {
            _unitOfWork.Delete(id);
            _unitOfWork.Save();
        }

        public void Comment(int id, string commentAdded)
        {
            var @event = GetEvent(id);
            var timeStamp = DateTime.Now.ToString("dd-MM-yyyy   HH:mm");

            if (@event.CommentAdded == null)
            {
                @event.CommentAdded = commentAdded;
                @event.CommentAdded += $"+ {timeStamp}";
            }
            else
            {
                @event.CommentAdded += $", {commentAdded}";
                @event.CommentAdded += $"+ {timeStamp}";
            }
            _unitOfWork.Update(@event);
            _unitOfWork.Save();
        }
    }
}
