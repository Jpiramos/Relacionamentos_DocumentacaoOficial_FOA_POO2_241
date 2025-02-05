using Microsoft.EntityFrameworkCore;
using Relacionamentos.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("RelacionamentosDbConnectionString");
builder.Services.AddDbContext<RelacionamentosContext>(options => options.UseSqlServer(connectionString));

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar o pipeline de requisi��o HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();