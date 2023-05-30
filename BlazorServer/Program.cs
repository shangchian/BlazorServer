using BlazorServer.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<IBookService, BookService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44396/");   // �b BlazorServer/Properties/
});

// Customized start
builder.Services.AddRazorPages();           // DI container
builder.Services.AddServerSideBlazor();     // DI container
builder.Services.AddScoped<IBookService, BookService>();    // DI container�A���U�۩w�q�A�ȡA���o���y���
var app = builder.Build();

app.UseStaticFiles();                       // �i�H���� wwwroot/htmlpage.html
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");            // _Host.cshtml
// Customized end


//app.MapGet("/", () => "Hello World!");

app.Run();
