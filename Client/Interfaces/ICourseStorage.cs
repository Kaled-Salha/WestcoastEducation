using System;
using Client.Models;

namespace Client.Interfaces;

public interface ICourseStorage
{
  void SaveCourses(List<Course> courses);

  List<Course> LoadCourses();

}
