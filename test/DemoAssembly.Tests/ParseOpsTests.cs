using System.Management.Automation.Language;
using Xunit;

namespace DemoAssembly.Tests
{
    public class ParseOpsTests
    {
        [Fact]
        public void DoesNotReturnNull()
        {
            Ast result = ParseOps.Parse("Get-ChildItem");
            Assert.NotNull(result);
        }
    }
}
