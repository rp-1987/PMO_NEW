using System.Collections.Generic;
using PMO.Models.DataAccess;

namespace PMO.DataAccess.Engines
{
    public interface IProjectEngine
    {
        List<Project> GetProjectStatusRATop5();
        List<Project> GetProjectStatusChartTop5();
        List<Project> GetProjectStatusTop5(string isPsc, string imp);
        UserInProjects GetProjectsByUser(string userId);
        List<Project> GetAllProjects(string isPsc, string imp);
    }
}