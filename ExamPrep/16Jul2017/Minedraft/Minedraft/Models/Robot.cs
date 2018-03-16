public abstract class Robot
{
    private string id;

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