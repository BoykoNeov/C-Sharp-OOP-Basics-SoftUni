using System.Linq;

public class AddRemoveCollection<T> : AddCollection<T>, IAddRemoveCollection<T>
{
    public override int Add(T element)
    {
        this.elements.Insert(0, element);
        return 0;
    }

    public virtual T Remove()
    {
        T element = this.elements.Last();
        this.elements.RemoveAt(this.elements.Count - 1);
        return element;
    }
}