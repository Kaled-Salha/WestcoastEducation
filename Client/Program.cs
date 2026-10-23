using Client.Enums;
using Client.Models;
using Client.Services;

var westcoastServices = new WestcoastServices();

Console.WriteLine("---------------------------");
Console.WriteLine("--- Westcoast Education ---");
Console.WriteLine("---------------------------");
Console.WriteLine("1. Add course");
Console.WriteLine("2. List courses");
Console.WriteLine("3. Save courses");
Console.WriteLine("4. Load courses");
Console.WriteLine("5. Add student");
Console.WriteLine("6. List students");
Console.WriteLine("7. Add teacher");
Console.WriteLine("8. Add education manager");
Console.WriteLine("9. Add administrator");
Console.WriteLine("0. Exit");

while (true)
{
  Console.Write("Choose an option: ");
  var key = Console.ReadLine();

  if (string.IsNullOrWhiteSpace(key))
  {
    Console.WriteLine("You need to choose an option.");
    continue;
  }

  switch (key)
  {
    case "1":
      AddCourse();
      break;

    case "2":
      westcoastServices.ListCourses();
      break;

    case "3":
      westcoastServices.SaveCourses();
      break;

    case "4":
      westcoastServices.LoadCourses();
      break;

    case "5":
      AddStudent();
      break;

    case "6":
      westcoastServices.ListStudents();
      break;

    case "7":
      AddTeacher();
      break;

    case "8":
      AddEducationManager();
      break;

    case "9":
      AddAdministrator();
      break;

    case "0":
      Environment.Exit(0);
      break;

    default:
      Console.WriteLine("Invalid option.");
      break;
  }
}


void AddCourse()
{
  Console.Write("Course number: ");
  var courseNumber = Console.ReadLine();

  Console.Write("Course name: ");
  var courseName = Console.ReadLine();

  Console.Write("Duration in weeks: ");
  var durationInput = Console.ReadLine();

  Console.Write("Start date (yyyy-mm-dd): ");
  var startDateInput = Console.ReadLine();

  Console.Write("End date (yyyy-mm-dd): ");
  var endDateInput = Console.ReadLine();

  Console.Write("Course type (1 = Classroom, 2 = Distance): ");
  var courseTypeInput = Console.ReadLine();

  if (string.IsNullOrWhiteSpace(courseNumber) ||
      string.IsNullOrWhiteSpace(courseName))
  {
    Console.WriteLine("Course number and name are required.");
    return;
  }

  if (!int.TryParse(durationInput, out int duration))
  {
    Console.WriteLine("Duration must be a number.");
    return;
  }

  if (!DateTime.TryParse(startDateInput, out DateTime startDate) ||
      !DateTime.TryParse(endDateInput, out DateTime endDate))
  {
    Console.WriteLine("Invalid date.");
    return;
  }

  if (courseTypeInput != "1" && courseTypeInput != "2")
  {
    Console.WriteLine("Invalid course type.");
    return;
  }

  var course = new Course
  {
    CourseNumber = courseNumber,
    CourseName = courseName,
    DurationInWeeks = duration,
    StartDate = startDate,
    EndDate = endDate,
    CourseType = courseTypeInput == "2"
      ? CourseTypeEnum.Distance
      : CourseTypeEnum.Classroom
  };

  westcoastServices.Add(course);
}


void AddStudent()
{
  var student = new Student();

  AddPersonInfo(student);

  if (string.IsNullOrWhiteSpace(student.FirstName) ||
      string.IsNullOrWhiteSpace(student.LastName) ||
      string.IsNullOrWhiteSpace(student.PersonalNumber))
  {
    Console.WriteLine("First name, last name and personal number are required.");
    return;
  }

  westcoastServices.Add(student);
}


void AddTeacher()
{
  var teacher = new Teacher();

  AddTeacherInfo(teacher);

  westcoastServices.Add(teacher);
}


void AddEducationManager()
{
  var educationManager = new EducationManager();

  if (!AddEducationManagerInfo(educationManager))
  {
    return;
  }

  westcoastServices.Add(educationManager);
}


void AddAdministrator()
{
  var administrator = new Administrator();

  if (!AddEducationManagerInfo(administrator))
  {
    return;
  }

  westcoastServices.Add(administrator);
}


void AddPersonInfo(Person person)
{
  Console.Write("First name: ");
  person.FirstName = Console.ReadLine() ?? "";

  Console.Write("Last name: ");
  person.LastName = Console.ReadLine() ?? "";

  Console.Write("Phone: ");
  person.Phone = Console.ReadLine() ?? "";

  Console.Write("Personal number: ");
  person.PersonalNumber = Console.ReadLine() ?? "";

  Console.Write("Street: ");
  var street = Console.ReadLine();

  Console.Write("Postal code: ");
  var postalCode = Console.ReadLine();

  Console.Write("City: ");
  var city = Console.ReadLine();

  person.Address = new Address
  {
    Street = street ?? "",
    PostalCode = postalCode ?? "",
    City = city ?? ""
  };
}


void AddTeacherInfo(Teacher teacher)
{
  AddPersonInfo(teacher);

  Console.Write("Knowledge area: ");
  teacher.KnowledgeArea = Console.ReadLine() ?? "";
}


bool AddEducationManagerInfo(EducationManager educationManager)
{
  AddTeacherInfo(educationManager);

  Console.Write("Employment date (yyyy-mm-dd): ");
  var employmentDateInput = Console.ReadLine();

  if (!DateTime.TryParse(employmentDateInput, out DateTime employmentDate))
  {
    Console.WriteLine("Invalid employment date.");
    return false;
  }

  educationManager.EmploymentDate = employmentDate;

  return true;
}