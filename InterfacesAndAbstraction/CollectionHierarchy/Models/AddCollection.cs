using System.Collections.Generic;

public class AddCollection<T> : IAddCollection<T>
{
    protected List<T> elements = new List<T>();

    public virtual int Add(T element)
    {
        this.elements.Add(element);
        return this.elements.Count - 1;
    }

    public virtual IReadOnlyList<T> Elements
    {
        get
        {
            return this.elements;
        }
    }
}