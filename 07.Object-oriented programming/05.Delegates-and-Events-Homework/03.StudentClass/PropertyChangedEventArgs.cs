namespace StudentClass
{
    using System;

    public class PropertyChangedEventArgs : EventArgs
    {
        private string propertyName;
        private dynamic oldValue;
        private dynamic newValue;

        public PropertyChangedEventArgs(string propertyName, dynamic oldValue, dynamic newValue)
        {
            this.propertyName = propertyName;
            this.oldValue = oldValue;
            this.newValue = newValue;
        }

        public string PropertyName
        {
            get
            {
                return this.propertyName;
            }
        }

        public dynamic OldValue 
        {
            get
            {
                return this.oldValue;
            }
        }

        public dynamic NewValue 
        {
            get 
            {
                return this.newValue;
            }
        }
     }
}
