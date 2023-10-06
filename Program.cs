using Blog.Data;
using Blog_2;
using Blog_2.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; //sistema de autenticação padrão aspnet
}).AddJwtBearer(x => 
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options 
        => options.SuppressModelStateInvalidFilter = true);

builder.Services.AddDbContext<BlogDataContext>();
builder.Services.AddTransient<TokenService>(); //cria uma nova instancia e gera um novo token

var app = builder.Build();

app.UseAuthentication (); //sempre usar nessa ordem atenticação/autorização
app.UseAuthorization();


app.MapControllers();

app.Run();
