using System.ComponentModel.DataAnnotations;

namespace Test.Core.Requests.Products;

public class CreateProductRequest : BaseRequest
{
    [Required(ErrorMessage = "Product title is required")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Price is required")]
    public Decimal Price { get; set; }
}