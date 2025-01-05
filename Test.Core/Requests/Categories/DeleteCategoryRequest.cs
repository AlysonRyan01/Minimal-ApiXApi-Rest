using System.ComponentModel.DataAnnotations;

namespace Test.Core.Requests.Categories;

public class DeleteCategoryRequest : BaseRequest
{
    [Required(ErrorMessage = "CategoryId is required")]
    public long Id { get; set; }
}