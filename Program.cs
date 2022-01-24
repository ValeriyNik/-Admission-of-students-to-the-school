using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace TestApp
{
    public class Student
    {
        public string FirstName;
        public string LastName;
        public int Age;

        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }

    public class School
    {
        public string Name;
        public List<Student> Students;

        public School(string name)
        {
            Name = name;
            Students = new List<Student>();
        }

        public void PrintStudents()
        {
            if (Students.Count == 0)
            {
                Console.WriteLine($"В школе {Name} пока нет учеников!");
            }
            else
            {
                Console.WriteLine("{3, -5} {0, -10} {1, -10} {2, -10}", "Имя", "Фамилия", "Возраст", "№");
                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine("{3, -5} {0, -10} {1, -10} {2, -10}", Students[i].FirstName, Students[i].LastName, Students[i].Age, i + 1);
                }
            }
        }

        public void AddNewStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine($"Студент {student.FirstName} успешно добавлен в школу {Name}.");
        }

        public string DeleteStudent(int numberOfStudents)
        {
            if (numberOfStudents > Students.Count || numberOfStudents < 1)
            {
                return "Ученика с таким номер не существует. Попробуйте снова.";
            }
            else
            {
                string name = Students[numberOfStudents - 1].FirstName;

                Students.RemoveAt(numberOfStudents - 1);

                return $"Ученик {name} успешно удалён.";
            }
        }
    }
    class Program
    {
        static int TestNumber(string number)
        {
            string result = "";

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] >= '0' && number[i] <= '9')
                {
                    result += number[i];
                }
                else
                {
                    return 0;
                }
            }

            return Convert.ToInt32(result);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Введите название вашей школы");
            string schoolName = Console.ReadLine();
            School school = new School(schoolName);
            Console.WriteLine($"Школа {school.Name} успешна создана");

            while (true)
            {
                Console.WriteLine("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
                if (school.Students.Count > 0)
                {
                    Console.WriteLine($"Хотите посмотреть список учеников школы {school.Name}? Введите 1.");
                    Console.WriteLine($"Хотите удалить ученика из школы {school.Name}? Введите 3.");
                }

                Console.WriteLine($"Хотите добавить нового ученика в школу {school.Name}? Введите 2.");
                Console.WriteLine("Хотите завершить программу? Введите 0.");

                string userAnswer = Console.ReadLine();

                if (userAnswer == "1")
                {
                    school.PrintStudents();
                }
                else if (userAnswer == "2")
                {
                    Console.WriteLine("Введите имя ученика");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Введите фамилию ученика");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Введите возраст ученика");
                    int age = Convert.ToInt32(Console.ReadLine());

                    Student student = new Student(firstName, lastName, age);
                    school.AddNewStudent(student);
                }
                else if (userAnswer == "3")
                {
                    school.PrintStudents();
                    Console.WriteLine("Введите номер ученика.");
                    userAnswer = Console.ReadLine();
                    string resultDeleting = school.DeleteStudent(TestNumber(userAnswer));
                    Console.WriteLine(resultDeleting);
                }
                else if (userAnswer == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Вы ввели неверный номер. Повторите попытку.");
                }
            }
        }
    }
}
