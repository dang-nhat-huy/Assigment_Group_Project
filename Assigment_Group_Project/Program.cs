using Assigment_Group_Project;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateIssuerSigningKey = true,
//            ValidateLifetime = true,
//            RoleClaimType = ClaimTypes.Role,
//            ValidAudience = builder.Configuration["JWT:Audience"],
//            ValidIssuer = builder.Configuration["JWT:Issuer"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding
//                .UTF8.GetBytes(builder.Configuration["JWT:Key"]))
//        };
//    });
//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PRN231", Version = "v1" });

//    var securityScheme = new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Description = "Please enter a valid token",
//        Type = SecuritySchemeType.Http,
//        Scheme = "bearer",
//        BearerFormat = "JWT", 
//        In = ParameterLocation.Header, 
//        Reference = new OpenApiReference
//        {
//            Type = ReferenceType.SecurityScheme,
//            Id = "Bearer"
//        }
//    };
//    c.AddSecurityDefinition("Bearer", securityScheme);
//    c.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Type=ReferenceType.SecurityScheme,
//                    Id="Bearer"
//                }
//            },
//            new string[]{}
//        }
//    });
//});
builder.Services.AddWebAPIService(builder); //run DI
var app = builder.Build();
#region Add sau

app.UseSession();

app.MapHealthChecks("/healthz");

app.UseCors("_myAllowSpecificOrigins");

#endregion
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
