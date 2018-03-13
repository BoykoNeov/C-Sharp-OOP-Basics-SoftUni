public abstract class Tyre
{
    double degradation;

    protected Tyre(double hardness)
    {
        this.Hardness = hardness;
        this.Degradation = 100;
    }

    public virtual string Name { get; private set; }
    public double Hardness { get; private set; }

    public virtual double Degradation
    {
        get
        {
            return this.degradation;
        }
        protected set
        {
            if (value < 0)
            {
                throw new System.ArgumentException("Blown Tyre");
            }

            this.degradation = value;

        }
    }

    public virtual void ReduceDegradation()
    {
        this.Degradation -= this.Hardness;
    }
}

//Every type of tyre has different hardness of the compound.It also has a degradation level, which is its lifetime:
//Name – a string
//Hardness –  a floating-point number
//Degradation - a floating-point number
//Every tyre starts with 100 points degradation and drops down towards 0. Upon each lap it’s degradation is
//    reduced by the value of the hardness.If a tyre’s degradation drops below 0 points the tyre blows up and the driver cannot continue the race. If a tyre blows up you should throw an exeption.