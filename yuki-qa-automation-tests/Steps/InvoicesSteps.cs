using Reqnroll;
using System.Threading.Tasks;
using yuki_qa_automation_tests.Pages;

[Binding]
public class InvoicesSteps
{
    private readonly World _world;
    private InvoicesPage _invoicesPage;
    public InvoicesSteps(World world)
    {
        _world = world;
        _invoicesPage = new InvoicesPage(_world.Page);
    }

    [When(@"I open the Invoices Page")]
    public async Task GivenINavigateInvoicesPage()
    {        
        await _invoicesPage.ClickOnInvoicesTab();
    }

    [Then(@"I get all the Amount values and the sum should be 963.97 EUR")]
    public async Task WhenGetAllAmountValues()
    {
        var invoiceCells = await _invoicesPage.GetInvoicesCellsAsync();
        decimal sum = 0m;
        foreach (var cell in invoiceCells)
        {
            var parts = cell.Split(' ');
            decimal amount = decimal.Parse(parts[0], System.Globalization.CultureInfo.InvariantCulture);
            sum += amount;        }

        string expectedTotal = $"{sum:F2} EUR";

        await _invoicesPage.AssertTotalAsync(expectedTotal);
    }

    [Then(@"the invoices title should be visible")]
    public async Task ThenInvoiceTitleVisible()
    {
        var visible = await _invoicesPage.IsInvoicesTitleVisibleAsync();
        if (!visible) throw new System.Exception("Invoices Title is not visible!");
    }

    [Then(@"the second invoice number should be visible")]
    public async Task ThenSecondInvoiceNumberTable()
    {
        await _invoicesPage.AssertInvoiceNumberAsync(1, 0, "I634");
    }

    [Then(@"the value of the Amount should be 423.99 EUR")]
    public async Task ThenSecondAmountTable()
    {
        await _invoicesPage.AssertRowAmountAsync(1, "423.99 EUR");
    }
}