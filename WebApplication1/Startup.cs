
using InvoiceManager.Models;
using InvoiceManager.Repository;
using InvoiceManager.Service;
using Microsoft.OpenApi.Models;

namespace InvoiceManager.Api
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings.Instance.SetConfiguration(Configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //getting values from app setting

            string dbendpoint = Configuration["_CosmosDBUrl"];
            string dbkey = Configuration["_CosmosDBkey"];
            string databaseId = Configuration["_CosmosDatabaseId"];
            string collectionId = Configuration["_CosmosDBCollectionId"];

            services.AddScoped<IinvoiceRepository>(_ => new InvoiceRepository(dbendpoint, dbkey, databaseId, collectionId));

            services.AddTransient<IInvoiceService, InvoiceService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
            });

        }
    }
}
