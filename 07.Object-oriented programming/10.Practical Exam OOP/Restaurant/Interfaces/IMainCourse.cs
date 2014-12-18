namespace RestaurantManager.Interfaces
{
    using RestaurantManager.Models;

    public interface IMainCourse : IMeal
    {
        MainCourseType Type { get; }
    }
}