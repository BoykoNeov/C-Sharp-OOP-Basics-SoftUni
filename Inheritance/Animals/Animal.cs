public abstract class Animal
{
    private int age;
    private string name;
    private string gender;

    protected Animal(string name, string age)
    {
            Name = name;
            Age = int.Parse(age);
            Gender = null;
    }

    protected Animal(string name, string age, string gender) : this(name, age)
    {
        Gender = gender;
    }

    public int Age
    {
        get { return age; }
        set { age = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    public abstract string ProduceSound();

    public override string ToString()
    {
        return string.Format(this.Name + " " + this.Age + " " + this.Gender);
    }

    public virtual bool IsValid()
    {
        if (this.Age <= 0)
        {
            return false;
        }

        if (this.Gender == null)
        {
            return false;
        }

        return true;
    }
}