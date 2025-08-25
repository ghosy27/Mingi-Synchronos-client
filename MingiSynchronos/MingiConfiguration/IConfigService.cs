using MingiSynchronos.MingiConfiguration.Configurations;

namespace MingiSynchronos.MingiConfiguration;

public interface IConfigService<out T> : IDisposable where T : IMingiConfiguration
{
    T Current { get; }
    string ConfigurationName { get; }
    string ConfigurationPath { get; }
    public event EventHandler? ConfigSave;
    void UpdateLastWriteTime();
}
