using System;
using System.Collections.Generic;
using System.Linq; 

namespace oop.cs
{
    public class Student
    {
        public string StdID { get; set; }
        public string Name { get; set; }
        public Student(string masv, string hoten)
        {
            StdID = masv;
            Name = hoten;
        }
    }

    public class StudentDAO
    {
        private List<Student> Students = new List<Student>();

        static void Main()
        {
            var dao = new StudentDAO();
            dao.Students = new List<Student>()
            {
                new Student("SV001", "An"),
                new Student("SV002", "Binh"),
                new Student("SV001", "An")
            };
            dao.Add(new Student("SV004", "Cuong"));
        }

        public void Add(Student student)
        {
            Students.Add(student);
        }

        public void Edit(Student student)
        {
            var existingStudent = Students.FirstOrDefault(s => s.StdID == student.StdID);

            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                Console.WriteLine($"tim thay sinh vien thanh cong {student.StdID}!");
            }
            else
            {
                Console.WriteLine($"khong tim thay sinh vien {student.StdID} de sua.");
            }
        }
        static SinhVien GetById(List<SinhVien> danhSach, string id)
        {
            return danhSach.FirstOrDefault(sv => sv.MaSV.Equals(id, StringComparison.OrdinalIgnoreCase));
        }

        // 3. Tìm sinh viên theo Tên (getByName) - Trả về danh sách (vì có thể trùng tên hoặc tìm gần đúng)
        static List<SinhVien> GetByName(List<SinhVien> danhSach, string name)
        {
            return danhSach.Where(sv => sv.HoTen.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // 4. Xóa sinh viên theo Mã (Delete) - Trả về true nếu xóa thành công, ngược lại là false
        static bool Delete(List<SinhVien> danhSach, string id)
        {
            var sv = GetById(danhSach, id);
            if (sv != null)
            {
                danhSach.Remove(sv);
                return true;
            }
            return false;
        }

        static List<SinhVien> GetAlls(List<SinhVien> danhSach)
        {
            return danhSach ?? new List<SinhVien>();
        }

        static void RunSinhVienDemo()
        {
            // Khởi tạo danh sách sinh viên ban đầu
            List<SinhVien> danhSachSV = new List<SinhVien>
        {
            new SinhVien("SV001", "Trần Hiếu Minh", 22),
            new SinhVien("SV002", "Nguyễn Minh Đức", 22),
            new SinhVien("SV003", "Bùi Khánh Linh", 21)
        };

            // --- TEST 1: getAlls ---
            Console.WriteLine("=== 1. TEST GET ALLS ===");
            var tatCa = GetAlls(danhSachSV);
            foreach (var sv in tatCa)
            {
                Console.WriteLine($"Mã: {sv.MaSV} | Họ tên: {sv.HoTen}");
            }

            // --- TEST 2: getById ---
            Console.WriteLine("\n=== 2. TEST GET BY ID (SV002) ===");
            var svById = GetById(danhSachSV, "SV002");
            if (svById != null)
            {
                Console.WriteLine($"Đã tìm thấy: {svById.HoTen}, {svById.Tuoi} tuổi");
            }

            // --- TEST 3: getByName ---
            Console.WriteLine("\n=== 3. TEST GET BY NAME ('Minh') ===");
            var svByName = GetByName(danhSachSV, "Minh");
            foreach (var sv in svByName)
            {
                Console.WriteLine($"Kết quả khớp: {sv.MaSV} - {sv.HoTen}");
            }

            // --- TEST 4: Delete ---
            Console.WriteLine("\n=== 4. TEST DELETE (Xóa SV001) ===");
            bool xoaThanhCong = Delete(danhSachSV, "SV001");
            if (xoaThanhCong)
            {
                Console.WriteLine("Xóa thành công! Danh sách sau khi xóa:");
                foreach (var sv in GetAlls(danhSachSV))
                {
                    Console.WriteLine($"Mã: {sv.MaSV} | Họ tên: {sv.HoTen}");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy mã sinh viên cần xóa!");
            }
        }
    }

    public class SinhVien
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public int Tuoi { get; set; }

        public SinhVien(string maSV, string hoTen, int tuoi)
        {
            MaSV = maSV;
            HoTen = hoTen;
            Tuoi = tuoi;
        }
    }
}


