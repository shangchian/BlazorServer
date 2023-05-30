using BlazorServer.Services;


var builder = WebApplication.CreateBuilder(args);

// Customized start
builder.Services.AddRazorPages();           // DI container
builder.Services.AddServerSideBlazor();     // DI container
builder.Services.AddScoped<IBookService, BookService>();    // 註冊自定義服務
var app = builder.Build();

app.UseStaticFiles();                       // 可以執行 wwwroot/htmlpage.html
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");            // _Host.cshtml
// Customized end


//app.MapGet("/", () => "Hello World!");

app.Run();
