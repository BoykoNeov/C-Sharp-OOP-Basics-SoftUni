public class Rectangle
{
    public string Id { get; set; }
    private double Width { get; set; }
    private double Height { get; set; }
    private double X1 { get; set; }
    private double Y1 { get; set; }

    public Rectangle(string id, double width, double height, double topLeftX, double topLeftY)
    {
        this.Id = id;
        this.Width = width;
        this.Height = height;
        this.X1 = topLeftX;
        this.Y1 = topLeftY;
    }


    public bool DoIntersectWith(Rectangle intersectingRectangle)
    {
        double thisX2 = this.X1 + this.Width;
        double thisY2 = this.Y1 - this.Height;
        double IntersectX2 = intersectingRectangle.X1 + intersectingRectangle.Width;
        double IntersectY2 = intersectingRectangle.Y1 - intersectingRectangle.Height;


        if (this.X1 > IntersectX2 || thisX2 < intersectingRectangle.X1)
        {
            return false;
        }

        if (this.Y1 < IntersectY2 || thisY2 > intersectingRectangle.Y1)
        {
            return false;
        }

        return true;
    }
}