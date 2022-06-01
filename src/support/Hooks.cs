using BoDi;
using Microsoft.Playwright;
using NUnit.Framework;
using PlaywrightDotnetSpecflow.utils;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

using PlaywrightDotNetSpecFlow.Helpers;

[assembly: Parallelizable(ParallelScope.Fixtures)]

namespace PlaywrightDotnetSpecflow.support
{

    [Binding]
    class Hooks
    {
        public Global global = new Global();
        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = scenarioContext;
        }

        [AfterScenario()]
        public async Task closeBrowser()
        {
            if (_scenarioContext.TestError != null)
            {
                await Helpers.Screenshot(global.Page);
            }
            await global.BrowserLaunch.DisposeAsync();
        }

        [Before()]
        public async Task createBrowser()
        {
            global.Playwright = await Playwright.CreateAsync();
            var optionBrowser = global.TypeLaunchOptions = new BrowserTypeLaunchOptions { Headless = false };
            global.BrowserLaunch = await global.Playwright.Chromium.LaunchAsync(optionBrowser);
            global.Context = await global.BrowserLaunch.NewContextAsync();
            global.Page = await global.Context.NewPageAsync();
            _objectContainer.RegisterInstanceAs(global.Page);
        }
    }
}