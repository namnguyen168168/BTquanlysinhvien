using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTquanlysinhvien
{
    internal class BTquanlysinhvien
    {
        public class Student
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public double Score { get; set; }
        }

        public class Program
        {
            static Student[] students = new Student[100];
            static int count = 0;

            public static void Main()
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.InputEncoding = Encoding.Unicode;
                int choice;
                do
                {
                    Console.WriteLine("1. Nhập danh sách sinh viên");
                    Console.WriteLine("2. Hiển thị danh sách sinh viên");
                    Console.WriteLine("3. Sắp xếp theo điểm giảm dần");
                    Console.WriteLine("4. Tìm sinh viên theo họ tên");
                    Console.WriteLine("5. Thoát");
                    Console.Write("Nhập lựa chọn của bạn (1-5): ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            InputStudents();
                            break;
                        case 2:
                            DisplayStudents();
                            break;
                        case 3:
                            SortByScore();
                            break;
                        case 4:
                            FindByName();
                            break;
                        case 5:
                            Console.WriteLine("Thoát chương trình.");
                            break;
                        default:
                            Console.WriteLine("Lựa chọn không hợp lệ.");
                            break;
                    }

                    Console.WriteLine();
                } while (choice != 5);
            }

            static void InputStudents()
            {
                Console.Write("Nhập số lượng sinh viên: ");
                int n = int.Parse(Console.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    Console.Write("Nhập mã sinh viên: ");
                    string id = Console.ReadLine();

                    Console.Write("Nhập họ tên: ");
                    string name = Console.ReadLine();

                    Console.Write("Nhập điểm: ");
                    double score = double.Parse(Console.ReadLine());

                    students[count++] = new Student { Id = id, Name = name, Score = score };
                }

                Console.WriteLine("Nhập danh sách sinh viên thành công.");
            }

            static void DisplayStudents()
            {
                if (count == 0)
                {
                    Console.WriteLine("Danh sách sinh viên rỗng.");
                    return;
                }

                Console.WriteLine("Danh sách sinh viên:");
                Console.WriteLine("{0,-10} {1,-20} {2,-10}", "Mã SV", "Họ tên", "Điểm");

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("{0,-10} {1,-20} {2,-10}", students[i].Id, students[i].Name, students[i].Score);
                }
            }

            static void SortByScore()
            {
                if (count == 0)
                {
                    Console.WriteLine("Danh sách sinh viên rỗng.");
                    return;
                }

                Array.Sort(students, 0, count, new StudentScoreComparer());

                Console.WriteLine("Danh sách sinh viên đã sắp xếp theo điểm số giảm dần:");
                Console.WriteLine("{0,-10} {1,-20} {2,-10}", "Mã SV", "Họ tên", "Điểm");

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("{0,-10} {1,-20} {2,-10}", students[i].Id, students[i].Name, students[i].Score);
                }
            }

            static void FindByName()
            {
                if (count == 0)
                {
                    Console.WriteLine("Danh sách sinh viên rỗng.");
                    return;
                }

                Console.Write("Nhập họ tên sinh viên cần tìm kiếm: ");
                string name = Console.ReadLine();

                bool found = false;

                for (int i = 0; i < count; i++)
                {
                    if (students[i].Name.ToUpper().Contains(name.ToUpper()))
                    {
                        Console.WriteLine("{0,-10} {1,-20} {2,-10}", students[i].Id, students[i].Name, students[i].Score);
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Không tìm thấy sinh viên nào có tên {0}.", name);
                }
            }
        }

        public class StudentScoreComparer : IComparer<Student>
        {
            public int Compare(Student x, Student y)
            {
                return y.Score.CompareTo(x.Score);
            }
        }
    }
}
