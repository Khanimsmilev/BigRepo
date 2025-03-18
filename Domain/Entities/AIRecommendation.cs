using Domain.Abstraction;

namespace Domain.Entities;

public class AIRecommendation : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public string RecommendationText { get; set; } // AI-nin verdiyi tövsiyə
    public string RecommendationType { get; set; } // "Job", "Connection", "Skill Improvement" və s.
    //public DateTime CreatedAt { get; set; }
}
