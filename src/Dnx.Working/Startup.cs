using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;

namespace Dnx.Working
{
	public class Startup
	{
		public Startup(IApplicationEnvironment env, IRuntimeEnvironment runtimeEnvironment)
		{
		}

		public void ConfigureServices(IServiceCollection services)
		{
			Services = services;
			services.AddMvc();
			services.AddMvcDnx();
		}

		public IServiceCollection Services { get; set; }

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app,
			IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.All
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseDeveloperExceptionPage();
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseIISPlatformHandler();
			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();
		}
	}
}