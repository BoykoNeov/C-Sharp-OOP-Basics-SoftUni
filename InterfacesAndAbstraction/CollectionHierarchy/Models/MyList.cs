public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
{
    public int Used
    {
        get
        {
            return this.elements.Count;
        }
    }

    public override T Remove()
    {
        T element = this.elements[0];
        this.elements.RemoveAt(0);
        return element;
    }
}