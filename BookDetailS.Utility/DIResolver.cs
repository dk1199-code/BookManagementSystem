using BookDetailS.Core.IBookrepositery;
using BookDetailS.Core.IBookService;
using BookDetailS.Resources.Repositery;
using BookDetailS.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDetailS.Utility
{
    public static class DIResolver
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            #region Context accesor
            // this is for accessing the http context by interface in view level
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Services

            services.AddScoped<IBookService, BookService>();

            #endregion

            #region Repository

            services.AddScoped<IBookRepositery, BookRepositery>();

            #endregion

        }
    }
}
