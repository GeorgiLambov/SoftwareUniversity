namespace CalcDistance
{
    using System.ServiceModel;

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        double CalcDistance(Point startPoint, Point endPoint);
    }
}
