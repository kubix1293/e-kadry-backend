using System;

namespace EKadry.Application.Services.JobPositions.JobPositionList
{
    public class JobPositionListDto 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int GusCode { get; set; }
    }
}