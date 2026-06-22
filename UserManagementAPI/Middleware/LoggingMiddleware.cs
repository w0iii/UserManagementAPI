namespace UserManagementAPI.Middleware
{

public class LoggingMiddleware
{

private readonly RequestDelegate next;



public LoggingMiddleware(RequestDelegate next)
{
    this.next = next;
}




public async Task Invoke(HttpContext context)
{

Console.WriteLine(
$"Request: {context.Request.Method} {context.Request.Path}"
);



await next(context);



Console.WriteLine(
$"Response Status: {context.Response.StatusCode}"
);

}


}

}