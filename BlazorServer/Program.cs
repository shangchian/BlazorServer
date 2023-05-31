using BlazorServer.Services;


var builder = WebApplication.CreateBuilder(args);

// Customized start
builder.Services.AddRazorPages();           // DI container
builder.Services.AddServerSideBlazor();     // DI container
builder.Services.AddScoped<IBookService, BookService>();    // DI container，註冊自定義服務，取得書籍資料
builder.Services.AddHttpClient<IBookService, BookService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:44396/");   // 在 MyWebAPI/Properties/launchSettings.json > iisSettings, https > 44396, http > 19318
});

var app = builder.Build();

app.UseStaticFiles();                       // 可以執行 wwwroot/htmlpage.html
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");            // _Host.cshtml
// Customized end


//app.MapGet("/", () => "Hello World!");

app.Run();
