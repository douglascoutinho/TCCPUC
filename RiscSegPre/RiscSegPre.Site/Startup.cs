using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RiscSegPre.Application.AutoMapper;
using RiscSegPre.Infra.Data.Context;
using RiscSegPre.Site.Data;
using RiscSegPre.Site.Extentions.Menssagem;
using RiscSegPre.Site.IoC;
using SharpDX.DXGI;
using System.Globalization;

namespace RiscSegPre.Site
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            ToastrMessageEx.ChangeDefaultCookieName("Risco-Error-Message");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Configuração para o EntityFramework

            //mapeando injeção de dependência para a classe DataContext
            services.AddTransient<DataContext>();

            //mapeando a string de conexão que será enviada para a classe DataContext
            services.AddDbContext<DataContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("webContext"))
                );


            services.AddTransient<LoginContext>();

            services.AddDbContext<LoginContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("webContext")));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<LoginContext>();

            #endregion

            #region Configuração para Injeção de Dependência

            NativeInjectorBootStrapper.RegisterServices(services);

            #endregion

            #region Configuração para o AutoMapper

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                // cfg.AllowNullCollections = true;
                cfg.AddProfile<DomainEntityToModel>();
                cfg.AddProfile<ModelToDomainEntity>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            #endregion

            services.AddControllersWithViews()
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                    {
                        return factory.Create(typeof(SharedResource));
                    };
                });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddControllersWithViews().AddMvcOptions(options =>
            {
                options.MaxModelValidationErrors = 50;
                options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Campo Obrigatório!");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Definindo a cultura padrão: pt-BR
            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages(); // This one!

            });
        }
    }
}
