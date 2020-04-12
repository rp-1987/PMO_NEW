using System;
using System.Collections.Generic;
using System.Text;

namespace PMO.Models.DataAccess
{

    public class UserInProjects
    {
        public string UserId { get; set; }
        public List<UserProject> UserProjects { get; set; }
    }

    public class UserProject
    {        
        public UserRole Role { get; set; }
        public Project Project { get; set; }
    }
}
