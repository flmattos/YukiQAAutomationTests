using Reqnroll;
using System.Threading.Tasks;
using yuki_qa_automation_tests.Pages;

[Binding]
public class HomeSteps
{
    private readonly World _world;
    private HomePage _homePage;

    public HomeSteps(World world)
    {
        _world = world;
        _homePage = new HomePage(_world.Page);
    }

    [Given(@"I open the Home Page")]
    public async Task GivenINavigateToHomePage()
    {        
        await _homePage.GoToAsync("https://localhost:5001");
    }

    [Then(@"the welcome text should be visible")]
    public async Task ThenWelcomeTextVisible()
    {
        var visible = await _homePage.IsWelcomeVisibleAsync();
        if (!visible) throw new System.Exception("Welcome text is not visible!");
    }
}
