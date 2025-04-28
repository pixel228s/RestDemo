using System.Globalization;

namespace PizzaRestaurantDemo.API.Infrastructure.Middlewares
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var cultureName = "ka-GE";

            var queryCulture = context.Request.Headers["Accept-Language"].ToString();
            Console.WriteLine(queryCulture);

            if (!string.IsNullOrWhiteSpace(queryCulture))
                cultureName = queryCulture.Split(',')[0];

            var culture = new CultureInfo(cultureName);

            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

            await _next(context);
        }
    }
}
