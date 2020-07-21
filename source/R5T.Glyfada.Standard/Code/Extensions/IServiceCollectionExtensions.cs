using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

using R5T.Caledonia;
using R5T.Caledonia.Default;
using R5T.Dacia;
using R5T.Nikaia;
using R5T.Nikaia.Configuration;

using R5T.Glyfada.Default;


namespace R5T.Glyfada.Standard
{
    public static class IServiceCollectionExtensions
    {
        public static
            (
            IServiceAction<IGitOperator> main,
            IServiceAction<ICommandLineInvocationOperator> commandLineInvocationOperatorAction,
            IServiceAction<IGitExecutableFilePathProvider> gitExecutableFilePathProviderAction,
            IServiceAction<IOptions<GitConfiguration>> gitConfigurationOptionsAction
            )
        AddGitOperatorAction(this IServiceCollection services)
        {
            // 0.
            var commandLineInvocationOperatorAction = ServiceAction<ICommandLineInvocationOperator>.New(() => services.AddSingleton<ICommandLineInvocationOperator, DefaultCommandLineInvocationOperator>());
            var gitConfigurationAction = services.AddGitConfigurationAction();

            // 1.
            var gitExecutableFilePathProviderAction = services.AddGitExecutableFilePathProviderAction(
                gitConfigurationAction);

            var gitOperatorAction = services.AddGitOperatorAction(
                commandLineInvocationOperatorAction,
                gitExecutableFilePathProviderAction);

            return (
                gitOperatorAction,
                commandLineInvocationOperatorAction,
                gitExecutableFilePathProviderAction,
                gitConfigurationAction);
        }

        public static IServiceCollection AddGitOperator(this IServiceCollection services)
        {
            services
                .AddSingleton<IGitOperator, GitOperator>()
                .AddSingleton<IGitExecutableFilePathProvider, GitExecutableFilePathProvider>()
                .AddGitConfiguration()
                .AddSingleton<ICommandLineInvocationOperator, DefaultCommandLineInvocationOperator>()
                ;

            return services;
        }
    }
}
