namespace DistanceCalculatorRESTClient
{
    using System;
    using System.Net;

    public class DistanceCalculator
    {
        public static void Main()
        {
            using (WebClient client = new WebClient())
            {
                var response = client.UploadString("http://localhost:20645/CalcDistance?startPoint.X={4}&startPoint.Y={3}&endPoint.X={5}&endPoint.Y={2}", "POST", "");

                Console.WriteLine(response);
            }
        }
    }
}
