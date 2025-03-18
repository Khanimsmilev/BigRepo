using Domain.Abstraction;

namespace Domain.Entities;

public class JobPost : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string SalaryRange { get; set; }
    public string RequiredSkills { get; set; } // AI ilə analiz üçün
    public int EmployerId { get; set; }
    public User Employer { get; set; } // İstifadəçi ilə əlaqə


    //public DateTime PostedAt { get; set; }
}
