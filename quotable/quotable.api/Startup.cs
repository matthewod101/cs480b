using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quotable.core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace lorem.api
{
    /// <summary>
    /// The startup class for this API
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration">The configuration for the application</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// Configure the services for the application.
        /// </summary>
        /// <param name="services">The collection of service.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            // setup to use a sqlite database
            services.AddDbContext<QuotableContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder</param>
        /// <param name="env">The hosting environment</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<QuotableContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                PopulateDatabase(context);
            }
        }

        private static void PopulateDatabase(QuotableContext c)
        {
            IEnumerable<string> lines = System.IO.File.ReadAllLines(@"..\..\quotes.txt");
            DefaultRandomQuoteGenerator d = new DefaultRandomQuoteGenerator(lines);
            var count = 0;
            foreach (string s in lines)
            {
                var author = new Author()
                {
                    FirstName = d.FindAuthorFirstName(count),
                    LastName = d.FindAuthorLastName(count)
                };
                var quote = new Quote();
                quote.quote = d.FindQuoteById(count);
                var qa = new QuoteAuthor() { quote = quote, Author = author };
                c.AddRange(qa);
                count++;
            }
            c.SaveChanges();
        }
    }
}