using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using Repository;
using Repository.IRepository;
using Service.IService;
using Service.Service;

namespace Assigment_Group_Project
{
    public static class DependencyInjection
    {
        public static void AddWebAPIService(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddControllers().AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });
            //services.AddControllers().AddNewtonsoftJson(o =>
            //{
            //    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //});

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHealthChecks();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(typeof(Program));
            //services.AddScoped<IClaimsServices, ClaimsServices>();
            //Adding Session
            services.AddDistributedMemoryCache(); //Adding cache in memory for session.
            services.AddSession(); //Adding session.
            //services.AddTransient<ISessionServices, SessionServices>();
            services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RoleClaimType = ClaimTypes.Role,
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding
                            .UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                    };
                });
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            #region DI_Repository
            builder.Services.AddScoped<IMenuRepository, MenuRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ITaskRepository, TaskRepository>();
            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IVoucherRepository, VoucherRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            #region DI_Service
            builder.Services.AddScoped<IMenuService, MenuService>();
            builder.Services.AddScoped<IServicesService, ServicesService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ITaskService, TaskService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IVoucherService, VoucherService>();
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();
            builder.Services.AddScoped<IUserService, UserService>();
            #endregion

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PRN231", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Please enter a valid token",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
            });
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            //{
            //    options.RequireHttpsMetadata = false;
            //    options.SaveToken = true;
            //    options.TokenValidationParameters = new TokenValidationParameters()
            //    {
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidateIssuerSigningKey = true,
            //        ValidateLifetime = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            //    };
            //});
            //services.AddFluentValidationClientsideAdapters();


            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin()
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });


        }
    }
}

