// Jakar.Extensions :: Jakar.Http.Tests

using System.Net.Http;
using System.Threading.Tasks;



namespace Jakar.Extensions.Tests;


/// <summary> HTTP bodies: an argument typed as a base type (<see cref="object"/>, <see cref="BaseClass"/>) is serialized as its runtime type. </summary>
[TestFixture]
public sealed class JsonBody_Tests
{
    [Test] public async Task JsonBody_UsesTheRuntimeType()
    {
        object                 model   = new Alert("Heads up", "Something happened", TimeSpan.FromSeconds(30));
        using ByteArrayContent content = WebRequester.CreateJsonContentOfRuntimeType(model);
        string                 json    = await content.ReadAsStringAsync();

        Assert.That(json, Does.Contain("\"Title\" : \"Heads up\""), "serialized as Alert, not as object");
        Assert.That(json, Does.Not.Contain("\n"),                   "compact");
    }
}