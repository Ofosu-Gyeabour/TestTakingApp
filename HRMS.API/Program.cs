using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PETAS.Data.Data;

var Cors = @"Cors";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMvc(option => option.EnableEndpointRouting = false)
         .SetCompatibilityVersion(CompatibilityVersion.Latest)
         .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
        options.AddPolicy(Cors,
                //builder => builder.AllowAnyOrigin()
                //.AllowAnyMethod()
                //.AllowAnyHeader()
                //.SetPreflightMaxAge(TimeSpan.FromSeconds(5000))
                //.SetIsOriginAllowed(x => true)
                //.WithExposedHeaders("*")

                builder => builder.AllowAnyOrigin()
                   .WithMethods("POST", "GET", "HEAD", "OPTIONS", "DELETE")
                     .WithHeaders("Access-Control-Allow-Origin", "Access-Control-Allow-Methods", "Access-Control-Allow-Headers", "Content-Disposition", "Content-Type", "Authorization", "Accept", "Origin", "Host", "api-user") //
                     .SetPreflightMaxAge(TimeSpan.FromSeconds(5000))
                     .SetIsOriginAllowed(x => true)
                     .WithExposedHeaders("*")
            );
});


builder.Services.AddDbContext<HRMSContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PanTrainerHRMSConn"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseRouting();

app.UseCors(Cors);
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

app.UseAuthorization();

app.MapControllers();

app.Run();
