using PlaywrightDotnetSpecflow.utils;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;

namespace PlaywrightDotnetSpecflow.BasePage
{
    public class TestFunctions : PageTest
    {
        public Global global = new Global();          
        public async Task ExecuteClick(string elemento) => await global.Page.Locator($"{elemento}").ClickAsync();

        public async Task<string> InnerText(string elemento) => await global.Page.InnerTextAsync($"{elemento}");

        public async Task ExecuteDoubleClick(string elemento) => await global.Page.Locator($"{elemento}").DblClickAsync();
        public async Task ValidateText(string elemento, string text) => await Expect(global.Page.Locator($"{elemento}")).ToHaveTextAsync($"{text}");
        public async Task IframeLocator(string elemento, string text) => await global.Page.FrameLocator($"{elemento}").Locator($"{text}").ClickAsync();
        public async Task TypeText(string elemento, string text) => await global.Page.Locator($"{elemento}").FillAsync($"{text}");
        public async Task ValidateUrl(string elemento) => await global.Page.WaitForURLAsync($"{elemento}");
        public async Task WaiLoadPage() => await global.Page.WaitForLoadStateAsync(Microsoft.Playwright.LoadState.DOMContentLoaded);
        public async Task Keyboard(string elemento) => await global.Page.Keyboard.PressAsync($"{elemento}");
        public async Task ValidateElementExist(string elemento) => await global.Page.Locator($"{elemento}").WaitForAsync();
        public async Task ValidateHiddenElement(string elemento) => await global.Page.IsHiddenAsync($"{elemento}");
        public async Task isVisible(string elemento) => await global.Page.Locator($"{elemento}").IsVisibleAsync();



    }
}