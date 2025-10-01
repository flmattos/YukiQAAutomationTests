using Reqnroll;
using System.Threading.Tasks;
using yuki_qa_automation_tests.Pages;

[Binding]
public class PrivacySteps
{
    private readonly World _world;
    private PrivacyPage _privacyPage;
    public PrivacySteps(World world)
    {
        _world = world;
        _privacyPage = new PrivacyPage(_world.Page);
    }

    [When(@"I open the Privacy Page")]
    public async Task GivenINavigatePrivacyPage()
    {
        await _privacyPage.ClickOnPrivacyTab();
    }

    [Then(@"the privacy title should be visible")]
    public async Task ThenPrivacyTitleVisible()
    {
        var visible = await _privacyPage.IsPrivacyPolicyVisibleAsync();
        if (!visible) throw new System.Exception("Privacy heading is not visible!");
    }
}
