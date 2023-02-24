using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Tests
{
    [TestClass()]
    public class ContactServiceTests
    {
        [TestMethod()]
        public void AddValidContactTest()
        {  
            var service = new ContactService();

            service.AddContact("Nome", "9999999999", "name@email.com");

            service.contacts.Should().HaveCount(1);
            service.contacts[0].Should().NotBeNull();
            service.contacts[0].Name.Should().Be("Nome");
            service.contacts[0].Phone.Should().Be("9999999999");
            service.contacts[0].Email.Should().Be("name@email.com");
        }

        public void AddInvalidContactTest()
        {
            var service = new ContactService();
        }

        [TestMethod()]
        public void ListContactsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateContactTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveContactTest()
        {
            Assert.Fail();
        }
    }
}