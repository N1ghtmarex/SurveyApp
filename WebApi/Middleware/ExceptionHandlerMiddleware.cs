using Common.Exceptions;
using System.Net;
using System.Text.Json;
using WebApi.Models;

namespace WebApi.Middleware
{
    public class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (BusinessLogicException ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = JsonSerializer.Serialize(new BadResponseModel { Message = ex.Message });

                await response.WriteAsync(result);
            }
            catch (ForbiddenException ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.Forbidden;
                var result = JsonSerializer.Serialize(new BadResponseModel { Message = ex.Message });

                await response.WriteAsync(result);
            }
            catch (ObjectAlreadyExistsException ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                var result = JsonSerializer.Serialize(new BadResponseModel { Message = ex.Message });

                await response.WriteAsync(result);
            }
            catch (ObjectNotFoundException ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.NotFound;
                var result = JsonSerializer.Serialize(new BadResponseModel { Message = ex.Message });

                await response.WriteAsync(result);
            }
            catch (Exception ex)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var result = JsonSerializer.Serialize(new BadResponseModel { Message = ex.Message });

                await response.WriteAsync(result);
            }
        }
    }
}
