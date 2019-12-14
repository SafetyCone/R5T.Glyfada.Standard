using System;

using Microsoft.Extensions.Configuration;

using R5T.Nikaia.Configuration.Suebia;


namespace R5T.Glyfada.Standard
{
    public static class IConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddGitConfiguration(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder.AddGitConfigurationJsonFile(configurationServiceProvider);

            return configurationBuilder;
        }
    }
}
