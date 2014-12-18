using System;
using System.Text;

[Version(1.0)]
public class GenericList<T> where T : IComparable<T>
{
    private const int DefaultCapacity = 16;

    private T[] elements;
    private int count;

    public GenericList(int capacity = DefaultCapacity)
    {
        this.elements = new T[capacity];
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }

            return this.elements[index];
        }

        set
        {
            if (index < 0 || index >= this.count)
            {
                throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
            }

            this.elements[index] = value;
        }
    }

    public int Count
    {
        get { return this.count; }
    }


    public int Capacity
    {
        get { return this.elements.Length; }
    }

    public void Add(T element)
    {
        if (this.count > Capacity - 1)
        {
            this.AutoGrow();
        }

        this.elements[this.count] = element;
        this.count++;
    }

    public void Remove(int index)
    {
        try
        {
            if (index < this.count - 1)
            {
                for (int i = index; i < this.count - 1; i++)
                {
                    this.elements[i] = this.elements[i + 1];
                }

                this.count--;
            }
            else if (index == this.Count - 1)
            {
                this.count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        catch (IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException(String.Format("Invalid index: {0}.", index));
        }
    }

    public void Insert(int index, T value)
    {
        try
        {
            if (index > this.Count)
            {
                throw new IndexOutOfRangeException();
            }

            this.Add(this.elements[Count - 1]);

            for (int i = this.Count - 1; i >= index; i--)
            {
                this.elements[i + 1] = this.elements[i];
            }

            this.elements[index] = value;
        }
        catch (IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException("Index was outside the bounds of the list.");
        }
    }

    public void Clear()
    {
        this.elements = new T[DefaultCapacity];
        this.count = 0;
    }

    public int IndexOf(T element)
    {
        for (int i = 0; i < this.count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                return i;
            }
        }

        return -1;
    }

    public bool Contains(T element)
    {
        if (this.IndexOf(element) != -1)
        {
            return true;
        }

        return false;
    }

    public int Find(T value, int startIndex = 0)
    {
        int valueIndex = -1;
        try
        {
            for (int i = startIndex; i < this.Count; i++)
            {
                if (this.elements[i].Equals(value))
                {
                    valueIndex = i;
                    break;
                }
            }
        }
        catch (IndexOutOfRangeException)
        {
            throw new IndexOutOfRangeException("Index was outside the bounds of the list.");
        }

        return valueIndex;
    }

    public T Max()
    {
        if (this.count < 1)
        {
            throw new InvalidOperationException("The list is empty");
        }

        T max = this.elements[0];
        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(max) > 0)
            {
                max = elements[i];
            }
        }
        return max;
    }

    public T Min()
    {
        if (this.count < 1)
        {
            throw new InvalidOperationException("The list is empty");
        }

        T min = this.elements[0];
        for (int i = 1; i < this.count; i++)
        {
            if (this.elements[i].CompareTo(min) < 0)
            {
                min = elements[i];
            }
        }
        return min;
    }

    private void AutoGrow()
    {
        int capacity = this.elements.Length * 2;
        var arr = new T[capacity];
        for (int i = 0; i < this.count; i++)
        {
            arr[i] = this.elements[i];
        }
        this.elements = arr;
    }

    public override string ToString()
    {
        if (this.count == 0)
        {
            return "";
        }
        var result = new StringBuilder();
        for (int i = 0; i < this.count - 1; i++)
        {
            result.Append(this.elements[i] + ", ");
        }
        result.Append(this.elements[this.count - 1]);
        return result.ToString();
    }
}

