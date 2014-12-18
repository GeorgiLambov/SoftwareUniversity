namespace SoftUniLearningSystem.Data
{
    public class OnlineStudent : CurrentStudent
    {
        public OnlineStudent(string fName, string lName, string id, int stdNumber, double averageGrade)
            : base(fName, lName, id, stdNumber, averageGrade)
        {
        }
    }
}
