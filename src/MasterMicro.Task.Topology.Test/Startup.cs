using MasterMicro.Task.Toplogy.Application.Interfaces;
using MasterMicro.Task.Toplogy.Application.Repositories;
using MasterMicro.Task.Toplogy.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MasterMicro.Task.Topology.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton<ITopologyService, TopologyService>();
        }
    }
}
