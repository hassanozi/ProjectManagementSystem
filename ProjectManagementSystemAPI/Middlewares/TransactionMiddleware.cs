﻿using ProjectManagementSystemAPI.Data;
using ProjectManagementSystemAPI.Model;

namespace ProjectManagementSystemAPI.Middlewares
{
    public class TransactionMiddleware
    {
        RequestDelegate _next;

        public TransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async System.Threading.Tasks.Task InvokeAsync(HttpContext httpContext, Context context)
        {
            var method = httpContext.Request.Method.ToUpper();
            if (method == "POST" || method == "PUT" || method == "DELETE")
            {
                var transaction = context.Database.BeginTransaction();
               
                try
                {
                    
                    await _next(httpContext);
                    await  context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction?.RollbackAsync();
                    throw ;
                }
            }
            else
            {
                await _next(httpContext);
            }
        }

    }
}
