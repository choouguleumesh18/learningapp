
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect("Endpoint=https://learningappconfigaration.azconfig.io;Id=TGnT;Secret=2EuxPZ0UhSpgoypSnvqyTfUwxrPU0UZit3MxaOzAH4Ndiu7oGmQtJQQJ99BFACi5YpzNlPvWAAABAZAC2CC4");
 });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
