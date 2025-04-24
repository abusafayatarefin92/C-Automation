using NUnit.Framework;
using Tests.Common;
using Utils.Reports;

namespace Tests.Tests
{
    internal class WebFormTests : TestBase
    {
        [Test]
        public void WriteToTextAreaTest()
        {
            ExtentReporting.LogInfo("Starting test - submit form");

            var text = Guid.NewGuid().ToString();
            var expectedMessage = "Received!";

            var message = WebForm.WriteToTextArea(text).SubmitForm().GetMessage();

            Assert.That(message, Is.EqualTo(expectedMessage));
        }

        [Test]
        public void WriteToTextAreaNegativeTest()
        {
            ExtentReporting.LogInfo("Starting negative test - submit form");

            var text = Guid.NewGuid().ToString();
            var expectedMessage = "Received Failed!";

            var message = WebForm.WriteToTextArea(text).SubmitForm().GetMessage();

            Assert.That(message, Is.EqualTo(expectedMessage));
        }
    }
}
