using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text;

namespace OrnateStatueTests;

public class ApprovalTest
{
    [Fact]
    public Task ThirtyDays()
    {
        var builder = new StringBuilder();
        Console.SetOut(new StringWriter(builder));

        Program.Main(["30"]);
        var output = builder.ToString();

        return Verify(output);
    }
}
