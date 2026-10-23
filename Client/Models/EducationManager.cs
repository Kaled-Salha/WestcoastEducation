using System;

namespace Client.Models;

public class EducationManager : Teacher
{
  public DateTime EmploymentDate { get; set; }

  public override string ToString()
  {
    return $"{base.ToString()}, Employment date: {EmploymentDate:yyyy-MM-dd}";
  }


}
