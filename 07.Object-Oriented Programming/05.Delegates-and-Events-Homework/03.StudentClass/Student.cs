namespace StudentClass
{
    using System;

    public class Student
    {
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name 
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Name cannot be empty!");
                }

                this.OnPropertyChanged("Name", value, this.name);
                this.name = value;
            }
        }

        public int Age 
        { 
            get 
            {
                return this.age;
            }
            
            set
            {
                if (value > 100 || value < 0)
                {
                    throw new IndexOutOfRangeException("Age should be in ArgumentOutOfRangeException [1...100]");
                }

                this.OnPropertyChanged("Age", value, this.age);
                this.age = value;
            }
        }

        protected void OnPropertyChanged(string propertyName, dynamic oldValue, dynamic newValue)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChangedEventArgs arg = new PropertyChangedEventArgs(propertyName, oldValue, newValue);
                this.PropertyChanged(this, arg);
            }
        }
    }
}
