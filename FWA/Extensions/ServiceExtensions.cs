using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FWA.Data;
using FWA.Data.Repositories;
using FWA.Data.Repositories.Interfaces;
using FWA.Data.Services;

namespace FWA.WebApi.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddFwa(this IServiceCollection services)
        {
            
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<MovieService>();
            services.AddScoped<RatingService>();
        }
    }
}
