using bookShopAPI.Context;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(cfg => {
        cfg.WithOrigins(builder.Configuration["AllowedOrigins"]); // Todos los origenes permitidos por defecto, aun que podemos hacer filtro dentro de los appsettings.
        cfg.AllowAnyMethod();
        cfg.AllowAnyHeader();
    });
    options.AddPolicy(name: "AnyOrigin",
        cfg => {
            cfg.AllowAnyOrigin();
            cfg.AllowAnyMethod();
            cfg.AllowAnyHeader();
        });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Configuration.GetValue<bool>("UseDeveloperExceptionPage"))
    app.UseDeveloperExceptionPage();
else
    app.UseExceptionHandler("/error");

app.UseCors("AnyOrigin");

app.UseStaticFiles();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/error", [EnableCors("AnyOrigin")][ResponseCache(NoStore = true)] () => Results.Problem());
app.MapGet("/error/test", [EnableCors("AnyOrigin")][ResponseCache(NoStore = true)] () => { throw new Exception("test"); });

app.MapControllers();

app.Run();
