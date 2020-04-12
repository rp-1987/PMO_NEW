using System;
using System.Collections.Generic;
using System.Text;

namespace PMO.Models.DataAccess
{
    public class Project
    {
        public virtual long? ProjectId { get; set; }
        public virtual string ProjectShortName { get; set; }
        public virtual string ProjectLongName { get; set; }
        public virtual DateTime? StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual int? ProjectDuration { get; set; }
        public virtual string MppPath { get; set; }
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual string ResourceStatus { get; set; }
        public virtual string TimeStatus { get; set; }
        public virtual string CostStatus { get; set; }
        public virtual string StatusSummary { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? ModifiedOn { get; set; }
        public virtual int IsEnable { get; set; }
        public virtual string Objective { get; set; }
        public virtual string ProjectOutlook { get; set; }
        public virtual bool IsPSC { get; set; }
        public virtual string PsrMode { get; set; }
        public virtual int? PsrTat { get; set; }
        public virtual string StatusChallenges { get; set; }
        public virtual string ProjectScope { get; set; }
        public virtual string ProjectImportance { get; set; }
        public virtual DateTime? UpdatedOn { get; set; }
        public virtual DateTime? PlannedStartDate { get; set; }
        public virtual DateTime? PlannedEndDate { get; set; }
        public virtual int? PlannedProjectDuration { get; set; }
        public virtual string ProjectManager { get; set; }
        public virtual string ProjectManagerId { get; set; }
    }
}
