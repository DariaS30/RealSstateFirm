using BL;
using DAL;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using static BL.BLLExeptions;

namespace Tests
{
    public class VerifyInputServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsInputCorrect_WhenValidInput_shouldReturnTrue()
        {
            string pattern = "^(1F|2F|3F|PH)$";
            string value = "2F";

            bool result = VerifyInputService.IsInputCorrect(value, pattern);

            Assert.IsTrue(result);
        }

        [Test]
        public void IsInputCorrect_WhenInvalidInput_shouldReturnFalse()
        {
            string pattern = "^(1F|2F|3F|PH)$";
            string value = "One Floor";

            bool result = VerifyInputService.IsInputCorrect(value, pattern);

            Assert.IsFalse(result);
        }



    }
}