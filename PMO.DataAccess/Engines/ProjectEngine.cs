using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using PMO.Models.DataAccess;

namespace PMO.DataAccess.Engines
{
    public class ProjectEngine : BaseEngine, IProjectEngine
    {
        public ProjectEngine()
        {

        }

        public List<Project> GetProjectStatusRATop5()
        {
            string sql = "PMO_Project_StatusRA_Top5";
            var projects = new List<Project>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            ProjectId = long.Parse(reader["ProjectID"].ToString()),
                            ProjectShortName = reader["Short"].ToString(),
                            ProjectLongName = reader["Project_Name"].ToString(),
                            StartDate = reader["StartDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["StartDate"]),
                            EndDate = reader["EndDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["EndDate"]),
                            MppPath = reader["MPP_Path"].ToString(),
                            CreatedBy = reader["CreatedBy"].ToString(),
                            CreatedOn = reader["CreatedOn"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["CreatedOn"]),
                            ResourceStatus = reader["Resource_Status"].ToString(),
                            TimeStatus = reader["Time_Status"].ToString(),
                            CostStatus = reader["Cost_Status"].ToString(),
                            StatusSummary = reader["Status_Summary"].ToString(),
                            ModifiedBy = reader["ModifiedBy"].ToString(),
                            ModifiedOn = reader["ModifiedOn"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["ModifiedOn"]),
                            IsEnable = int.Parse(reader["isEnable"].ToString()),
                            Objective = reader["Objective"].ToString(),
                            ProjectOutlook = reader["Project_Outlook"].ToString(),
                            IsPSC = (reader["IsPSC"].ToString() == "1"),
                            PsrMode = reader["PSR_MODE"].ToString(),
                            PsrTat = int.Parse(reader["PSR_TAT"].ToString()),
                            StatusChallenges = reader["STATUS_CHALLENGES"].ToString(),
                            ProjectScope = reader["Scope"].ToString(),
                            ProjectImportance = reader["Importance"].ToString(),
                            UpdatedOn = reader["UpdatedOn"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["UpdatedOn"])
                        });
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                    throw;
                }

                return projects;
            }
        }


        public List<Project> GetProjectStatusChartTop5()
        {
            string sql = "PMO_Project_Status_Chart_top5";
            var projects = new List<Project>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            ProjectId = long.Parse(reader["projectid"].ToString()),
                            ProjectShortName = reader["ProjectShortName"].ToString(),
                            ProjectLongName = reader["ProjectName"].ToString(),
                            StartDate = reader["actualstartdate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["actualstartdate"]),
                            EndDate = reader["actualenddate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["actualenddate"]),
                            PlannedStartDate = reader["PlannedStartDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["PlannedStartDate"]),
                            PlannedEndDate = reader["PlannedEndDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["PlannedEndDate"]),
                            PlannedProjectDuration = reader["PlannedDays"] is DBNull ? 0 : int.Parse(reader["PlannedDays"].ToString()),
                            ProjectDuration = reader["actual"] is DBNull ? 0 : int.Parse(reader["actual"].ToString()),
                        });
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                    throw;
                }

                return projects;
            }
        }

        public List<Project> GetProjectStatusTop5(string isPsc, string imp)
        {
            string sql = "PMO_Project_Status_Top5";
            var projects = new List<Project>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@IsPSC", isPsc));
                sqlCommand.Parameters.Add(new SqlParameter("@imp", imp));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            ProjectId = long.Parse(reader["ProjectID"].ToString()),
                            ProjectShortName = reader["Short"].ToString(),
                            ProjectLongName = reader["Project_Name"].ToString(),
                            StartDate = reader["StartDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["StartDate"]),
                            EndDate = reader["EndDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["EndDate"]),
                            CreatedOn = reader["CreatedOn"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["CreatedOn"]),
                            MppPath = reader["MPP_Path"].ToString(),
                            CreatedBy = reader["CreatedBy"].ToString(),
                            ResourceStatus = reader["ResourceColor"].ToString(),
                            TimeStatus = reader["TimeColor"].ToString(),
                            CostStatus = reader["CostColor"].ToString(),
                            StatusSummary = reader["Status_Summary"].ToString(),
                            ModifiedBy = reader["ModifiedBy"].ToString(),
                            ModifiedOn = reader["ModifiedOn"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["ModifiedOn"]),
                            IsEnable = reader["isEnable"] is DBNull ? 0 : int.Parse(reader["isEnable"].ToString()),
                            Objective = reader["Objective"].ToString(),
                            ProjectOutlook = reader["Project_Outlook"].ToString(),
                            IsPSC = reader["Project_Outlook"].ToString() == "1" ? true : false,
                            PsrMode = reader["PSR_MODE"].ToString(),
                            PsrTat = reader["PSR_TAT"] is DBNull ? 0 : int.Parse(reader["PSR_TAT"].ToString()),
                            StatusChallenges = reader["STATUS_CHALLENGES"].ToString(),
                            ProjectScope = reader["Scope"].ToString(),
                            ProjectImportance = reader["Importance"].ToString(),
                            UpdatedOn = reader["UpdatedOn"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["UpdatedOn"])
                        });
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                    throw;
                }

                return projects;
            }
        }

        public UserInProjects GetProjectsByUser(string userId)
        {
            string sql = "PMO_Project_Get_By_UserID";
            UserInProjects userInProjects = null;
            var userProjects = new List<UserProject>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var sqlCommand = new SqlCommand(sql, connection);
                sqlCommand.Parameters.Add(new SqlParameter("@UserId", userId));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        userProjects.Add(new UserProject
                        {
                            Project = new Project
                            {
                                ProjectId = long.Parse(reader["ProjectID"].ToString()),
                                ProjectShortName = reader["Short"].ToString(),
                                ProjectLongName = reader["Project_Name"].ToString()
                            },
                            Role = new UserRole
                            {
                                RoleId = int.Parse(reader["RollID"].ToString()),
                                RoleName = reader["DispRoll"].ToString()
                            }
                        });
                    }
                    connection.Close();

                    userInProjects = new UserInProjects
                    {
                        UserId = userId,
                        UserProjects = userProjects
                    };
                }
                catch (Exception ex)
                {

                    throw;
                }

                return userInProjects;
            }
        }

        public List<Project> GetAllProjects(string isPsc, string imp)
        {
            string sql = "usp_GetAllProjectsForExecutiveDashboard";
            var projects = new List<Project>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                var sqlCommand = new SqlCommand(sql, connection);
                if (!string.IsNullOrEmpty(isPsc))
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPSC", isPsc));
                if (!string.IsNullOrEmpty(imp))
                    sqlCommand.Parameters.Add(new SqlParameter("@imp", imp));
                sqlCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    connection.Open();
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        projects.Add(new Project
                        {
                            ProjectId = long.Parse(reader["ProjectID"].ToString()),
                            ProjectLongName = reader["Project_Name"].ToString(),
                            StartDate = reader["StartDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["StartDate"]),
                            EndDate = reader["EndDate"] is DBNull ? DateTime.Now : Convert.ToDateTime(reader["EndDate"]),
                            ResourceStatus = GetColor(reader["Resource_Status"].ToString()),
                            TimeStatus = GetColor(reader["Time_Status"].ToString()),
                            CostStatus = GetColor(reader["Cost_Status"].ToString()),
                            ProjectManager = reader["EmpName"].ToString(),
                            ProjectManagerId = reader["EmpId"].ToString(),
                            IsPSC = reader["IsPSC"].ToString() == "0" ? true : false,
                            ProjectImportance = reader["Importance"].ToString(),
                            StatusSummary = reader["Status_Summary"].ToString()
                        });
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {

                    throw;
                }

                return projects;
            }
        }

        public string GetColor(string colorCode)
        {
            switch (colorCode)
            {
                case "1":
                    return "red";
                case "2":
                    return "yellow";
                case "3":
                    return "green";
                default:
                    return "grey";
            }
        }
    }
}
