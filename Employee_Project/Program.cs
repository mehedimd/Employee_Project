using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------------------------------------Employee Add---------------------------------------------
            EmployeeRoot employeeRoot = new EmployeeRoot();
            employeeRoot.Add(new Employee()
            {
                EmpID = "P-102",
                EmpName = "Mehedi",
                JoinDate = new DateTime(2023, 2, 2),
                Department = Departments.SoftwareEngineering,
                Designation = Designations.JrDeveloper,
                Salary = 50000
            });
            employeeRoot.Add(new Employee()
            {
                EmpID = "P-112",
                EmpName = "Rakib",
                JoinDate = new DateTime(2023, 12, 02),
                Department = Departments.SoftwareEngineering,
                Designation = Designations.SrDeveloper,
                Salary = 85000
            });
            employeeRoot.Add(new Employee()
            {
                EmpID = "P-107",
                EmpName = "Zahid",
                JoinDate = new DateTime(2023, 04,07),
                Department = Departments.Production,
                Designation = Designations.Manager,
                Salary = 150000
            });
            employeeRoot.Add(new Employee()
            {
                EmpID = "P-131",
                EmpName = "Mehedi",
                JoinDate = new DateTime(2023, 01, 10),
                Department = Departments.Production,
                Designation = Designations.DataEntry,
                Salary = 50000
            });

            // -------------------------------------------Leave Record Add-----------------------------------------
            
            LeaveRecordRoot leaveRecordRoot = new LeaveRecordRoot();

            leaveRecordRoot.Add(new EmployeeLeaveRecord()
            {
                    EmpID = "P-102",
                    LeaveDate = new DateTime(2024,01, 02),
                    LeaveReason = "Sick",
                    LeaveCountDay = 1               
            });
            leaveRecordRoot.Add(new EmployeeLeaveRecord()
            {
                EmpID = "P-107",
                LeaveDate = new DateTime(2024, 01, 12),
                LeaveReason = "Father's Sick",
                LeaveCountDay = 3
            });
            leaveRecordRoot.Add(new EmployeeLeaveRecord()
            {
                EmpID = "P-131",
                LeaveDate = new DateTime(2024, 01, 02),
                LeaveReason = "Sick",
                LeaveCountDay = 2
            });


            // --------------------------------------Retrive All Employees Record---------------------------------
            var allEmployees = employeeRoot.GetAll();
            Console.WriteLine("\n============================================ All Employees Record ======================================");
            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"EmployeeID: {employee.EmpID}, Name: {employee.EmpName}, Department: {employee.Department}, Designation: {employee.Designation}, " +
                    $" Salary: {employee.Salary}");
            }

            //---------------------------------------Retrive All Leave Record---------------------------
            var allLeaveRecord = leaveRecordRoot.GetAll();
            Console.WriteLine("\n============================================ All Leave Record ======================================");
            allLeaveRecord.ForEach(leave => Console.WriteLine($"EmployeeID: {leave.EmpID}, " +
                $"LeaveDate: {leave.LeaveDate}, Reason: {leave.LeaveReason}, TotalLeave: {leave.LeaveCountDay}"));

            
            // ------------------------Join  "Employee" and "EmployeeLeaveRecord"
            //                              Retrive Employees who have taken leave Using LINQ --------------

            var leaveEmployees = from employees in allEmployees
                                 join leaveRecord in allLeaveRecord
                                 on employees.EmpID equals leaveRecord.EmpID
                                 select new
                                 {
                                     ID = employees.EmpID,
                                     Name = employees.EmpName,
                                     Design = employees.Designation,
                                     Date = leaveRecord.LeaveDate,
                                     Reason = leaveRecord.LeaveReason,
                                     TotalLeaveDay = leaveRecord.LeaveCountDay
                                 };
            Console.WriteLine("\n============================================ Employees who have taken leave ======================================");
            foreach (var lv in leaveEmployees)
            {
                Console.WriteLine($"EmployeeID: {lv.ID}, Name: {lv.Name}, Designation: {lv.Design}, " +
                    $"LeaveDate: {lv.Date}, Reason: {lv.Reason}, TotalLeaveDay: {lv.TotalLeaveDay}");
            }

            // -----------------Retrive Employees Where Department = "SoftwareEngineering"  and Orderby() Department Name------------------
            Console.WriteLine("\n============================= Only SoftWare Engineering Department's Leave Record==========================");
            var softDepartEmp = allEmployees.Where(emp => emp.Department.Equals(Departments.SoftwareEngineering)).OrderBy(odr => odr.Department);

            foreach (var emp in softDepartEmp)
            {
                Console.WriteLine($"Employee ID: {emp.EmpID}, Name: {emp.EmpName}, Department: {emp.Department}, Designation: {emp.Designation} " +
                    $"Salary: {emp.Salary}");
            }

            //                                ================ Aggrigate Function() ===========================

            //--------------------------------------------------Count Total Employee---------------------------------------------------
            Console.WriteLine("\n================================= Count Total Employee ====================================");
            var countEmployee = allEmployees.Count();
            Console.WriteLine($"Total Employees = {countEmployee}");

            // --------------------------------------  Maximum Salary Employee's Details -----------------------
            Console.WriteLine("\n========================= Maximum Salary Employee's Details =================================");
            var maxSalary = allEmployees.Max(emp => emp.Salary);
            var MaxSalaryEmp = allEmployees.Where(emp => emp.Salary.Equals(maxSalary)).FirstOrDefault();

            Console.WriteLine($"Employee ID: {MaxSalaryEmp.EmpID}, Name: {MaxSalaryEmp.EmpName}, Department: {MaxSalaryEmp.Department}, Designation: {MaxSalaryEmp.Designation} " +
                                $"Salary: {MaxSalaryEmp.Salary}");

            // ------------------------------------------------- Groupby Department----------------------------------------------------------
            Console.WriteLine("\n===================================== Groupby Department =======================================");
            var groupByDepart = from allEmp in allEmployees
                                group allEmp by allEmp.Department into dpt
                                select new
                                {
                                    Name = dpt.Key,
                                    DepartCount = dpt.Count(),
                                };
            Console.WriteLine("Department \t TotalEmployeePerDepartment");
            foreach (var emp in groupByDepart)
            {
                Console.WriteLine($"{emp.Name}, {emp.DepartCount} ");
            }

            Console.ReadKey();
        }
    }
}
