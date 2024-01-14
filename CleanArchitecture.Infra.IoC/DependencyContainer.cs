using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.CommandHandlers;
using CleanArchitecture.Domain.Commands;
using CleanArchitecture.Domain.Core.Bus;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infra.Bus;
using CleanArchitecture.Infra.Data.Context;
using CleanArchitecture.Infra.Data.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Bus
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Handlers
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            // Application layer
            services.AddScoped<ICourseService, CourseService>();

            // Data layer
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<UniversityDbContext>();
        }
    }
}
