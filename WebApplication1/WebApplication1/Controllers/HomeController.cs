using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private List<Employee> employees;
        private List<Vacation> vacations = new List<Vacation>();

        public HomeController()
        {

            employees = GenerateRandomEmployees(100);
            vacations = GenerateRandomVacations(employees);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Vacations()
        {
            
            List<Vacation> vacations = DataStorage.Vacations;
            ViewBag.Employees = new SelectList(DataStorage.Employees, "Id", "FullName");
            return View(vacations);
        }



        public ActionResult NewVacation()
        {
            ViewBag.Employees = new SelectList(DataStorage.Employees, "Id", "FullName");
            return View(new Vacation());
        }


        [HttpPost]

        public ActionResult NewVacation(int employeeId, DateTime startDate, DateTime endDate)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == employeeId);

            if (employee == null)
            {
                ModelState.AddModelError("employeeId", "Неверный сотрудник");
            }

            if (endDate < startDate)
            {
                ModelState.AddModelError("endDate", "Дата окончания должна быть после даты начала");
            }

            if ((endDate - startDate).TotalDays > 14)
            {
                ModelState.AddModelError("endDate", "Длительность отпуска не должна превышать 14 дней");
            }

            if (ModelState.IsValid)
            {
                Vacation newVacation = new Vacation(startDate, endDate, employee);
                vacations.Add(newVacation);
                return RedirectToAction("Vacations");
            }

            ViewBag.Employees = employees;
            return View();
        }
        [HttpPost]
        public ActionResult CreateVacation(Vacation vacation, int employeeId)
        {
            if (ModelState.IsValid)
            {
                Employee employee = DataStorage.Employees.FirstOrDefault(e => e.Id == employeeId);

                if (employee != null)
                {
                    Vacation existingVacation = DataStorage.Vacations.FirstOrDefault(v => v.Id == employeeId);

                    if (existingVacation != null)
                    {
                        existingVacation.StartDate = vacation.StartDate;
                        existingVacation.EndDate = vacation.EndDate;
                        existingVacation.Employee = employee;
                    }
                    else
                    {
                        ModelState.AddModelError("", "Отпуск не найден");
                        ViewBag.Employees = new SelectList(DataStorage.Employees, "Id", "FullName");
                        return View("CreateVacation", vacation);
                    }

                    return RedirectToAction("Vacations");
                }

                ModelState.AddModelError("EmployeeId", "Неверный сотрудник");
            }

            ViewBag.Employees = new SelectList(DataStorage.Employees, "Id", "FullName");
            return View("CreateVacation", vacation);
        }

        public ActionResult VacationIntersections()
        {
            List<VacationIntersection> intersections = new List<VacationIntersection>();

            // Пересечение отпуска с сотрудниками моего отдела. Сотрудники моложе 30 лет.
            List<Employee> youngColleagues = DataStorage.Employees.Where(e => e.Department == "Мой отдел" && e.Age < 30).ToList();
            List<Vacation> intersectionWithYoungColleagues = DataStorage.Vacations.Where(v => youngColleagues.Contains(v.Employee)).ToList();
            intersections.Add(new VacationIntersection("Сотрудники моего отдела моложе 30 лет", intersectionWithYoungColleagues));

            // Пересечение отпуска с сотрудниками-женщинами не из моего отдела. Возраст сотрудников - старше 30, но моложе 50.
            List<Employee> womenColleagues = DataStorage.Employees.Where(e => e.Department != "Мой отдел" && e.Gender == "Женский" && e.Age > 30 && e.Age < 50).ToList();
            List<Vacation> intersectionWithWomenColleagues = DataStorage.Vacations.Where(v => womenColleagues.Contains(v.Employee)).ToList();
            intersections.Add(new VacationIntersection("Сотрудницы не из моего отдела старше 30 и моложе 50 лет", intersectionWithWomenColleagues));

            // Пересечение отпуска с сотрудниками из любого отдела. Возраст сотрудников - старше 50 лет.
            List<Employee> seniorColleagues = DataStorage.Employees.Where(e => e.Age > 50).ToList();
            List<Vacation> intersectionWithSeniorColleagues = DataStorage.Vacations.Where(v => seniorColleagues.Contains(v.Employee)).ToList();
            intersections.Add(new VacationIntersection("Сотрудники старше 50 лет", intersectionWithSeniorColleagues));

            // Отпуска без пересечений.
            List<Vacation> nonIntersectingVacations = DataStorage.Vacations.Except(intersections.SelectMany(i => i.Vacations)).ToList();
            intersections.Add(new VacationIntersection("Отпуска без пересечений", nonIntersectingVacations));

            return View(intersections);
        }

        private List<Employee> GenerateRandomEmployees(int count)
        {
            List<Employee> employees = new List<Employee>();

            string[] positions = { "Менеджер", "Разработчик", "Аналитик", "Тестировщик", "Дизайнер",
                                   "Бухгалтер", "HR-специалист", "Маркетолог", "Администратор", "Продавец" };

            string[] departments = { "Мой отдел", "Отдел разработки", "Отдел маркетинга", "Отдел финансов", "Отдел кадров" };

            Random random = new Random();
            if (DataStorage.Employees.Count == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    string fullName = "Сотрудник " + (i + 1);
                    string gender = random.Next(2) == 0 ? "Мужской" : "Женский";
                    string position = positions[random.Next(positions.Length)];
                    int age = random.Next(20, 60);
                    string department = departments[random.Next(departments.Length)];

                    Employee employee = new Employee(i + 1, fullName, gender, position, age, department);
                    employees.Add(employee);
                }
            }
           
            DataStorage.Employees.AddRange(employees);
            return employees;
        }
        private DateTime GenerateRandomStartDate(int year)
        {
            Random random = new Random();
            int startDayOfYear = random.Next(1, 365);
            DateTime startDate = new DateTime(year, 1, 1).AddDays(startDayOfYear);
            return startDate;
        }

        private DateTime GenerateRandomEndDate(DateTime startDate)
        {
            Random random = new Random();
            int vacationLength = random.Next(1, 15);
            DateTime endDate = startDate.AddDays(vacationLength);
            return endDate;
        }

        private List<Vacation> GenerateRandomVacations(List<Employee> employees)
        {
            
            List<Vacation> vacations = new List<Vacation>();

            
            int currentYear = DateTime.Now.Year;
            if (DataStorage.Vacations.Count == 0)
            {
                foreach (Employee employee in employees)
                {
                    DateTime startDate = GenerateRandomStartDate(currentYear);
                    DateTime endDate = GenerateRandomEndDate(startDate);
                    Vacation vacation = new Vacation(startDate, endDate, employee);

                    vacations.Add(vacation);

                }
                
            }
           
            DataStorage.Vacations.AddRange(vacations);
            return vacations;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }

        public Employee(int id, string fullName, string gender, string position, int age, string department)
        {
            Id = id;
            FullName = fullName;
            Gender = gender;
            Position = position;
            Age = age;
            Department = department;
        }

        public Employee()
        {
        }
    }

    public class Vacation
    {
        [Display(Name = "Сотрудник")]
        public Employee Employee { get; set; }

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int EmployeeId { get; set; }


        public Vacation(DateTime startDate, DateTime endDate, Employee employee)
        {
            StartDate = startDate;
            EndDate = endDate;
            Employee = employee;
            EmployeeId = employee.Id;
            Id = employee.Id;
        }
        public Vacation()
        {
            Employee = new Employee();
        }
    }

    public class VacationIntersection
    {
        public string Criteria { get; set; }
        public List<Vacation> Vacations { get; set; }

        public VacationIntersection(string criteria, List<Vacation> vacations)
        {
            Criteria = criteria;
            Vacations = vacations;
        }
    }
    public static class DataStorage
    {
        public static List<Employee> Employees { get; } = new List<Employee>();
        public static List<Vacation> Vacations { get; } = new List<Vacation>();
    }
}

