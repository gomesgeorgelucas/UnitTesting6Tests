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

            service.AddContact("Nome", "9999999999", "name@email.com").Should().BeTrue();

            service.contacts.Should().HaveCount(1);
            service.contacts[0].Should().NotBeNull();
            service.contacts[0].Name.Should().Be("Nome");
            service.contacts[0].Phone.Should().Be("9999999999");
            service.contacts[0].Email.Should().Be("name@email.com");
        }

        [TestMethod()]
        public void AddInvalidContactTest()
        {
            var service = new ContactService();

            service.Invoking(c => c.AddContact(null, "9999999999", "name@email.com")).Should().Throw<ArgumentException>();
            service.Invoking(c => c.AddContact("Nome", null, "name@email.com")).Should().Throw<ArgumentException>();
            service.Invoking(c => c.AddContact("Nome", "9999999999", null)).Should().Throw<ArgumentException>();

        }

        [TestMethod()]
        public void ListContactsTest()
        {
            var service = new ContactService();

            service.AddContact("one", "9999999999", "name1@email.com");
            service.AddContact("two", "8888888888", "name2@email.com");
            service.AddContact("three", "7777777777", "name3@email.com");

            service.contacts.Should().HaveCount(3);

            service.ListContacts().Should().Be("Lista de contatos:\n1. one - 9999999999 - name1@email.com\n2. two - 8888888888 - name2@email.com\n3. three - 7777777777 - name3@email.com\n");

        }

        [TestMethod()]
        public void EmptyListContactsTest()
        {
            var service = new ContactService();

            service.ListContacts().Should().Be("Não há contatos cadastrados.");
        }

        [TestMethod()]
        public void UpdateValidContactTest()
        {
            var service = new ContactService();

            service.AddContact("name", "9999999999", "name@email.com").Should().BeTrue();

            service.UpdateContact(0, "name2", "9999999999", "name@email.com").Should().Be("Contato 'name2' atualizado com sucesso.");
        }

        [TestMethod()]
        public void UpdateInvalidContactTest()
        {
            var service = new ContactService();

            service.contacts.Should().HaveCount(0);
            service.UpdateContact(1, "", "", "").Should().Be("Índice inválido. Tente novamente.");
            service.UpdateContact(-1, "", "", "").Should().Be("Índice inválido. Tente novamente.");

        }

        [TestMethod()]
        public void RemoveContactFromListTest()
        {
            var service = new ContactService();

            service.AddContact("name", "9999999999", "name@email.com").Should().BeTrue();
            service.contacts.Should().HaveCount(1);
            service.RemoveContact(0).Should().Be("Contato 'name' removido com sucesso.");
            service.contacts.Should().HaveCount(0);
        }

        [TestMethod()]
        public void RemoveContactFromEmptyListTest()
        {
            var service = new ContactService();

            service.RemoveContact(0).Should().Be("Índice inválido. Tente novamente.");
            service.RemoveContact(-1).Should().Be("Índice inválido. Tente novamente.");
        }

        [TestMethod()]
        public void RemoveInvalidContactFromListTest()
        {
            var service = new ContactService();

            service.AddContact("name", "9999999999", "name@email.com").Should().BeTrue();
            service.contacts.Should().HaveCount(1);
            service.RemoveContact(-2).Should().Be("Índice inválido. Tente novamente.");
            service.contacts.Should().HaveCount(1);
            service.RemoveContact(3).Should().Be("Índice inválido. Tente novamente.");
            service.contacts.Should().HaveCount(1);
        }
    }
}