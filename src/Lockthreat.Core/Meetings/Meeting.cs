using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Meetings 
{
 public class Meeting : FullAuditedEntity<long>, IMayHaveTenant
    {
        public Meeting ()
        {
            SelectedMeetingAbsenteeUsers = new  List<MeetingAbsenteeUser>();
            SelectedMeetingAttendUsers = new List<MeetingAttendUser>();
        }
        public int? TenantId { get; set; }
        public string MeetingId { get; set; }
        public string MeetingTitle { get; set; }
        public string MeetingDescription { get; set; }
        public DateTime? MeetingStartDate { get; set; }
        public DateTime? MeetingEndDate { get; set; }     
        public long? MeetingvenueId  { get; set; }
        public string MeetingLocation { get; set; }
        public string City { get; set; }
        public int? CountryId { get; set; }
        public DynamicParameterValue Country  { get; set; }
        public string MeetingAgenda { get; set; }       
        public long? EmployeeId  { get; set; }
        public Employee Employee { get; set; } 
        public string  MinutesofMeeting { get; set; }
        public string MinutesofMeetingAttachedment { get; set; }  //stores Base 64 string
        public string MeetingConclusion { get; set; }
        public long? OrganizerId { get; set; }
        public Employee Organizer  { get; set; }
        public int? MeetingTypeId { get; set; }
        public DynamicParameterValue MeetingType { get; set; }
        public int? MeetingClassificationId { get; set; }
        public DynamicParameterValue MeetingClassification  { get; set; }
        public ICollection<MeetingAbsenteeUser> SelectedMeetingAbsenteeUsers  { get; set; }
        public ICollection<MeetingAttendUser> SelectedMeetingAttendUsers  { get; set; }

    }
}
