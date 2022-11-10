using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MSTests
{
    [TestClass]
    public class VerifyInputServiceTest
    {
        [TestMethod]
        public void IsInputCorrect_WhenValidInput_shouldReturnTrue()
        {
            string pattern = "^(1F|2F|3F|PH)$";
            string value = "2F";

            bool result = VerifyInputService.IsInputCorrect(value, pattern);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInputCorrect_WhenInvalidInput_shouldReturnFalse()
        {
            string pattern = "^(1F|2F|3F|PH)$";
            string value = "One Floor";

            bool result = VerifyInputService.IsInputCorrect(value, pattern);

            Assert.IsFalse(result);
        }
    }
}
