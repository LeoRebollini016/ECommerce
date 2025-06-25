using System.ComponentModel.DataAnnotations;

namespace APPLICATION.Dtos.Products;

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public float Price { get; set; }
}
