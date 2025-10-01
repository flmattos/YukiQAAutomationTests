using Microsoft.Playwright;
using Reqnroll;
using System;
using System.IO;
using System.Threading.Tasks;

[Binding]
public class Hooks
{
    private readonly World _world;
    private static IPlaywright _playwright;
    private static IBrowser _browser;
    private static IPage _page;
    private static IBrowserContext _context;
    private readonly string _solutionFolder;
    private static string _scenarioTracePath;

    public Hooks(World world)
    {
        _world = world;
        var assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var binFolder = Path.GetDirectoryName(assemblyPath);
        _solutionFolder = Directory.GetParent(binFolder).Parent.Parent.Parent.FullName;
        Directory.CreateDirectory(Path.Combine(_solutionFolder, "PlaywrightTraces"));
        var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
        _scenarioTracePath = Path.Combine(_solutionFolder, "PlaywrightTraces", $"trace_{timestamp}.zip");
    }

    [BeforeTestRun]
    public static async Task BeforeTestRun()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });
        _context = await _browser.NewContextAsync(new BrowserNewContextOptions
        {
            IgnoreHTTPSErrors = true
        });
        _page = await _context.NewPageAsync();
        await _context.Tracing.StartAsync(new()
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        _world.Page = _page;
    }

    [AfterTestRun]
    public static async Task AfterTestRun()
    {
        await _context.Tracing.StopAsync(new()
        {
            Path = _scenarioTracePath
        });
        await _context.CloseAsync();
        await _browser.CloseAsync();
        _playwright.Dispose();
    }
}