using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MvcClient.Controllers;
using DataAccessors.Entity;
using DataAccessors.Accessors;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject
{
    [TestClass]
    public class MvcClientTest
    {
        [TestMethod]
        public void MvcTestMethod()
        {
            Mock<IAccessor<Person>> personMock = new Mock<IAccessor<Person>>();
            personMock.Setup(a => a.GetAll()).Returns(new List<Person>());
            personMock.Setup(a => a.GetById(It.IsAny<object>())).Returns(new Person());

            Mock<IAccessor<Phone>> phoneMock = new Mock<IAccessor<Phone>>();

            //PersonController pc = new PersonController(personMock.Object, phoneMock.Object);
           // pc.Index();
        }
    }
}
