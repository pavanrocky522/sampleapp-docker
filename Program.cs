var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel to listen on port 80
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // Bind to all network interfaces on port 80
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();