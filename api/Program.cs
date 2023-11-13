using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var elsaSection = builder.Configuration.GetSection("Elsa");
builder.Services
    .AddElsa(elsa => elsa
        .UseEntityFrameworkPersistence(ef => ef.UseSqlite())
        .AddConsoleActivities()
        .AddHttpActivities(elsaSection.GetSection("Server").Bind)
        .AddEmailActivities(elsaSection.GetSection("Smtp").Bind)
        .AddQuartzTemporalActivities()
        .AddWorkflowsFrom<Program>()
    );
//dotnet add package Elsa.Server.Api
builder.Services.AddElsaApiEndpoints();
// builder.Services.AddRazorPages();



var app = builder.Build();

app.UseStaticFiles();
app.UseHttpActivities();
app.UseRouting();
    // .UseEndpoints(endpoints =>
    // {
    //     endpoints.MapControllers();
    // //    endpoints.MapFallbackToPage("/_Host");
    // });


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();

