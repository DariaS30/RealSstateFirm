using BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1
{
    [TestClass]
    public class VerifyInputServiceTest
    {
        [TestMethod]
        public void IsInputCorrect_should_return_true_after_cheking_value_with_pattern()
        {
            string pattern = "^(1F|2F|3F|PH)$";
            string value = "2F";

            bool result = VerifyInputService.IsInputCorrect(value, pattern);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInputCorrect_should_return_false_after_cheking_value_with_pattern()
        {
            string pattern = "^(1F|2F|3F|PH)$";
            string value = "One Floor";

            bool result = VerifyInputService.IsInputCorrect(value, pattern);

            Assert.IsFalse(result);
        }
    }
}
