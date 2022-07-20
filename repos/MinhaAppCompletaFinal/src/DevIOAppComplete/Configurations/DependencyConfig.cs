//using DevIO.Business.Models;
//using DevIO.Business.Intefaces;
//using DevIO.Data.Context;
//using DevIO.Data.Repository;


//namespace DevIOAppComplete.Configurations
//{
//    public static class DependencyConfig
//    {
//        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
//        {
//            services.AddScoped<MeuDbContext>();
//            services.AddScoped<IProdutoRepository, ProdutoRepository>();
//            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
//            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
//            return services;
//        }
//    }
//}
