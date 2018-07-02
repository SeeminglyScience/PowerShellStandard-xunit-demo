using System.Management.Automation.Language;

namespace DemoAssembly
{
    public static class ParseOps
    {
        public static Ast Parse(string input)
        {
            return Parser.ParseInput(input, out _, out _);
        }
    }
}
