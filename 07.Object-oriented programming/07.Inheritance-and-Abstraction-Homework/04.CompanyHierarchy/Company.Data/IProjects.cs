namespace Company.Data
{
    using System;
    public interface IProjects
    {
        string ProjectName { get; set; }

        DateTime StartDate { get; set; }

        string Detail { get; set; }

        ProjectState State { get; set; }

        void CloseProject();
    }
}
