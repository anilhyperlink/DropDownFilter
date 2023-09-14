
namespace DropDownFilter.Models
{
    public class DropDownModel
    {
        public bool HasPhoto { get; set; }
        public int? AccountWithinDays { get; set; }
        public int? NotAccountWithinDays { get; set; }
        public string EmailContains { get; set; }
        public string EmailNotContains { get; set; }
        public string FirstNameContains { get; set; }
        public string FirstNameNotContains { get; set; }
        public string LastNameContains { get; set; }
        public string LastNameNotContains { get; set; }
        public int? PageNumber { get; set; }
    }
}
