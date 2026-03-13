using CryptoTracker.Domain.Enums;

namespace CryptoTracker.Domain.Entities
{
    public class Alert
    {
        public Guid Id { get; set; }
        
        public decimal TargetPrice { get; set; }

        public AlertDirection Direction { get; set; }

        public AlertStatus Status { get; set; }

        public DateTime CreatedAt{ get; set; }

        public Guid UserId { get; set; }

        public Guid AssetId { get; set; }
    }
}
