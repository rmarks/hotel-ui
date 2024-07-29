using Hotel.FakeData;
using Hotel.UI;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddFakeData();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    SeedData.Seed(scope.ServiceProvider.GetRequiredService<AppDbContext>());
}

await app.RunAsync();
