using Blog.Data;
using Blog_2.Services;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options 
        => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>(); //cria uma nova instancia e gera um novo token

var app = builder.Build();
app.MapControllers();
app.Run();
