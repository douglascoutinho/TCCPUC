using Microsoft.Extensions.DependencyInjection;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Repositories;

namespace RiscSegPre.Site.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            #region Camada de Aplicação
            
            #endregion Camada de Aplicação

            #region Camada de Dominio
          
            #endregion Camada de Dominio

            #region Camada de Infra Estrutura do Repositorio

            services.AddScoped<IPredioRepository, PredioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IDelegaciaPoliciaCivilRepository, DelegaciaPoliciaCivilRepository>();
            services.AddScoped<IBatalhaoPoliciaMilitarRepository, BatalhaoPoliciaMilitarRepository>();
            services.AddScoped<IApartamentoRepository, ApartamentoRepository>();
            services.AddScoped<IBairroRepository, BairroRepository>();
            services.AddScoped<IRiscoRepository, RiscoRepository>();
            services.AddScoped<IInspecaoRepository, InspecaoRepository>();


            #endregion Camada de Infra Estrutura do Repositorio
        }
    }
}
