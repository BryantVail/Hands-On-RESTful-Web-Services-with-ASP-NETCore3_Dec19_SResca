
using Microsoft.AspNetCore.Http;
using SampleAPI;
using System;
using System.Threading.Tasks;

namespace Middleware
{
    public class MyMiddleware
    {
        readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IPaymentService paymentService)
        {
            Console.WriteLine(paymentService.GetMessage());

            await _next(context);
        }
    }
}