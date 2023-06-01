using BlazorServer.Services;
using Blazored.Toast;


var builder = WebApplication.CreateBuilder(args);

// Customized start
builder.Services.AddBlazoredToast();        // BlazoredToast 通知元件
builder.Services.AddRazorPages();           // DI container
builder.Services.AddServerSideBlazor();     // DI container
builder.Services.AddScoped<IBookService, BookService>();    // DI container，註冊自定義服務，取得書籍資料
builder.Services.AddScoped<ICategoryService, CategoryService>();

var WebApiBaseAddress = builder.Configuration["WebsiteConfig:WebApiBaseAddress"];

builder.Services.AddHttpClient<IBookService, BookService>(client =>
{
    client.BaseAddress = new Uri(WebApiBaseAddress ?? "https://localhost:44396/");   // 在 MyWebAPI/Properties/launchSettings.json > iisSettings, https > 44396, http > 19318
});
builder.Services.AddHttpClient<ICategoryService, CategoryService>(client =>
{
    client.BaseAddress = new Uri(WebApiBaseAddress ?? "https://localhost:44396/");   // 在 MyWebAPI/Properties/launchSettings.json > iisSettings, https > 44396, http > 19318
});

var app = builder.Build();

app.UseStaticFiles();                       // 可以執行 wwwroot/htmlpage.html
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");            // _Host.cshtml
// Customized end


//app.MapGet("/", () => "Hello World!");

app.Run();
