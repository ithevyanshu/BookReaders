using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Linq;

namespace Shared
{
    public class Event
    {
        public int EventId { get; set; }

        public string UserId { get; set; }

        public string Role { get; set; }

        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Date : ")]
        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Display(Name = "Location")]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Starts At : ")]
        [DataType(DataType.Time)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "Type of Event : ")]
        public string Type { get; set; }

        [Display(Name = "Duration (in hrs)")]
        [Range(0, 4)]
        public int? Duration { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        [Display(Name = "Other Details")]
        [MaxLength(500)]
        public string OtherDetails { get; set; }

        [Display(Name = "Invite Others")]
        public string InviteByEmail { get; set; }

        [Display(Name = "Comments")]
        public string CommentAdded { get; set; }
    }
}
