using BusinessLogic;
using DataAccessors.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebClient.Models
{
    public class PersonBlStub: IPersonBll
    {
        List<Person> _list;

        public PersonBlStub()
        {
            _list = new List<Person>()
            {
                new Person{Id=1, Name="qwe1", LastName="asd1"},
                new Person{Id=2, Name="qwe2", LastName="asd2"},
                new Person{Id=3, Name="qwe3", LastName="asd3"},
                new Person{Id=4, Name="qwe4", LastName="asd4"},
            };
        }

        public IEnumerable<DataAccessors.Entity.Person> GetPersons()
        {
            return _list;
        }

        public DataAccessors.Entity.Person GetPerson(object id)
        {
            return (from p in _list where p.Id == (int)id select p).SingleOrDefault();
        }

        public void DeletePerson(object personId)
        {
            _list.Remove(GetPerson(personId));
        }

        public void UpdatePerson(DataAccessors.Entity.Person person)
        {
            Person p = GetPerson(person.Id);
            p.DayOfBirth = person.DayOfBirth;
            p.LastName = person.LastName;
            p.Name = person.Name;
            p.Phones = person.Phones;            
        }

        public void AddPerson(DataAccessors.Entity.Person person)
        {
            if(GetPerson(person.Id) == null)
                _list.Add(person);
            else
            {
                DeletePerson(person.Id);
                _list.Add(person);
            }
        }
    }
}