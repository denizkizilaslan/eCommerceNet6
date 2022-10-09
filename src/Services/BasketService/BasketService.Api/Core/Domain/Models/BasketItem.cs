using System.ComponentModel.DataAnnotations;

namespace BasketService.Api.Core.Domain.Models
{
    public class BasketItem : IValidatableObject
    {
        public string Id { get; init; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string PictureUrl { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (Quantity < 1)
                results.Add(new ValidationResult("Geçersiz Miktar", new[] { "Quantity" }));

            if (Price <= 0)
                results.Add(new ValidationResult("Geçersiz Birim Fiyat", new[] { "Price" }));

            return results;
        }
    }
}
