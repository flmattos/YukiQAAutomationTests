using Microsoft.Playwright;
using System.Threading.Tasks;

namespace yuki_qa_automation_tests.Pages;
public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    private ILocator WelcomeHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Welcome" });
    public async Task GoToAsync(string url)
    {
        await _page.GotoAsync(url);
    }

    public async Task<bool> IsWelcomeVisibleAsync()
    {
        return await WelcomeHeading.IsVisibleAsync();
    }
}
