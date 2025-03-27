using Domain.Abstraction;

namespace Domain.Entities;

public class Education : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public string SchoolName { get; set; }
    public string Degree { get; set; }
    public string FieldOfStudy { get; set; }
    public DateTime StartYear { get; set; }
    public DateTime? EndYear { get; set; } // oxuyursa null olsun
}
