using MingiSynchronos.FileCache;
using MingiSynchronos.Services.Mediator;
using MingiSynchronos.WebAPI.Files;
using Microsoft.Extensions.Logging;

namespace MingiSynchronos.PlayerData.Factories;

public class FileDownloadManagerFactory
{
    private readonly FileCacheManager _fileCacheManager;
    private readonly FileCompactor _fileCompactor;
    private readonly FileTransferOrchestrator _fileTransferOrchestrator;
    private readonly ILoggerFactory _loggerFactory;
    private readonly MingiMediator _MingiMediator;

    public FileDownloadManagerFactory(ILoggerFactory loggerFactory, MingiMediator MingiMediator, FileTransferOrchestrator fileTransferOrchestrator,
        FileCacheManager fileCacheManager, FileCompactor fileCompactor)
    {
        _loggerFactory = loggerFactory;
        _MingiMediator = MingiMediator;
        _fileTransferOrchestrator = fileTransferOrchestrator;
        _fileCacheManager = fileCacheManager;
        _fileCompactor = fileCompactor;
    }

    public FileDownloadManager Create()
    {
        return new FileDownloadManager(_loggerFactory.CreateLogger<FileDownloadManager>(), _MingiMediator, _fileTransferOrchestrator, _fileCacheManager, _fileCompactor);
    }
}