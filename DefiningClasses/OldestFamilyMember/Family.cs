using System.Collections.Generic;
using System.Linq;

public class Family
{
    List<Person> members;

    public Family()
    {
        this.Members = new List<Person>();
    }

    public void AddMember(Person familyMember)
    {
        this.Members.Add(familyMember);
    }

    public Person GetOldestMember()
    {
        return this.Members.OrderByDescending(x => x.Age).FirstOrDefault();
    }

    public List<Person> Members { get => members; private set => members = value; }
}