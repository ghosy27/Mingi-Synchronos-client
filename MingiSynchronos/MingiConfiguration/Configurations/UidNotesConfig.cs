using MingiSynchronos.MingiConfiguration.Models;

namespace MingiSynchronos.MingiConfiguration.Configurations;

public class UidNotesConfig : IMingiConfiguration
{
    public Dictionary<string, ServerNotesStorage> ServerNotes { get; set; } = new(StringComparer.Ordinal);
    public int Version { get; set; } = 0;
}
