﻿using System.Linq;
using Bodoconsult.Core.Database.SqlClient.Test.Helpers;
using Bodoconsult.Core.Database.SqlClient.Test.MetaDataSample;
using NUnit.Framework;

namespace Bodoconsult.Core.Database.SqlClient.Test
{
    [TestFixture]
    public class UnitTestMetaDataSample
    {

        private CustomerService _db;

        [SetUp]
        public void Setup()
        {
            var conn = TestHelper.SqlServerConnectionString;

            _db = new CustomerService(conn);

        }

        [Test]
        public void TestGetAll()
        {

            // Act
            var result = _db.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Any());

        }

        [Test]
        public void TestGetById()
        {

            const int id = 28;

            // Act
            var result = _db.GetById(id);

            // Assert
            Assert.IsNotNull(result);

            Assert.AreEqual(id, result.CustomerId);
        }

        [Test]
        public void TestCount()
        {

            // Act
            var result = _db.Count();

            // Assert
            Assert.IsTrue(result > 0);

        }


        [Test]
        public void TestUpdate()
        {
            const int id = 28;

            string newName;

            // Act
            var customer = _db.GetById(id);

            if (customer.LastName == "Barnett")
            {
                newName = "Roberts";
            }
            else
            {
                newName = "Barnett";
            }

            customer.LastName = newName;

            // Act
            _db.Update(customer);

            // Assert
            var result = _db.GetById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(newName, result.LastName);

        }


        [Test]
        public void TestAddNew()
        {
            int id = _db.Count() + 1;

            var customer = TestDataHelper.NewCustomer();
            customer.CustomerId = id;

            // Act
            _db.AddNew(customer);

            // Assert
            var result = _db.GetById(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(customer.LastName, result.LastName);

        }
    }
}