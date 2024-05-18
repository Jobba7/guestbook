using Guestbook.Persistence;
using Guestbook.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IEntryRepository, EntryRepository>();
builder.Services.AddScoped<IEntryService, EntryService>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
