using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SocialManager.Test
{
    [TestClass]
    public class PupilTests
    {
        [TestMethod()]
        public void Instantiate_EmptyPupil_FirstNameLastNameShouldBeNull()
        {
            Pupil pupil = new Pupil();
            Assert.IsNull(pupil.GetFirstName());
            Assert.IsNull(pupil.GetLastName());
        }

        [TestMethod()]
        public void SetLastName_WithName_GetLastNameShouldReturnSettedName()
        {
            Pupil pupil = new Pupil();
            pupil.SetLastName("Max");
            Assert.AreEqual("Max", pupil.GetLastName());
        }

        /// <summary>
        ///A simple test for GetFullName
        ///</summary>
        [TestMethod()]
        public void FullName_SetName_ShouldReturnCorrectFullName()
        {
            Pupil pupil = new Pupil();
            pupil.SetFirstName("Max");
            pupil.SetLastName("Muster");
            Assert.AreEqual("Max Muster", pupil.GetFullName());
        }

        [TestMethod()]
        public void FullName_WithoutSettedFirstNameAndLastName_ShouldReturnEmptyString()
        {
            Pupil pupil = new Pupil();
            Assert.AreEqual(String.Empty, pupil.GetFullName());
        }

        [TestMethod()]
        public void FullName_WithoutSettedFirstName_ShouldReturnLastName()
        {
            Pupil pupil = new Pupil();
            pupil.SetLastName("Muster");
            Assert.AreEqual("Muster", pupil.GetFullName());
        }

        [TestMethod()]
        public void FullName_WithoutSettedLastName_ShouldReturnFirstName()
        {
            Pupil pupil = new Pupil();
            pupil.SetFirstName("Max");
            Assert.AreEqual("Max", pupil.GetFullName());
        }

        [TestMethod()]
        public void SetCity_CityName_GetCityShouldReturnSettedName()
        {
            Pupil pupil = new Pupil();
            pupil.SetCity("Linz");
            Assert.AreEqual("Linz", pupil.GetCity());
        }

        [TestMethod()]
        public void SetZipCode_TestZipCode_GetZipCodeShouldReturnSettedZipCode()
        {
            Pupil pupil = new Pupil();
            pupil.SetZipCode("4020");
            Assert.AreEqual("4020", pupil.GetZipCode());
        }

        [TestMethod()]
        public void DateOfBirth_Set_GetterShouldReturnSettedDate()
        {
            DateTime expected = DateTime.Today;
            Pupil pupil = new Pupil();
            pupil.SetDateOfBirth(expected);
            Assert.AreEqual(expected, pupil.GetDateOfBirth());
        }

        [TestMethod()]
        public void IsFullOfAge_Today18_ShouldReturnTrue()
        {
            Pupil pupil = new Pupil();
            pupil.SetDateOfBirth(DateTime.Today.AddYears(-18));
            Assert.IsTrue(pupil.IsOfFullAge());
        }

        [TestMethod()]
        public void IsFullOfAge_Tomorrow18_ShouldReturnFalse()
        {
            Pupil pupil = new Pupil();
            pupil.SetDateOfBirth(DateTime.Today.AddYears(-18).AddDays(1));
            Assert.IsFalse(pupil.IsOfFullAge());
        }

        [TestMethod()]
        public void IsFullOfAge_Yesterday18_ShouldReturnTrue()
        {
            Pupil pupil = new Pupil();
            pupil.SetDateOfBirth(DateTime.Today.AddYears(-18).AddDays(-1));
            Assert.IsTrue(pupil.IsOfFullAge());
        }

        [TestMethod()]
        public void YearsOld_Yesterday16_ShouldReturn16()
        {
            Pupil pupil = new Pupil();
            pupil.SetDateOfBirth(DateTime.Today.AddYears(-16).AddDays(-1));
            Assert.AreEqual(16, pupil.GetYearsOld());
        }

        [TestMethod()]
        public void YearsOld_Today16_ShouldReturn16()
        {
            Pupil pupil = new Pupil();
            pupil.SetDateOfBirth(DateTime.Today.AddYears(-16).AddDays(-1));
            Assert.AreEqual(16, pupil.GetYearsOld());
        }

        [TestMethod()]
        public void YearsOld_Tomorrow16_ShouldReturn15()
        {
            Pupil pupil = new Pupil();
            pupil.SetDateOfBirth(DateTime.Today.AddYears(-16).AddDays(1));
            Assert.AreEqual(15, pupil.GetYearsOld());
        }

        [TestMethod()]
        public void LivesNearBy_IsNear_ShouldReturnTrue()
        {
            Pupil pupil = new Pupil();
            Pupil friend = new Pupil();
            pupil.SetZipCode("4060");
            friend.SetZipCode("4020");
            Assert.IsTrue(pupil.LivesNearBy(friend));
        }

        [TestMethod()]
        public void LivesNearBy_IsSameZipCode_ShouldReturnTrue()
        {
            Pupil pupil = new Pupil();
            Pupil friend = new Pupil();
            pupil.SetZipCode("4060");
            friend.SetZipCode("4060");
            Assert.IsTrue(pupil.LivesNearBy(friend));
        }

        [TestMethod()]
        public void LivesNearBy_IsNotNearBy_ShouldReturnFalse()
        {
            Pupil pupil = new Pupil();
            Pupil friend = new Pupil();
            pupil.SetZipCode("4060");
            friend.SetZipCode("4160");
            Assert.IsFalse(pupil.LivesNearBy(friend));
        }

        [TestMethod()]
        public void LivesNearBy_TooShortZipCode_ShouldReturnFalse()
        {
            Pupil pupil = new Pupil();
            Pupil friend = new Pupil();
            pupil.SetZipCode("4060");
            friend.SetZipCode("406");
            Assert.IsFalse(pupil.LivesNearBy(friend));
        }
    }
}