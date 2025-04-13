using NUnit.Framework;
using Tests.Common;

namespace Tests.Tests
{
    internal class WebFormTests : TestBase
    {
        [Test]
        public void WriteToTextAreaTest()
        {
            var text = Guid.NewGuid().ToString();

            var message = WebForm.WriteToTextArea(text).SubmitForm().GetMessage();
        }
    }
}
