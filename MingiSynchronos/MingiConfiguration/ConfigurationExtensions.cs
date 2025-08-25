using MingiSynchronos.MingiConfiguration.Configurations;

namespace MingiSynchronos.MingiConfiguration;

public static class ConfigurationExtensions
{
    public static bool HasValidSetup(this MingiConfig configuration)
    {
        return configuration.AcceptedAgreement && configuration.InitialScanComplete
                    && !string.IsNullOrEmpty(configuration.CacheFolder)
                    && Directory.Exists(configuration.CacheFolder);
    }
}