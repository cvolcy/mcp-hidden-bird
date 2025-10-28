using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace McpHiddenBird
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            ConfigureSwagger(builder);
            
            builder.Services.AddMcpServer().WithHttpTransport().WithToolsFromAssembly();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(config =>
                {
                    config.ConfigObject.PersistAuthorization = true;
                    config.ConfigObject.TryItOutEnabled = true;
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapMcp("/mcp");

            app.MapControllers();
            app.Run();
        }

        private static void ConfigureSwagger(WebApplicationBuilder builder)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddSwaggerGen(config =>
            {
                config.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

            });
        }
    }
}