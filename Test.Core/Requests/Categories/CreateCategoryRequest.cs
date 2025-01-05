using System.ComponentModel.DataAnnotations;

namespace Test.Core.Requests.Categories;

public class CreateCategoryRequest : BaseRequest
{
    [Required(ErrorMessage = "Title is required")]
    [MaxLength(50, ErrorMessage = "Title length cannot be more than 50 characters")]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(280, ErrorMessage = "Description length cannot be more than 280 characters")]
    public string Description { get; set; } = string.Empty;
}