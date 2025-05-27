using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFood.Application.Models.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse(T? data, string? message = "", bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        public static ApiResponse<T> Ok(T? data, string? message = "Requisição bem-sucedida.")
            => new(data, message, true);

        public static ApiResponse<T> Ok(string? message = "Requisição bem-sucedida.")
            => new(default, message, true);

        public static ApiResponse<T> Fail(string? message)
            => new(default, message, false);
    }
}
