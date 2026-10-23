using System;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class WestcoastServices
{
  private readonly List<Course> _courses = [];
  private readonly List<Student> _students = [];
  private readonly List<Teacher> _teachers = [];
  private readonly List<EducationManager> _educationManagers = [];
  private readonly List<Administrator> _administrators = [];

  private readonly ICourseStorage _storage = new StorageService();

  public void Add(Course course)
  {
    if (string.IsNullOrWhiteSpace(course.CourseNumber))
    {
      Console.WriteLine("Course number cannot be empty.");
      return;
    }

    if (_courses.Any(c => c.CourseNumber == course.CourseNumber))
    {
      Console.WriteLine("A course with that course number aleady exists!");
      return;
    }
    _courses.Add(course);
    Console.WriteLine("Course added.");
  }

  public void SaveCourses()
  {
    _storage.SaveCourses(_courses);
    Console.WriteLine("Courses saved.");
  }

  public void LoadCourses()
  {
    var loadedCourses = _storage.LoadCourses();

    _courses.Clear();
    _courses.AddRange(loadedCourses);

    Console.WriteLine("Courses loaded.");
  }

  public void Add(Student student)
  {
    if (string.IsNullOrWhiteSpace(student.PersonalNumber))
    {
      Console.WriteLine("Personal number cannot be empty.");
      return;
    }

    if (_students.Any(s => s.PersonalNumber == student.PersonalNumber))
    {
      Console.WriteLine("A student with that personal number already exists.");
      return;
    }

    _students.Add(student);
    Console.WriteLine("Student added.");
  }

  public void Add(Teacher teacher)
  {
    _teachers.Add(teacher);
  }

  public void Add(EducationManager educationManager)
  {
    _educationManagers.Add(educationManager);
  }

  public void Add(Administrator administrator)
  {
    _administrators.Add(administrator);
  }

  public void ListCourses()
  {
    foreach (var course in _courses)
    {
      Console.WriteLine(course);
    }
  }

  public void ListStudents()
  {
    foreach (var student in _students)
    {
      Console.WriteLine(student);
    }
  }

}
