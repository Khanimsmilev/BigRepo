using Domain.Abstraction;

namespace Domain.Entities;
public class CV : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public string CVUrl { get; set; } // cv saxlandigi url
    public string ExtractedText { get; set; } // AI analiz ucun metn
    public string AIAnalysis { get; set; } // AI tovsiyyesi

}

