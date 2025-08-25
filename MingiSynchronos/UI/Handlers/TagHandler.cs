﻿using MingiSynchronos.Services.ServerConfiguration;

namespace MingiSynchronos.UI.Handlers;

public class TagHandler
{
    public const string CustomAllTag = "Mingi_All";
    public const string CustomOfflineTag = "Mingi_Offline";
    public const string CustomOfflineSyncshellTag = "Mingi_OfflineSyncshell";
    public const string CustomOnlineTag = "Mingi_Online";
    public const string CustomUnpairedTag = "Mingi_Unpaired";
    public const string CustomVisibleTag = "Mingi_Visible";
    private readonly ServerConfigurationManager _serverConfigurationManager;

    public TagHandler(ServerConfigurationManager serverConfigurationManager)
    {
        _serverConfigurationManager = serverConfigurationManager;
    }

    public void AddTag(string tag)
    {
        _serverConfigurationManager.AddTag(tag);
    }

    public void AddTagToPairedUid(string uid, string tagName)
    {
        _serverConfigurationManager.AddTagForUid(uid, tagName);
    }

    public List<string> GetAllTagsSorted()
    {
        return
        [
            .. _serverConfigurationManager.GetServerAvailablePairTags()
                        .OrderBy(s => s, StringComparer.OrdinalIgnoreCase)
,
        ];
    }

    public HashSet<string> GetOtherUidsForTag(string tag)
    {
        return _serverConfigurationManager.GetUidsForTag(tag);
    }

    public bool HasAnyTag(string uid)
    {
        return _serverConfigurationManager.HasTags(uid);
    }

    public bool HasTag(string uid, string tagName)
    {
        return _serverConfigurationManager.ContainsTag(uid, tagName);
    }

    /// <summary>
    /// Is this tag opened in the paired clients UI?
    /// </summary>
    /// <param name="tag">the tag</param>
    /// <returns>open true/false</returns>
    public bool IsTagOpen(string tag)
    {
        return _serverConfigurationManager.ContainsOpenPairTag(tag);
    }

    public void RemoveTag(string tag)
    {
        _serverConfigurationManager.RemoveTag(tag);
    }

    public void RemoveTagFromPairedUid(string uid, string tagName)
    {
        _serverConfigurationManager.RemoveTagForUid(uid, tagName);
    }

    public void SetTagOpen(string tag, bool open)
    {
        if (open)
        {
            _serverConfigurationManager.AddOpenPairTag(tag);
        }
        else
        {
            _serverConfigurationManager.RemoveOpenPairTag(tag);
        }
    }
}