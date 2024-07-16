using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities;
using Exam_Guardian.infra.Repo;
using Exam_Guardian.infra.Repository;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Exam_Guardian.core.Utilities.TokenConstant;
using Newtonsoft.Json;
namespace Exam_Guardian.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddDbContext<core.Data.ModelContext>(x => x.UseOracle(builder.Configuration.GetConnectionString("DBConnectionString")));

            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();


            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = TokenConstant.symmetricSecurityKey,
                ClockSkew = TimeSpan.Zero
            }); ;



            //            builder.Services
            //                .AddAuthentication(options =>
            //                         {
            //                            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //                            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //                            options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //                          })
            //              .AddCookie(options => 
            //                          {
            //                           options.Cookie.IsEssential = true;
            //                           })
            //              .AddGoogle(googleOptions =>
            //                          {
            //                            googleOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //                            googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            //                            googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            //                            googleOptions.CallbackPath = "/signin-google";
            //                           })
            //              .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
            //                           {
            //                             x.TokenValidationParameters = new TokenValidationParameters
            //                                  {
            //                                     ValidateIssuer = false,
            //                                     ValidateAudience = false,
            //                                     ValidateLifetime = true,
            //                                     ValidateIssuerSigningKey = true,
            //                                     IssuerSigningKey = TokenConstant.symmetricSecurityKey,
            //                                    ClockSkew = TimeSpan.Zero
            //                                    };
            //});
            builder.Services.Configure<WhatsAppSettings>(builder.Configuration.GetSection(nameof(WhatsAppSettings)));
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddSignalR();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://192.168.1.17:4200")
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials(); // Allow credentials (cookies, authorization headers)
                    });
            });


         


            //todo: databse connection
            builder.Services.AddScoped<IDbContext,infra.Common.DbContext>();

            //todo: services
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<IPlanFeatureService, PlanFeatureService>();
            builder.Services.AddScoped<IComplementService, ComplementService>();
            builder.Services.AddScoped<IExamReservationService, ExamReservationService>();
            builder.Services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            builder.Services.AddScoped<IExamService, ExamService>();
            builder.Services.AddScoped<IProctorService, ProctorService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<ITestimonalRepositary,TestimonialRepository>();
            builder.Services.AddScoped<ITestimonalService, TestimonalService>();
            builder.Services.AddScoped<IContactUsServices, ContactUsServices>();
            builder.Services.AddScoped<IStatisticsService, StatisticsService>();
            builder.Services.AddScoped<IAboutService, AboutService>();





            //todo: repo
            builder.Services.AddScoped<IExamProviderRepository, ExamProviderRepository>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IPlanRepository, PlanRepository>();
            builder.Services.AddScoped<IPlanFeatureRepository, PlanFeatureRepository>();
            builder.Services.AddScoped<IComplementRepository, ComplementRepository>();
            builder.Services.AddScoped<IExamReservationRepository, ExamReservationRepository>();
            builder.Services.AddScoped<IProctorRepository, ProctorRepository>();
            builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
            builder.Services.AddScoped<IAboutRepository, AboutRepository>();

            builder.Services.AddControllers()
                          .AddJsonOptions(options =>
                                       {
                                         options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                                        });

            builder.Services.AddControllers()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting(); // Add this line to enable routing



            //app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors("AllowAngularDev");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<VideoCallHub>("/videoCallHub");
                endpoints.MapControllers();
            });
            app.MapControllers();

            app.Run();
        }
    }
}
