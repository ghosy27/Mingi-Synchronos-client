using MingiSynchronos.MingiConfiguration.Models;

namespace MingiSynchronos.MingiConfiguration.Configurations;

public class ServerTagConfig : IMingiConfiguration
{
    public Dictionary<string, ServerTagStorage> ServerTagStorage { get; set; } = new(StringComparer.OrdinalIgnoreCase);
    public int Version { get; set; } = 0;
}