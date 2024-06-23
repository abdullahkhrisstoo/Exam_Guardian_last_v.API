using Exam_Guardian.core.ICommon;
using Exam_Guardian.core.IRepo;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using Exam_Guardian.infra.Common;
using Exam_Guardian.infra.Repo;
using Exam_Guardian.infra.Repository;
using Exam_Guardian.infra.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

namespace Exam_Guardian.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddHttpContextAccessor();



            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            })
           .AddCookie(options =>
           {
               options.Cookie.IsEssential = true;
           })
           .AddGoogle(googleOptions =>
           {
               googleOptions.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

               googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
               googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
               googleOptions.CallbackPath = "/signin-google";
           });



            //todo: databse connection
            builder.Services.AddScoped<IDbContext, DbContext>();

            //todo: services
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddSingleton<IEmailService, EmailService>();
            builder.Services.AddScoped<IPlanService, PlanService>();
            builder.Services.AddScoped<IPlanFeatureService, PlanFeatureService>();
            builder.Services.AddScoped<IComplementService, ComplementService>();
            builder.Services.AddScoped<IExamReservationService, ExamReservationService>();
            builder.Services.AddScoped<IGoogleAuthService, GoogleAuthService>();
            //todo: repo
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();
            builder.Services.AddScoped<IPlanRepository, PlanRepository>();
            builder.Services.AddScoped<IPlanFeatureRepository, PlanFeatureRepository>();
            builder.Services.AddScoped<IComplementRepository, ComplementRepository>();
            builder.Services.AddScoped<IExamReservationRepository, ExamReservationRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
          



            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();



            app.MapControllers();

            app.Run();
        }
    }
}
