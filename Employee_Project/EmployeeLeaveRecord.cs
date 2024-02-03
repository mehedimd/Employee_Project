using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Project
{
    internal class EmployeeLeaveRecord
    {
        public string EmpID { get; set; }
        public DateTime LeaveDate { get; set; }
        public string LeaveReason { get; set; }
        public int LeaveCountDay { get; set; }
    }
}
