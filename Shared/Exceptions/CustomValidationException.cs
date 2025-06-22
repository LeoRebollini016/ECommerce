using Shared.Models;
using System.Text.Json;

namespace Shared.Exceptions;

public class CustomValidationException: Exception
{
    public CustomValidationException(List<CustomValidationModel> messages) : base(JsonSerializer.Serialize(messages)) { }
}
