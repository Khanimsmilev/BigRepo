using Domain.Abstraction;

namespace Domain.Entities
{
    public class WorkExperience : BaseEntity
    {

        public int UserId { get; set; }
        public User User { get; set; }

        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // hele isleyirse null olmalidir
        public string Description { get; set; }
    }
}
