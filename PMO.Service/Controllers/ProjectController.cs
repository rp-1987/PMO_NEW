using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMO.DataAccess.Engines;
using PMO.Models.DataAccess;

namespace PMO.Service.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public readonly IProjectEngine _projectEngine;

        public ProjectController(IProjectEngine projectEngine)
        {
            _projectEngine = projectEngine;
        }

        [HttpGet("/Project/RATopFive")]        
        public ActionResult<List<Project>> GetProjectStatusRATop5()
        {
            return _projectEngine.GetProjectStatusRATop5();
        }

        [HttpGet("/Project/ChartTopFive")]
        public ActionResult<List<Project>> GetProjectStatusChartTop5()
        {
            return _projectEngine.GetProjectStatusChartTop5();
        }

        [HttpGet("/Project/TopFive/{psc}/{imp}")]
        public ActionResult<List<Project>> GetProjectStatusTop5(string psc, string imp)
        {
            return _projectEngine.GetProjectStatusTop5(psc, imp);
        }

        [HttpGet("/Project/ProjectsByUser/{userId}")]
        public ActionResult<UserInProjects> GetProjectsByUser(string userId)
        {
            return _projectEngine.GetProjectsByUser(userId);
        }

        [HttpGet("/Project/GetAllProjects/{psc?}/{imp?}")]
        public ActionResult<List<Project>> GetAllProjects(string psc, string imp)
        {
            return _projectEngine.GetAllProjects(psc, imp);
        }
    }
}