using Domain.Abstraction;

namespace Domain.Entities;
public class CV : BaseEntity
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }

    public string CVUrl { get; set; } // CV faylının harada saxlandığı
    public string ExtractedText { get; set; } // AI analiz üçün mətn
    public string AIAnalysis { get; set; } // AI tövsiyələri
    //public DateTime UploadedAt { get; set; }
}

