namespace CryptoTracker.Domain.Entities
{
    public class Asset
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Symbol { get; set; }

        public decimal CurrentPrice { get; set; }

        public DateTime LastUpdated { get; set; } 
    }
}
