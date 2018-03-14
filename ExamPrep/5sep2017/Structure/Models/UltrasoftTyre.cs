public class UltrasoftTyre : Tyre
{
    private double degradation;
    private double grip;

    public UltrasoftTyre(double hardness, double grip) : base(hardness)
    {
        this.Grip = grip;
    }

    public override string Name => "Ultrasoft";
    public double Grip
    {
        get
        {
            return this.grip;
        }
        private set
        {
            if (value <= 0)
            {
                throw new System.ArgumentException();
            }
            else
            {
                this.grip = value;
            }
        }
    }

    public override double Degradation
    {
        get
        {
            return this.degradation;
        }
        protected set
        {
            if (value < 30)
            {
                throw new System.Exception("Blow up");
            }
            else
            {
                this.degradation = value;
            }
        }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}

//Because it’s ultra-soft this type of tyre has an additional property:
//Grip –  a positive floating-point number
//The name of this tyre is always “Ultrasoft”.
//Upon each lap, it’s Degradation drops down by its Hardness summed with its Grip.Also, the ultra-soft tyre blows up when tyre’s Degradation drops below 30 points.