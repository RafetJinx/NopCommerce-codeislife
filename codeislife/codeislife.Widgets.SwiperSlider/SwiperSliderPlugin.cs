using Nop.Services.Localization;
using Nop.Services.Plugins;

namespace codeislife.Widgets.SwiperSlider
{
    public class SwiperSliderPlugin : BasePlugin
    {
        #region Fields
        private readonly ILocalizationService _localizationService;
        #endregion

        #region Ctor
        public SwiperSliderPlugin(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }

        #endregion

        #region Methods

        public override Task InstallAsync()
        {
            Task task = _localizationService.AddOrUpdateLocaleResourceAsync("codeislife.Widgets.SwiperSlider.test", "test");

            return task;
        }

        public override Task UninstallAsync()
        {
            return base.UninstallAsync();
        }

        public override Task PreparePluginToUninstallAsync()
        {
            _localizationService.DeleteLocaleResourcesAsync("codeislife.Widgets.SwiperSlider");

            return base.PreparePluginToUninstallAsync();
        }

        //public override string GetConfigurationPageUrl()
        //{
        //    return base.GetConfigurationPageUrl();
        //}
        #endregion
    }
}
