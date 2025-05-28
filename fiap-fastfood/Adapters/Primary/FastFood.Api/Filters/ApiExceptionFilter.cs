using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using FastFood.Application.Models.Common;
using FastFood.Domain.Common.Exceptions;

namespace FastFood.Api.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            if (exception is DomainException or ApplicationException)
            {
                _logger.LogWarning(exception, "Exceção esperada capturada: {Mensagem}", exception.Message);

                context.Result = new BadRequestObjectResult(
                    ApiResponse<string>.Fail(exception.Message)
                );

                context.ExceptionHandled = true;
                return;
            }

            _logger.LogError(exception, "Ocorreu uma exceção não tratada");

            context.Result = new ObjectResult(
                ApiResponse<string>.Fail("Erro inesperado ao processar a solicitação.")
            )
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}
