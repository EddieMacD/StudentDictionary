using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Program
    {
        #region Structures
        struct Student
        {
            public string Name;
            public double Age;
            public string Nationality;
        }
        #endregion

        #region ValidateInput
        static int ValidateExistingID(Dictionary<int, Student> dictionary)
        {
            int ID = 0;
            bool valid = false;

            do
            {
                Console.Write("Enter the student's ID:    ");

                if (int.TryParse(Console.ReadLine(), out ID))
                {
                    if (dictionary.ContainsKey(ID))
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid student ID");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid student ID");
                    Console.WriteLine("");
                }
            } while (!valid);

            return ID;
        }

        static int ValidateNewID(Dictionary<int, Student> dictionary)
        {
            int ID = 0;
            bool valid = false;

            do
            {
                Console.Write("Enter the new student's ID:    ");

                if (int.TryParse(Console.ReadLine(), out ID))
                {
                    if (!dictionary.ContainsKey(ID))
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("That ID already exists");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid student ID");
                    Console.WriteLine("");
                }
            } while (!valid);

            return ID;
        }

        static string ValidateNewName ()
        {
            string name = "";
            bool valid = false;

            do
            {
                Console.Write("Enter the new student's name:    ");
                name = Console.ReadLine();

                if (name != "")
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid name");
                    Console.WriteLine("");
                }
            } while (!valid);

            return name;
        }

        static double ValidateNewAge()
        {
            double age = 0;
            bool valid = false;

            do
            {
                Console.Write("Enter the new student's age:    ");

                if (double.TryParse(Console.ReadLine(), out age))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid age");
                    Console.WriteLine("");
                }
            } while (!valid);

            return age;
        }

        static string ValidateNewNationality()
        {
            string nationality;
            bool valid = false;

            do
            {
                Console.Write("Enter the new student's nationality:    ");
                nationality = Console.ReadLine();

                if (nationality != "")
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Invalid nationality");
                    Console.WriteLine("");
                }
            } while (!valid);

            return nationality;
        }
        #endregion

        #region Add
        static void AddStudent(Dictionary<int, Student> dictionary)
        {
            int newID = ValidateNewID(dictionary);
            Student newStudent = new Student();

            Console.WriteLine("");
            Console.WriteLine("");

            newStudent.Name = ValidateNewName();

            Console.WriteLine("");
            Console.WriteLine("");

            newStudent.Age = ValidateNewAge();

            Console.WriteLine("");
            Console.WriteLine("");

            newStudent.Nationality = ValidateNewNationality();

            Console.Clear();
            Console.WriteLine("New Student " + newID + " Added");
            Console.WriteLine("");

            dictionary.Add(newID, newStudent);
        }
        #endregion

        #region Update
        static void UpdateStudent(Dictionary<int, Student> dictionary)
        {
            int ID = ValidateExistingID(dictionary);
            bool invalid = true;

            Console.Clear();

            do
            {
                DisplayUpdateMenu();

                Console.Write("Enter your choice:    ");
                int.TryParse(Console.ReadLine(), out int input);

                Console.Clear();

                switch (input)
                {
                    case 1:
                        invalid = false;
                        UpdateName(dictionary, ID);
                        break;

                    case 2:
                        invalid = false;
                        UpdateAge(dictionary, ID);
                        break;

                    case 3:
                        invalid = false;
                        UpdateNationality(dictionary, ID);
                        break;

                    case 4:
                        invalid = false;
                        UpdateName(dictionary, ID);
                        Console.WriteLine();
                        Console.WriteLine();
                        UpdateAge(dictionary, ID);
                        Console.WriteLine();
                        Console.WriteLine();
                        UpdateNationality(dictionary, ID);
                        break;

                    default:
                        Console.WriteLine("Not a valid menu item");
                        break;
                }
            } while (invalid);

            Console.Clear();
            Console.WriteLine("Student " + ID + " Updated");
            Console.WriteLine("");
        }

        static void UpdateName(Dictionary<int, Student> dictionary, int ID)
        {
            Student student = dictionary[ID];
            student.Name = ValidateNewName();
            dictionary[ID] = student;
        }

        static void UpdateAge(Dictionary<int, Student> dictionary, int ID)
        {
            Student student = dictionary[ID];
            student.Age = ValidateNewAge();
            dictionary[ID] = student;
        }

        static void UpdateNationality(Dictionary<int, Student> dictionary, int ID)
        {
            Student student = dictionary[ID];
            student.Nationality = ValidateNewNationality();
            dictionary[ID] = student;
        }

        static void DisplayUpdateMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("1:    Update Name");
            Console.WriteLine("2:    Update Age");
            Console.WriteLine("3:    Update Nationality");
            Console.WriteLine("");
            Console.WriteLine("4:    Update All");
            Console.WriteLine("=================================");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        #endregion

        #region Remove
        static void RemoveStudent(Dictionary<int, Student> dictionary)
        {
            int ID = ValidateExistingID(dictionary);

            dictionary.Remove(ID);

            Console.Clear();
            Console.WriteLine("Student " + ID + " Removed");
            Console.WriteLine("");
        }
        #endregion

        #region Print
        static string StudentLine(int ID, Student student)
        {
            return (ID + ":    " + student.Name + ", Age " + student.Age + " years, " + student.Nationality);
        }
        
        static void PrintStudent(Dictionary<int, Student> dictionary)
        {
            int ID = ValidateExistingID(dictionary);

            Console.Clear();
            Console.WriteLine(StudentLine(ID, dictionary[ID]));
        }

        static void PrintAll (Dictionary<int, Student> dictionary)
        {
            for(int i = 0; i < dictionary.Count(); i++)
            {
                int ID = dictionary.ElementAt(i).Key;
                Console.WriteLine(StudentLine(ID, dictionary[ID]));
            }

            Console.WriteLine("");
            Console.WriteLine("");
        }
        #endregion

        #region MainMenu
        static void Main(string[] args)
        {
            Dictionary<int, Student> dictionary = new Dictionary<int, Student>();
            bool more = true;

            do
            {
                DisplayMainMenu();

                Console.Write("Enter your choice:    ");
                int.TryParse(Console.ReadLine(), out int input);

                Console.Clear();

                switch (input)
                {
                    case 1:
                        AddStudent(dictionary);
                        break;

                    case 2:
                        UpdateStudent(dictionary);
                        break;

                    case 3:
                        RemoveStudent(dictionary);
                        break;

                    case 4:
                        PrintStudent(dictionary);
                        break;

                    case 5:
                        PrintAll(dictionary);
                        break;

                    case 9:
                        more = false;
                        break;

                    default:
                        Console.WriteLine("Not a valid menu item");
                        break;
                }
            } while (more);
        }

        static void DisplayMainMenu()
        {
            Console.WriteLine("=================================");
            Console.WriteLine("1:    Add Student");
            Console.WriteLine("2:    Update Student");
            Console.WriteLine("3:    Remove Student");
            Console.WriteLine("4:    Print Student");
            Console.WriteLine("5:    Print All Students");
            Console.WriteLine("");
            Console.WriteLine("9:    Exit");
            Console.WriteLine("=================================");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        #endregion
    }
}
