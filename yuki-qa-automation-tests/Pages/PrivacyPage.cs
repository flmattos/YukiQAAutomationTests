using Microsoft.Playwright;
using System.Threading.Tasks;

namespace yuki_qa_automation_tests.Pages;
public class PrivacyPage
{
    private readonly IPage _page;

    public PrivacyPage(IPage page)
    {
        _page = page;
    }
    private ILocator PrivacyPolicyHeading => _page.GetByRole(AriaRole.Heading, new() { Name = "Privacy Policy" });
    private ILocator PrivacyPolicyTab => _page.Locator("#nav-item-link-privacy");
    public async Task ClickOnPrivacyTab()
    {
        await PrivacyPolicyTab.ClickAsync();
    }

    public async Task<bool> IsPrivacyPolicyVisibleAsync()
    {
        return await PrivacyPolicyHeading.IsVisibleAsync();
    }
}
