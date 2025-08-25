using MingiSynchronos.API.Data;
using MingiSynchronos.FileCache;
using MingiSynchronos.Services.CharaData.Models;

namespace MingiSynchronos.Services.CharaData;

public sealed class MingiCharaFileDataFactory
{
    private readonly FileCacheManager _fileCacheManager;

    public MingiCharaFileDataFactory(FileCacheManager fileCacheManager)
    {
        _fileCacheManager = fileCacheManager;
    }

    public MingiCharaFileData Create(string description, CharacterData characterCacheDto)
    {
        return new MingiCharaFileData(_fileCacheManager, description, characterCacheDto);
    }
}