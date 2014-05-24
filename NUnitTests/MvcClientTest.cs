using BusinessLogic;
using DataAccessors.Entity;
using Moq;
using MvcClient.Controllers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTests
{
    internal class TestBusinessLogic : IPersonBll
    {
        ICollection<Person> _persons = new LinkedList<Person>();

        public ICollection<Person> Persons
        {
            get { return _persons; }
            set { _persons = value; }
        }

        public IEnumerable<Person> GetPersons()
        {
            return _persons;
        }

        public Person GetPerson(object id)
        {
            return (from p in _persons where p.Id == (int)id select p).SingleOrDefault();
        }

        public void DeletePerson(object personId)
        {
            Person p = GetPerson(personId);
            _persons.Remove(p);
        }

        public void UpdatePerson(Person person)
        {
            Person old = GetPerson(person.Id);
            _persons.Add(person);
        }

        public void AddPerson(Person person)
        {
            _persons.Add(person);
        }

        public void Add(Person person)
        {
            _persons.Add(person);
        }
    }

    [TestFixture]
    public class MvcClientTest
    {
        [Test]
        public void PersonControllerTest()
        {

            TestBusinessLogic testBl = new TestBusinessLogic();
            testBl.Persons = new List<Person>()
            {
                new Person{Id=1, LastName="qwe", Name="qwe"},
                new Person{Id=2, LastName="qwe", Name="qwe"},
                new Person{Id=3, LastName="qwe", Name="qwe"},
                new Person{Id=4, LastName="qwe", Name="qwe"},
            };

            PersonController controller = new PersonController(testBl);
            controller.Create();
            controller.Details(4);
            controller.Index();
        }

    }
}
