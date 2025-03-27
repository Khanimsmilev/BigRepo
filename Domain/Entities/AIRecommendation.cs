using Domain.Abstraction;

namespace Domain.Entities;

public class AIRecommendation : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public string RecommendationText { get; set; } //AI verdiyi tovsiyye
    public string RecommendationType { get; set; } // job, connection, skill improvement ...

}
