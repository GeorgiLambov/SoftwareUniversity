using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;

namespace SoftwareAcademy
{
    public interface ITeacher
    {
        string Name { get; set; }
        void AddCourse(ICourse course);
        string ToString();
    }

    public class Teacher : ITeacher
    {
        private string name;
        private ICollection<ICourse> courses;

        public Teacher(string name)
        {
            this.Name = name;
            this.courses = new List<ICourse>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Teacher name cannot be null.");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Teacher name cannot be empty string or a sequence of white spaces!");
                }

                this.name = value;
            }
        }

        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            // Teacher: Name=(teacher name); Courses=[(course names – comma separated)]

            StringBuilder output = new StringBuilder();
            output.AppendFormat("Teacher: Name={0}", this.Name);

            if (this.courses.Count > 0)
            {
                //output.AppendFormat("; Courses=[{0}]",
                //    string.Join(", ", this.courses.Select(course => course.Name)));

                output.Append("; Courses=[");
                foreach (var cousre in this.courses)
                {
                    output.AppendFormat("{0}, ", cousre.Name);
                }

                output.Length -= 2;
                output.Append("]");
            }

            return output.ToString();
        }
    }

    public interface ICourse
    {
        string Name { get; set; }

        ITeacher Teacher { get; set; }

        void AddTopic(string topic);

        string ToString();
    }

    public  class Course : ICourse
    {
        private string name;
        private ICollection<string> topics;

        protected Course(string name, ITeacher teacher)
        {
            this.Name = name;
            this.Teacher = teacher;
            this.topics = new LinkedList<string>();
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Course name cannot be null!!!");
                }
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Course name cannot be empty or a sequence of white space!");
                }

                this.name = value;
            }
        }

        public ITeacher Teacher { get; set; }  // has no teacher

        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}: Name={1}", this.GetType().Name, this.Name);

            if (this.Teacher != null)
            {
                result.AppendFormat("; Teacher={0}", this.Teacher.Name);
            }
            if (this.topics.Count > 0)
            {
                result.AppendFormat("; Topics=[{0}]", string.Join(", ", this.topics));
            }

            return result.ToString();
        }
    }

    public interface ILocalCourse : ICourse
    {
        string Lab { get; set; }
    }

    public class LocalCourse : Course, ILocalCourse
    {
        private string lab;

        public LocalCourse(string name, ITeacher teacher, string lab)
            : base(name, teacher)
        {
            this.Lab = lab;
        }

        public string Lab
        {
            get { return this.lab; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Local course laboratory cannot be null.");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Local course laboratory cannot be empty string or a sequence of white spaces!");
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("; Lab={0}", this.Lab);
            return result.ToString();

            //return base.ToString() + "; Lab=" + this.Lab;
        }
    }

    public interface IOffsiteCourse : ICourse
    {
        string Town { get; set; }
    }

    public class OffsiteCourse : Course, IOffsiteCourse
    {
        private string town;

        public OffsiteCourse(string name, ITeacher teacher, string town)
            : base(name, teacher)
        {
            this.Town = town;
        }

        public string Town
        {
            get { return this.town; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value", "Offsite course town cannot be null.");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentOutOfRangeException("Offsite course town cannot be empty string or a sequence of white spaces!");
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder(base.ToString());
            result.AppendFormat("; Town={0}", this.town);
            return result.ToString();

            //return base.ToString() + "; Lab=" + this.Lab;
        }
    }

    public interface ICourseFactory
    {
        ITeacher CreateTeacher(string name);
        ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab);
        IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town);
    }


    public class CourseFactory : ICourseFactory
    {
        public ITeacher CreateTeacher(string name)
        {
            return new Teacher(name);
        }

        public ILocalCourse CreateLocalCourse(string name, ITeacher teacher, string lab)
        {
            return new LocalCourse(name, teacher, lab);
        }

        public IOffsiteCourse CreateOffsiteCourse(string name, ITeacher teacher, string town)
        {
            return new OffsiteCourse(name, teacher, town);
        }
    }

    public class SoftwareAcademyCommandExecutor
    {
        public static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        private static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using SoftwareAcademy;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {"
                        + csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}
