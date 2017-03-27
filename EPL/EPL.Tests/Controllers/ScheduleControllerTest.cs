using System;
using System.Collections.Generic;
using System.Linq;
using EPL.DataModel;
using EPL.Repository;
using NUnit.Framework;

namespace EPL.Tests.Controllers
{
    [TestFixture]
    class ScheduleControllerTest
    {
        private EplRepo _repo;

        [SetUp]
        public void Setup()
        {
            _repo = new EplRepo();
            _repo.DeleteSchedule(1);
        }

        [Test]
        public void AddandGet()
        {
            _repo.UpSertSchedule(new Schedule {Id = 1,Time = DateTime.Now});
            var result = _repo.GetAllSchedule();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result.First().Id);
        }

        [TearDown]
        public void Teardown()
        {
            _repo.DeleteSchedule(1);
        }
    }
}
