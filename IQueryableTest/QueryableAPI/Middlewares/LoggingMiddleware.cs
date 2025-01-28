using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace QueryableAPI.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private const string LOG_FILE_NAME = "log.txt";
        private string LogFilePath { get; }
        private readonly object _logLock;

        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;

            _logLock = new object();

            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            LogFilePath = Path.Combine(projectPath, LOG_FILE_NAME);

            if (!File.Exists(LogFilePath))
            {
                File.Create(LogFilePath).Dispose();
            }
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            LogRequest(httpContext);

            await _next(httpContext);
        }

        private void LogRequest(HttpContext httpContext)
        {
            string requestUrl = httpContext.Request.Path;
            string message = $"Request to {requestUrl} at {DateTime.Now}\n";

            lock (_logLock)
            {
                File.AppendAllText(LogFilePath, message);
            }
        }
    }

    //// Extension method used to add the middleware to the HTTP request pipeline.
    //public static class LoggingMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<LoggingMiddleware>();
    //    }
    //}
}
