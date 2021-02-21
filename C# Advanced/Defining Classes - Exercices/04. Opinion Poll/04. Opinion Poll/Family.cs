using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Family
{
    public List<Person> Members { get; set; }


    public void AddMember(Person person)
    {
        this.Members.Add(person);
    }
    public Family()
    {
        this.Members = new List<Person>();
    }

    public Person GetOldestMember()
    {
        Person person = this.Members.OrderByDescending(p => p.Age).FirstOrDefault();
        return person;
    }
}