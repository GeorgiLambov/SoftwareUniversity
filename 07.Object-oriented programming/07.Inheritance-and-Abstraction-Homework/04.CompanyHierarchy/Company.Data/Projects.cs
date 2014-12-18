using System;

namespace Company.Data
{
    public class Projects : IProjects
    {
        private string projectName;
        private DateTime startDate;
        private string detail;
        private ProjectState state;

        public Projects(string projectName, DateTime startDate, string detail, ProjectState state)
        {
            this.ProjectName = projectName;
            this.StartDate = startDate;
            this.Detail = detail;
            this.State = state;
        }
        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Project Name can not be null or empty!");
                }

                this.projectName = value;
            }
        }
        public DateTime StartDate
        {
            get
            {
                return this.startDate;
            }

            set
            {
                if (value == default(DateTime))
                {
                    throw new ArgumentException("Datetime is invalid!");
                }

                this.startDate = value;
            }
        }
        public string Detail
        {
            get
            {
                return this.detail;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Detail", "Detail can not be null or empty!");
                }

                this.detail = value;
            }
        }
        public ProjectState State
        {
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
            }
        }


        public void CloseProject()
        {
            if (this.state == ProjectState.open)
            {
                this.State = ProjectState.closed;
            }
        }

        public override string ToString()
        {
            return string.Format(
                "Project: {0}, started: {1:dd.MM.yyyy}, State: {2}, Details: {3}",
                this.ProjectName,
                this.StartDate,
                this.State,
                this.Detail);
        }
    }
}
