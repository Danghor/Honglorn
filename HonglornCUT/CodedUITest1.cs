using System.IO;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HonglornCUT
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class CodedUITest1
    {
        public TestContext TestContext { get; set; }

        readonly UIMap uiMap = new UIMap();

        ApplicationUnderTest app;

        public CodedUITest1() { }

        [TestInitialize]
        public void Initialize()
        {
            app = ApplicationUnderTest.Launch(Path.Combine(new DirectoryInfo(TestContext.TestDir).Parent.Parent.FullName, @"HonglornWPF\bin\debug\HonglornWPF.exe"), "", "memory");
        }

        [TestCleanup]
        public void Cleanup()
        {
            app.Close();
        }

        [TestMethod]
        public void CodedUiTestMethod1()
        {
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
            uiMap.ErrorShownOnImportEmptyPath();
            uiMap.AssertMethod1();
        }
    }
}