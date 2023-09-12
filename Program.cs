using ProdutoApi.Application.EventHandlers;
using ProdutoApi.Infra.Repository;
using ProdutoApi.Profiles;
using Citel.Infra.Context;
using Citel.Interface;
using Citel.Application.Models;
using Citel.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddScoped<IRepository<Categoria>, CategoriaRepository>();
builder.Services.AddTransient<IRepository<Categoria>, CategoriaRepository>();
builder.Services.AddScoped<IRepository<Produto>, ProdutoRepository>();
builder.Services.AddTransient<IRepository<Produto>, ProdutoRepository>();
builder.Services.AddTransient<ILogger<LogEventHandler>, Logger<LogEventHandler>>();
builder.Services.AddScoped<ILogger<LogEventHandler>, Logger<LogEventHandler>>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), mySqlOptions =>
{
    mySqlOptions.EnableRetryOnFailure(
        maxRetryCount: 5,
        maxRetryDelay: TimeSpan.FromSeconds(2), 
        errorNumbersToAdd: null
    );
}));
builder.Services.AddAutoMapper(typeof(CategoriaProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Categoria}/{action=Index}/{id?}");

app.Run();
