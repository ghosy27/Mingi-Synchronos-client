using MingiSynchronos.API.Dto.Group;
using MingiSynchronos.PlayerData.Pairs;
using MingiSynchronos.Services.Mediator;
using MingiSynchronos.Services.ServerConfiguration;
using MingiSynchronos.UI;
using MingiSynchronos.UI.Components.Popup;
using MingiSynchronos.WebAPI;
using Microsoft.Extensions.Logging;

namespace MingiSynchronos.Services;

public class UiFactory
{
    private readonly ILoggerFactory _loggerFactory;
    private readonly MingiMediator _MingiMediator;
    private readonly ApiController _apiController;
    private readonly UiSharedService _uiSharedService;
    private readonly PairManager _pairManager;
    private readonly ServerConfigurationManager _serverConfigManager;
    private readonly MingiProfileManager _MingiProfileManager;
    private readonly PerformanceCollectorService _performanceCollectorService;

    public UiFactory(ILoggerFactory loggerFactory, MingiMediator MingiMediator, ApiController apiController,
        UiSharedService uiSharedService, PairManager pairManager, ServerConfigurationManager serverConfigManager,
        MingiProfileManager MingiProfileManager, PerformanceCollectorService performanceCollectorService)
    {
        _loggerFactory = loggerFactory;
        _MingiMediator = MingiMediator;
        _apiController = apiController;
        _uiSharedService = uiSharedService;
        _pairManager = pairManager;
        _serverConfigManager = serverConfigManager;
        _MingiProfileManager = MingiProfileManager;
        _performanceCollectorService = performanceCollectorService;
    }

    public SyncshellAdminUI CreateSyncshellAdminUi(GroupFullInfoDto dto)
    {
        return new SyncshellAdminUI(_loggerFactory.CreateLogger<SyncshellAdminUI>(), _MingiMediator,
            _apiController, _uiSharedService, _pairManager, dto, _performanceCollectorService);
    }

    public StandaloneProfileUi CreateStandaloneProfileUi(Pair pair)
    {
        return new StandaloneProfileUi(_loggerFactory.CreateLogger<StandaloneProfileUi>(), _MingiMediator,
            _uiSharedService, _serverConfigManager, _MingiProfileManager, _pairManager, pair, _performanceCollectorService);
    }

    public PermissionWindowUI CreatePermissionPopupUi(Pair pair)
    {
        return new PermissionWindowUI(_loggerFactory.CreateLogger<PermissionWindowUI>(), pair,
            _MingiMediator, _uiSharedService, _apiController, _performanceCollectorService);
    }
}
