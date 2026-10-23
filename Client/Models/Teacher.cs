using System;

namespace Client.Models;

public class Teacher : Person
{
  public string KnowledgeArea { get; set; } = string.Empty;

  public List<Course> ResponsibleCourses { get; set; } = [];

  public override string ToString()
  {
    return $"{base.ToString()}, Knowledge area: {KnowledgeArea}";
  }

}
