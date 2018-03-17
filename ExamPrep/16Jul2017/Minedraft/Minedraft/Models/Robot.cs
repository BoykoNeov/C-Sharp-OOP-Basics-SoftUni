public abstract class Robot
{
    private string id;
    private string type;

    public string Type
    {
        get { return type; }
        protected set { type = value; }
    }


    protected Robot(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get
        {
            return this.id;
        }

        protected set
        {
            this.id = value;
        }
    }
}