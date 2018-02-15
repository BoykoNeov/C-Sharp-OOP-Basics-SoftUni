public class Square : Rectangle
{
    public override int Length
    {
        get
        {
            return this.length;
        }
        set
        {
            this.length = value;
            this.height = value;
        }
    }

    private int length;
    private int height;

    public override int Height
    {
        get
        {
            return this.height;
        }
        set
        {
            this.length = value;
            this.height = value;
        }
    }

    public Square(int side) : base(side, side)
    {
    }
}