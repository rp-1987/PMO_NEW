using System;
using System.Collections.Generic;
using System.Text;

namespace PMO.Models.Shared
{
    public class PmoUser
    {
        public string EmpNo { get; set; }
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public string Location { get; set; }
        public bool IsAdmin { get; set; }
    }
}
