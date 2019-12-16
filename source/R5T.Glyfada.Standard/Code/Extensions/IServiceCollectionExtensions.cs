using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Caledonia;
using R5T.Caledonia.Default;
using R5T.Glyfada.Default;
using R5T.Nikaia;
using R5T.Nikaia.Configuration;
using R5T.Nikaia.Configuration.Suebia;


namespace R5T.Glyfada.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddGitOperator(this IServiceCollection services)
        {
            services
                .AddSingleton<IGitOperator, GitOperator>()
                .AddSingleton<IGitOperatorCore, GitOperatorCore>()
                .AddSingleton<IGitExecutableFilePathProvider, GitExecutableFilePathProvider>()
                .AddGitConfiguration()
                .AddSingleton<ICommandLineInvocationOperator, DefaultCommandLineInvocationOperator>()
                ;

            return services;
        }
    }
}
