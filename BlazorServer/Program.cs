var builder = WebApplication.CreateBuilder(args);

// Customized start
builder.Services.AddRazorPages();           // DI container
builder.Services.AddServerSideBlazor();     // DI container
var app = builder.Build();

app.UseStaticFiles();                       // ¥i¥H°õ¦æ wwwroot/htmlpage.html
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");            // _Host.cshtml
// Customized end


//app.MapGet("/", () => "Hello World!");

app.Run();
