namespace _03_14ClassStudent
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StudentSpecialty
    {
        private string specialtyName;
        private string facultyNumber;

        public StudentSpecialty(string specialtyName, string facultyNumber)
        {
            this.SpecialtyName = specialtyName;
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get
            {
                return this.facultyNumber;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("FacultyNumber", "FacultyNumber can not be null or empty!");
                }

                this.facultyNumber = value;
            }
        }

        public string SpecialtyName
        {
            get
            {
                return this.specialtyName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("SpecialtyName", "SpecialtyName can not be null or empty!");
                }

                this.specialtyName = value;
            }
        }
    }
}