using Domain.Abstraction;

namespace Domain.Entities;

public class JobPost : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string SalaryRange { get; set; }
    public string RequiredSkills { get; set; } // AI ile analiz ucun lazim olacaq
    public int EmployerId { get; set; }
    public User Employer { get; set; }

}
