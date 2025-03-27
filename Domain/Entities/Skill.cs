using Domain.Abstraction;

namespace Domain.Entities;

public class Skill  : BaseEntity
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public int ProficiencyLevel { get; set; } // 1 - 5 arası

    public User User { get; set; }
}

