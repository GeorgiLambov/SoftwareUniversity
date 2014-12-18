using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
public static class Storage
{
    public static void SavePath(string fileName, Path3D path)
    {
        try
        {
            using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.GetEncoding("UTF-8")))
            {
                sw.WriteLine(path.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw ex.InnerException;
        }

    }

    public static Path3D LoadPaths(string fileName)
    {
        try
        {
            string input = File.ReadAllText(fileName);

            string pattern = @"X=(.+?), Y=(.+?), Z=(.+?)";
            var reg = new Regex(pattern);
            var matchs = reg.Matches(input);

            Path3D path = new Path3D();
            foreach (Match match in matchs)
            {
                double x = double.Parse(match.Groups[1].Value);
                double y = double.Parse(match.Groups[2].Value);
                double z = double.Parse(match.Groups[3].Value);

                Point3D point = new Point3D(x, y, z);
                path.AddPoint(point);
            }
            return path;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw ex.InnerException;
        }
    }

}

