using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace MasterMicro.Task.Toplogy.API.Midlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }catch(FileNotFoundException IoException)
            {
                await HandleIOException(context, IoException);
            }catch(Exception ex)
            {
                await HandleException(context, ex);
            }
        }

        private async System.Threading.Tasks.Task HandleIOException(HttpContext context, FileNotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            context.Response.ContentType = "application/json";
            var responseBody = new
            {
                Message = ex.Message
            };
            var serializedBody = JsonConvert.SerializeObject(responseBody);
            await context.Response.WriteAsync(serializedBody);
        }
        private async System.Threading.Tasks.Task HandleException(HttpContext context, Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            var responseBody = new
            {
                Message = ex.Message
            };
            var serializedBody = JsonConvert.SerializeObject(responseBody);
            await context.Response.WriteAsync(serializedBody);
        }
    }
}
