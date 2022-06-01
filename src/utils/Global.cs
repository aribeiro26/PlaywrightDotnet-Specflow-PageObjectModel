using Microsoft.Playwright;

namespace PlaywrightDotnetSpecflow.utils
{
     public class Global
    {
        private IBrowser browserLaunch;
        private IBrowserContext context;
        private IBrowserType browser;
        private IPage page;
        private IPlaywright playwright;
        private BrowserTypeLaunchOptions typeLaunchOptions;
        public IBrowser BrowserLaunch { get => browserLaunch; set => browserLaunch = value; }
        public IBrowserContext Context { get => context; set => context = value; }
        public IBrowserType Browser { get => browser; set => browser = value; }
        public IPage Page { get => page; set => page = value; }
        public IPlaywright Playwright { get => playwright; set => playwright = value; }
        public BrowserTypeLaunchOptions TypeLaunchOptions { get => typeLaunchOptions; set => typeLaunchOptions = value; }

    }
}
