using MingiSynchronos.MingiConfiguration.Configurations;

namespace MingiSynchronos.MingiConfiguration;

public class MingiConfigService : ConfigurationServiceBase<MingiConfig>
{
    public const string ConfigName = "config.json";

    public MingiConfigService(string configDir) : base(configDir)
    {
    }

    public override string ConfigurationName => ConfigName;
}