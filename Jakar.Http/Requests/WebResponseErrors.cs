// Jakar.Extensions :: Jakar.Http
// 11/15/2026

namespace Jakar.Extensions;


/// <summary> <see cref="Error"/> factories for <see cref="WebResponse{TValue}"/>: they live here, with the requester, so Jakar.ErrorOr doesn't depend on Jakar.Http. </summary>
public static class WebResponseErrors
{
    extension( Error )
    {
        public static bool TryCreate<TValue>( WebResponse<TValue> response, string? title, [NotNullWhen(true)] out Error? error )
        {
            Exception? e = response.Exception?.Value;

            if ( e is not null )
            {
                error = Error.Create(e, title, response.URL?.OriginalString, in StringTags.Empty, response.StatusCode);
                return true;
            }

            error = null;
            return false;
        }
    }
}