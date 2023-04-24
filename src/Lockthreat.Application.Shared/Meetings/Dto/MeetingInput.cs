using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Meetings.Dto
{
  public  class MeetingInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public long? MeetingId  { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "meetingId,meetingTitle,meetingDescription DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
