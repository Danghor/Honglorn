using System.Data.Entity;

namespace HonglornAUT
{
    public partial class TraditionalCalculatorTest
    {
        class TestDbInitializer : DropCreateDatabaseAlways<TestDb> { }
    }
}