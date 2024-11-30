using System.ComponentModel.Design;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using static System.Formats.Asn1.AsnWriter;
using System.Xml.Linq;

namespace Zeyadyasser_project
{
    //fundemental project
    // struct to store student information
    struct Student
    {
        public int StudentID;
        public string StudentName;
        public grade Lettergrade;
        public int[] Scores;
        public double avarage;


    }
    // enum i will used to made data type form stored student grade
    enum grade { A, B, C, D, F }
    // now in frist add funcation

    internal class Program
    {
        static void addnew_student(Student[] students, ref int studentCount)
        {
            Console.Write("Enter Student ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Number of Subject");
            int number_subject=int.Parse(Console.ReadLine());
            int[] scores = new int[number_subject];
            for (int i = 0; i <scores.Length; i++)
            {
              
                    Console.Write($"Enter Score for Subject {i + 1}: ");
                scores[i] = int.Parse(Console.ReadLine());

            }
            double average = scores.Average(); 
            students[studentCount] = new Student
            {
                StudentID = id, 
                StudentName = name,
                Scores = scores,
                avarage = average 
            };
            studentCount++;
           
            Console.WriteLine("Student added successfully!");

        }
        static void updatastudent(Student[] student, ref int studentcount)
        {
            Console.WriteLine("Enter Student ID");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number of subject");
            int num_subject=int.Parse(Console.ReadLine());
            bool found = false;
            for (int i = 0; i < studentcount; i++)
            {
                if (student[i].StudentID == id)
                {
                    found = true;
                    
                    Console.WriteLine("Enter The New Name");
                    student[i].StudentName = Console.ReadLine();
                    
                    int[] scores = new int[num_subject];
                    for (int j = 0; j <scores.Length ; j++)
                    {
                        Console.Write($"Enter the New score of subject \t{j+1}:");
                        student[i].Scores[j] = int.Parse(Console.ReadLine( ));
                        
                    }
                    student[i].Scores= scores;
                    student[i].avarage = scores.Average();
                         if (student[i].avarage >= 90) student[i].Lettergrade = grade.A;
                    else if (student[i].avarage >= 80) student[i].Lettergrade = grade.B;
                    else if (student[i].avarage >= 70) student[i].Lettergrade = grade.C;
                    else if (student[i].avarage >= 60) student[i].Lettergrade = grade.D;
                    else student[i].Lettergrade = grade.F;
                    Console.WriteLine(" data updata successfully");
                    break;


                }
                
            }
            if (!found)
            {
                Console.WriteLine(" student id is not !found" +
                    "enter new id");
            }

        }


        static void Cal_Average(Student[] students, int studentCount)
        {

            
            
            for (int i = 0; i < studentCount; i++)
            {

                double average = students[i].avarage;

                if (students[i].avarage >= 90) students[i].Lettergrade = grade.A;
                else if (students[i].avarage >= 80) students[i].Lettergrade = grade.B;
                else if (students[i].avarage >= 70) students[i].Lettergrade = grade.C;
                else if (students[i].avarage >= 60) students[i].Lettergrade= grade.D;
                else students[i].Lettergrade = grade.F;
                Console.WriteLine(new string('-', 30));
            }
            Console.WriteLine("Grades calculated successfully!");

        }
        static void Displayqw(Student[] students, int studentCount)
        {
            if (studentCount==0)
            {
                Console.WriteLine("No student to dispaly");
            }
            for (int i = 0; i < studentCount; i++)
            {
                Console.WriteLine($"Student ID: {students[i].StudentID}");
                Console.WriteLine($"Student Name: {students[i].StudentName}");
                Console.WriteLine($"Student Scores: {string.Join(", ", students[i].Scores)}");
                Console.WriteLine($"Average Grade: {students[i].avarage:F2}");
                Console.WriteLine($"Letter Grade: {students[i].Lettergrade}");
                Console.WriteLine(new string('-', 30));
            }
        }
        static void Main(string[] args)
        {
            const int MaxStudents = 20;
            Student[] students = new Student[MaxStudents];
            int studentCount = 0;
            int choice;
            do 
            {
              Console.WriteLine("\n Welcom in Student Grade Management System");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Update Student");
                 Console.WriteLine("3. Calculate Grades");
                 Console.WriteLine("4. Display Results");
                    Console.WriteLine("5. Exit");
                     Console.Write("Enter your choice: ");
                choice=int.Parse(Console.ReadLine());

          
             switch (choice)
                {
                    case 1:
                        if (studentCount < MaxStudents)
                            addnew_student(students, ref studentCount);
                        else
                            Console.WriteLine("Maximum number of students reached!");
                        break;
                    case 2:
                        updatastudent(students,ref studentCount);

                        break;
                    case 3:
                        Cal_Average(students, studentCount);
                        break;
                    case 4:
                        Displayqw(students, studentCount);
                        break;
                    case 5:
                        Console.WriteLine("Exite ");
                        break;
                    default:
                        Console.WriteLine(" invaild choice;please try again");
                        break ;
                }
                
            } while (choice != 5);
                        

            

        }
    }
}