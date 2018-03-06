public abstract class Food
{
    private int quantity;

    public Food(int quantity)
    {
        this.Quatity = quantity;
    }

    public int Quatity
    {
        get
        {
            return this.quantity;
        }
        set
        {
            this.quantity = value;
        }
    }
}