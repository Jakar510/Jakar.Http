// Jakar.Extensions :: Jakar.Http.Tests
// 10/02/2026

// Shared by the golden-file generator (compiled against Jakar.Extensions 10.x / Newtonsoft with LEGACY defined) and by GoldenFile_Tests.
// Every sample is deterministic, so the JSON 10.x wrote and the JSON 11.0 writes can be compared directly.

using System.Collections.Generic;



namespace Jakar.Extensions.Tests;


public static class GoldenSamples
{
    public static ErrorResponse ErrorResponse() => new("something went wrong");


    /// <summary> File name → JSON, written with the serializer of the build this is compiled into. </summary>
    public static IEnumerable<(string Name, string Json)> All()
    {
        yield return ( "ErrorResponse", ErrorResponse().ToJson() );
    }
}