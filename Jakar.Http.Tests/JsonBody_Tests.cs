// Jakar.Extensions :: Jakar.Http.Tests

using System.Net.Http;
using System.Threading.Tasks;



namespace Jakar.Extensions.Tests;


/// <summary> HTTP bodies: a <see cref="BaseClass"/>-typed argument is serialized as its runtime type. </summary>
[TestFixture]
public sealed class JsonBody_Tests
{
    [Test] public async Task JsonBody_UsesTheRuntimeType()
    {
        BaseClass              model   = new Alert("Heads up", "Something happened", TimeSpan.FromSeconds(30));
        using ByteArrayContent content = WebRequester.CreateJsonContentOfRuntimeType(model);
        string                 json    = await content.ReadAsStringAsync();

        Assert.That(json, Does.Contain("\"Title\" : \"Heads up\""), "serialized as Alert, not as BaseClass");
        Assert.That(json, Does.Not.Contain("\n"),                   "compact");
    }
}