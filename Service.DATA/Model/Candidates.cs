using System;

namespace Service.DATA.Model
{
    public class Candidates
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Locations { get; set; }
        public string? EducationInfo { get; set; }
        public string? SpouseEducationInfo { get; set; }
        public string? WorkingActivity { get; set; }
        public DateTime ResponseDate { get; set; }
    }
}
