# Jakar.Http

An HttpClient-based requester (WebRequester) with retries, typed JSON bodies on Jakar.Json, and WebResponse<T> results that carry their errors.

```sh
dotnet add package Jakar.Http
```

Split out of [Jakar.Extensions](https://github.com/Jakar510/Jakar.Extensions) in 10.12.0. Since 10.2.0 it depends on Jakar.Files, Jakar.ErrorOr, Jakar.Core, Jakar.Logging and Jakar.Collections (not Jakar.Extensions; Jakar.Extensions 10.13 depends on it and type-forwards the types that moved).nuget.org/packages/Jakar.Extensions/), [Jakar.Files](https://www.nuget.org/packages/Jakar.Files/) and [Jakar.ErrorOr](https://www.nuget.org/packages/Jakar.ErrorOr/). The types keep the `Jakar.Extensions` namespace, so code that used them from Jakar.Extensions only needs this package reference (and a recompile).

## What's in it

- `WebRequester` (and its `Builder`, `RetryPolicy`, `WebRequesterOptions`): GET/POST/PUT/PATCH/DELETE against a host, with JSON bodies written by Jakar.Json.
- `WebHandler`: reads the response as a string, bytes, stream, file, `JsonTape` or a `[JsonModel]` type (`AsJson<T>`, `AsJsonArray<T>`, `AsJsonList<T>`).
- `WebResponse<T>` and `ErrorResponse`: the payload or the errors; `Error.TryCreate(WebResponse<T>, ...)` builds an `Error` from a failed response.
- `HeaderCollection`, `UriExtensions` and the networking exceptions.

`Status`, `Statuses` and the MIME types stay in Jakar.Extensions.

## Versioning

Versions are `<.NET major>.<library major>.<library minor>`: a breaking change bumps the middle number (`10.1.0` → `10.2.0`), anything else the last one.

## Repository

| Path | What it is |
|---|---|
| `Jakar.Http/` | The package. |
| `Jakar.Http.Tests/` | NUnit tests. |
| `.github/workflows/ci.yml` | Build and test on Ubuntu and Windows, for every push and pull request. |
| `.github/workflows/publish.yml` | On `master`: CI, then pack and push to nuget.org (Trusted Publishing). |