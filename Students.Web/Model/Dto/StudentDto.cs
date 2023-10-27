using System.Text.Json.Serialization;

namespace Students.Web.Model.Dto;

public class StudentDto
{
    [JsonPropertyName("id")] public int Id { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; } = null!;
    [JsonPropertyName("email")] public string Email { get; set; } = null!;
}