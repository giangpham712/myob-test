using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestPlatform.Common.ExtensionFramework.Utilities;
using MYOB.CodingTest.Employee;
using NUnit.Framework;

namespace MYOB.CodingTest.Tests
{
    public class EmployeeParserTests
    {
        [Test]
        public void ParseEmployee_NullOrEmptyString_ThrowsException()
        {
            var reader = new EmployeeParser();
            var exception = Assert.Throws<EmployeeParseException>(() => reader.ParseEmployee(null));
            Assert.AreEqual("Invalid employee input", exception.Message);
        }

        [TestCase("\"Mary Song\"")]
        [TestCase("\"Mary Song\" ABC")]
        [TestCase("Mary Song 120000")]
        public void ParseEmployee_InputMissingSalary_ThrowsException(string input)
        {
            var reader = new EmployeeParser();
            var exception = Assert.Throws<EmployeeParseException>(() => reader.ParseEmployee(input));
            Assert.AreEqual("Invalid employee input", exception.Message);
        }

        [TestCase("\"Mary Song\" 60000", "Mary Song", 60000)]
        [TestCase("Mary 55000", "Mary", 55000)]
        [TestCase("\"John\" 66666", "John", 66666)]
        public void ParseEmployee_ValidInput_ReturnsEmployee(string input, string expectedName, int expectedAnnualSalary)
        {
            var reader = new EmployeeParser();
            var employee = reader.ParseEmployee(input);

            Assert.AreEqual(expectedName, employee.Name);
            Assert.AreEqual(expectedAnnualSalary, employee.AnnualSalary);
        }
    }
}
