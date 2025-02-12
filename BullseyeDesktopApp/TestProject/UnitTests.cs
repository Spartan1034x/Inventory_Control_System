using NUnit.Framework;
using BullseyeDesktopApp;
using BullseyeDesktopApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Windows.Forms;

namespace TestProject
{
    [TestFixture]
    public class Tests
    {
        BullseyeDesktopApp.Tests tests;
       // BullseyeContext context;

        [SetUp]
        public void Setup()
        {
            tests = new BullseyeDesktopApp.Tests();
            //context = new BullseyeDesktopApp.Models.BullseyeContext();
        }

        /*
        [TearDown]
        public void Tearddown()
        {
            context.Dispose();
        } */

        //           DELIVERY DATE TESTS
        //
        // NON SPECIFIC DATE TESTS
        [TestCase("Tuesday")]
        [TestCase("Monday")]
        [TestCase("Sunday")]
        public void NonSpecificDate(string day)
        {
            // Arrange
            DateTime currentTime = DateTime.Now;

            // Act
            DateTime returnedDate = tests.CalculateDeliveryDate(day);

            // Assert: The returned date is in the future.
            Assert.Greater(returnedDate, currentTime, "The delivery date should be in the future.");

            // Day of week is correct.
            DayOfWeek expectedDay = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), day, true);
            Assert.That(returnedDate.DayOfWeek, Is.EqualTo(expectedDay), "The delivery date should be on the expected day of the week.");

            // Returned time is exactly 8:00 AM.
            Assert.That(returnedDate.Hour, Is.EqualTo(8), "The delivery date hour should be 8 AM.");
            Assert.That(returnedDate.Minute, Is.EqualTo(0), "The delivery date minute should be 0.");
            Assert.That(returnedDate.Second, Is.EqualTo(0), "The delivery date second should be 0.");
        }

        //                 
        // EXACT DATE TESTS **** Date will have to change in future to pass
        [TestCase("Tuesday", "2025-02-11T08:00:00")]
        [TestCase("Monday", "2025-02-17T08:00:00")]
        [TestCase("Sunday", "2025-02-16T08:00:00")] 
        public void ExactDate(string day, string expectedStr)
        {
            // Arrange
            DateTime expected = DateTime.Parse(expectedStr);

            // Act
            DateTime result = tests.CalculateDeliveryDate(day);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }


        //               CAN SUBMIT ORDERE TESTS
        //               
        //
        /*
        [TestCase(1, false)]
        [TestCase(4, true)]
        public void CanSubmit(int storeID, bool expectedRes)
        {

            var result = BullseyeDesktopApp.StaticHelpers.DBOperations.CanSubmitOrder(storeID);

            // Assert
            Assert.That(result, Is.EqualTo(expectedRes));

        } */


    }
}