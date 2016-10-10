using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Mocking
{
    [TestClass]
    public class MockTests
    {

        [TestMethod]
        public void AfterLoginAdminCanManageEmployees()
        {
            //Arrange
            var admin = new User() { UserName = "sist@eal.dk", Password = "!QAZ2wsx" };

            var mockLogin = new Mock<ILoginModule>();
            mockLogin.Setup(x => x.Login(admin))
                .Callback(() => { admin.Rights = Rights.Full; });

            //Act
            mockLogin.Object.Login(admin);

            //Assert
            Assert.AreEqual(Rights.Full, admin.Rights);
        }

        [TestMethod]
        public void AfterLoginNonAdminCannotManageOtherEmployees()
        {
            //Arrange
            var nonAdmin = new User() { UserName = "alhe@eal.dk", Password = "1234qwER" };

            var mockLogin = new Mock<ILoginModule>();
            mockLogin.Setup(x => x.Login(nonAdmin))
                .Callback(() => nonAdmin.Rights = Rights.None);

            //Act
            mockLogin.Object.Login(nonAdmin);

            //Assert
            Assert.AreEqual(Rights.None, nonAdmin.Rights);
        }

        [TestMethod]
        public void AfterLoginAdminCanViewEmployees()
        {
            //Arrange
            var admin = new User() { UserName = "sist@eal.dk", Password = "!QAZ2wsx" };

            var mockLogin = new Mock<ILoginModule>();
            mockLogin.Setup(x => x.Login(admin))
                .Callback(() => { admin.Rights = Rights.Full; });

            //Act
            mockLogin.Object.Login(admin);
            string result = admin.ViewAllEmployees();

            //Assert
            Assert.AreEqual("Here is the list", result);
        }

        [TestMethod]
        public void CanCalculateWeeklySalaryOfSingleEmployee()
        {
            //Arrange
            const int id = 1;
            const int hours = 42;

            var mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.LoadEmployee(id)).Returns(() => new Employee() { Id = id, Name = "Hans", Type = "Teacher", Wage = 1000 });

            double expectedResult = (1000 * 42);
            double weeklySalary = 0.0d;

            //Act
            Employee e = mock.Object.LoadEmployee(id);
            weeklySalary = e.CalculateWeeklySalary(hours, e.Wage);

            //Assert
            Assert.AreEqual(expectedResult, weeklySalary);

        }

        [TestMethod]
        public void CanCalculateTotalWeeklySalaryOfAllEmployees()
        {
            //Arrange
            const int hours = 42;

            var mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.FindAllEmployees()).Returns(() => new List<Employee> { new Employee() { Id = 1, Name = "Hans", Type = "Teacher", Wage = 1000 }, new Employee() { Id = 2, Name = "Tove", Type = "Teacher", Wage = 750 }, new Employee() { Id = 3, Name = "Lene", Type = "Teacher", Wage = 500 } });

            double expectedResult = (1000 * 42) + (750 * 42) + (500 * 42);
            double totalWeeklySalary = 0.0d;

            //Act
            List<Employee> employees = mock.Object.FindAllEmployees();
            foreach (var e in employees)
            {
                totalWeeklySalary += e.CalculateWeeklySalary(hours, e.Wage);
            }

            //Assert
            Assert.AreEqual(expectedResult, totalWeeklySalary);
        }

        [TestMethod]
        public void AfterMailSentMessageCanBeFoundInEmployeesNumReceivedMessages()
        {
            //Arrange
            const int id = 1;

            var mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.LoadEmployee(id))
                .Returns(() => new Employee() { Id = id, Name = "Hans", Type = "Teacher", Wage = 1000, MailBox = new MailBox() { NumReceivedMessages = 0 } });

            Employee e = mock.Object.LoadEmployee(id);
            var message = new Mail() { Content = "Hello " + e.Name + " Your paycheck is wrong!" };

            var mockMail = new Mock<IMailModule>();
            mockMail.Setup(x => x.SendMail(message, e))
               .Callback((Mail o, Employee em) =>
               {
                   o.Content = "Hello " + e.Name + " Your paycheck is wrong!";
                   em.MailBox.Add(o);
               });

            //Act  
            mockMail.Object.SendMail(message, e);
            string s = e.MailBox.GetLatestMessageText();

            //Assert            
            Assert.AreEqual(1, e.MailBox.NumReceivedMessages);
            Assert.AreEqual("Hello " + e.Name + " Your paycheck is wrong!", e.MailBox.GetLatestMessageText());
        }



        [TestMethod]
        public void CanCalulateAverageWeeklySaleryPerEmployee()
        {
            //implement your own logic
            //use mocks
            throw new NotImplementedException();
        }


        [TestMethod]
        public void AfterMailSentNumMessagesCreatedHasBeenIncrementedByOne()
        {
            //Arrange
            var admin = new User() { UserName = "sist@eal.dk", Password = "!QAZ2wsx", NumMessagesCreated = 0 };
            var message = new Mail() { Content = "Hello Mom! Hope you are doing well" };
            var mock = new Mock<IEmployeeRepository>();
            mock.Setup(m => m.LoadEmployee(1)).Returns(() => new Employee() { Id = 1, Name = "Karen", Type = "Mom", Wage = 20 });
            Employee e = mock.Object.LoadEmployee(1);

            var mockMail = new Mock<IMailModule>();
            mockMail.Setup(x => x.SendMail(message, e)).Callback(() => admin.NumMessagesCreated = 1);

            //Act
            mockMail.Object.SendMail(message, e);

            //Assert
            Assert.AreEqual(1, admin.NumMessagesCreated);
        }

        //[TestMethod]
        //public void AfterLoginAdminCanEditEmployeeName()
        //{
        //    //Arrange
        //    var admin = new User() { UserName = "sist@eal.dk", Password = "!QAZ2wsx" };

        //    var mockLogin = new Mock<ILoginModule>();
        //    mockLogin.Setup(x => x.Login(admin))
        //        .Callback(() => { admin.Rights = Rights.Full; });

        //    var mock = new Mock<IEmployeeRepository>();
        //    mock.Setup(m => m.LoadEmployee(1)).Returns(() => new Employee() { Id = 1, Name = "Peter", Type = "Slave", Wage = 20 });
        //    Employee e = mock.Object.LoadEmployee(1);

        //    //Act
        //    mockLogin.Object.Login(admin);
        //    admin.EditEmployeeName(e.Name, "Simon");

        //    //Assert
        //    Assert.AreEqual("Simon", e.Name);
        //}

       // [TestMethod]
        //public void AfterLoginAdminCanEditEmployeeWage()
        //{
        //    //Arrange
        //    var admin = new User() { UserName = "sist@eal.dk", Password = "!QAZ2wsx" };

        //    var mockLogin = new Mock<ILoginModule>();
        //    mockLogin.Setup(x => x.Login(admin))
        //        .Callback(() => { admin.Rights = Rights.Full; });

        //    var mock = new Mock<IEmployeeRepository>();
        //    mock.Setup(m => m.LoadEmployee(1)).Returns(() => new Employee() { Id = 1, Name = "Peter", Type = "Slave", Wage = 20 });
        //    Employee e = mock.Object.LoadEmployee(1);

        //    //Act
        //    mockLogin.Object.Login(admin);
        //    admin.EditEmployeeWage(e.Wage, 1000);

        //    //Assert
        //    Assert.AreEqual("Simon", e.Name);
        //}
        [TestMethod]
        public void DoYourOwnLogic1()
        {
            //implement your idea and own logic
            //use mocks
            throw new NotImplementedException();
        }
        [TestMethod]
        public void DoYourOwnLogic2()
        {
            //implement your idea and own logic
            //use mocks
            throw new NotImplementedException();
        }
        [TestMethod]
        public void DoYourOwnLogic3()
        {
            //implement your idea and own logic
            //use mocks
            throw new NotImplementedException();
        }

        [TestMethod]
        public void DoYourOwnLogic4()
        {
            //implement your idea and own logic
            //use mocks
            throw new NotImplementedException();
        }
        [TestMethod]
        public void DoYourOwnLogic5()
        {
            //implement your idea and own logic
            //use mocks
            throw new NotImplementedException();
        }
    }
}
