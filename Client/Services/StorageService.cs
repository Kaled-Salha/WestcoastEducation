using System;
using System.Text.Json;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class StorageService : ICourseStorage
{
  private readonly string _filePath = "courses.json";
  public void SaveCourses(List<Course> courses)
  {
    string json = JsonSerializer.Serialize(courses, new JsonSerializerOptions
    {
      WriteIndented = true
    });

    File.WriteAllText(_filePath, json);
  }
  public List<Course> LoadCourses()
  {
    if (!File.Exists(_filePath))
    {
      return [];
    }

    string json = File.ReadAllText(_filePath);

    return JsonSerializer.Deserialize<List<Course>>(json) ?? [];
  }

}
