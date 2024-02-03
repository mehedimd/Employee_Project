using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project
{
    // Enum
    public enum Departments
    {
        SoftwareEngineering, IT, Production
    }
    // Enum
    public enum Designations
    {
        Manager, JrDeveloper, SoftwareEngineer, SrDeveloper, DataEntry
    }
    internal class Employee : EmployeeRoot
    {
        public string EmpID { get; set; }
        public string EmpName { get; set; }
        public DateTime JoinDate { get; set; }
        public Departments Department { get; set; }
        public Designations Designation { get; set; }
        public double Salary { get; set; }
    }
}
