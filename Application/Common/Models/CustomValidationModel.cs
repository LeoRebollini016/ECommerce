namespace APPLICATION.Common.Models;

public class CustomValidationModel
{
    public string Property { get; set; } = string.Empty;
    public string[] Errors { get; set; }
}
