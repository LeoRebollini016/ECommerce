using APPLICATION.Common.Models;
using System.Text.Json;

namespace APPLICATION.Common.Exceptions;

public class CustomValidationException: Exception
{
    public CustomValidationException(List<CustomValidationModel> messages) : base(JsonSerializer.Serialize(messages)) { }
}
