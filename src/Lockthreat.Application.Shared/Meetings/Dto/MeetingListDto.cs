using Abp.DynamicEntityParameters;
using Lockthreat.Employee.Dto;
using Lockthreat.GRCPrograms.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Meetings.Dto
{
  public  class MeetingListDto 
    {
        public long Id { get; set; }
        public int? TenantId { get; set; }
        public string MeetingId { get; set; }
        public string MeetingTitle { get; set; }
        public string MeetingDescription { get; set; }
        public DateTime? MeetingStartDate { get; set; }
        public DateTime? MeetingEndDate { get; set; }
        public string MeetingVenue { get; set; }
        public string MeetingLocation { get; set; }
        public string City { get; set; }
        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }
        public string MeetingAgenda { get; set; }
        public long? EmployeeId { get; set; }
        public GetEmployeeForEditDto  Employee { get; set; }
        public string MinutesofMeeting { get; set; }
        public string MinutesofMeetingAttachedment { get; set; }  //stores Base 64 string
        public string MeetingConclusion { get; set; }
        public long? OrganizerId { get; set; }
        public GetEmployeeForEditDto  Organizer { get; set; }
        public int? MeetingTypeId { get; set; }
        public DynamicParameterValue MeetingType { get; set; }
        public int? MeetingClassificationId { get; set; }
        public DynamicParameterValue MeetingClassification { get; set; }
    }
}
