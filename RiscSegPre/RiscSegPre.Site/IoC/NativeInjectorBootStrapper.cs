using Microsoft.Extensions.DependencyInjection;
using RiscSegPre.Application.Contract;
using RiscSegPre.Application.Services;
using RiscSegPre.Domain.Entities.Adapter;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Repositories;

namespace RiscSegPre.Site.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IAddressApi, AddressApiService>();

            #region CAMADA DE APLICAÇÃO

            services.AddScoped<IApartamentoService, ApartamentoService>();
            services.AddScoped<IPredioService, PredioService>();
            services.AddScoped<IBatalhaoPoliciaMilitarService, BatalhaoPoliciaMilitarService>();
            services.AddScoped<IDelegaciaPoliciaCivilService, DelegaciaPoliciaCivilService>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IInspecaoService, InspecaoService>();
            services.AddScoped<IBairroService, BairroService>();
            services.AddScoped<IRiscoService, RiscoService>();

            #endregion Camada de Aplicação


            #region CAMADA DE INFRA ESTRUTURA DO REPOSTORIO

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
