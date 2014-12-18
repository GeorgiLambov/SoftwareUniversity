namespace StringDisperser
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable<char>
    {
        private StringBuilder allString;

        public StringDisperser(params string[] strings)
        {
            this.AllString = new StringBuilder();
            foreach (var str in strings)
            {
                this.AllString.Append(str);
            }
        }

        public StringBuilder AllString
        {
            get
            {
                return this.allString;
            }

            set
            {
                if (null == value)
                {
                    throw new ArgumentNullException("String can not be null!");
                }

                this.allString = value;
            }
        }

        public override string ToString()
        {
            return this.allString.ToString();
        }

        public override bool Equals(object obj)
        {
            var stringDisperser = obj as StringDisperser; // same (StringDisperser)obj
            if ((object)stringDisperser == null)  // == is not overide "=="
            {
                return false;
            }

            return this.AllString.ToString().Equals(stringDisperser.AllString.ToString());
        }

        public static bool operator ==(StringDisperser first, StringDisperser second)
        {
            return StringDisperser.Equals(first, second);
        }

        public static bool operator !=(StringDisperser first, StringDisperser second)
        {
            return !StringDisperser.Equals(first, second);
        }

        public override int GetHashCode()
        {
            return this.AllString.GetHashCode();
        }

        public object Clone()
        {
            StringDisperser newStringDisperser = this.MemberwiseClone() as StringDisperser;
            if (null == newStringDisperser)
            {
                throw new ArgumentNullException("Object can not be casted to type StringDisperser!");
            }

            newStringDisperser.allString = new StringBuilder().Append(this.allString.ToString());

            return newStringDisperser;
        }

        public int CompareTo(StringDisperser other)
        {
            return this.allString.ToString().CompareTo(other.allString.ToString());
        }



        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.allString.Length; i++)
            {
                yield return this.allString[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}