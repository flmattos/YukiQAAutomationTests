using Microsoft.Playwright;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace yuki_qa_automation_tests.Pages;

public class InvoicesPage
{
    private readonly IPage _page;

    public InvoicesPage(IPage page)
    {
        _page = page;
    }
    private ILocator InvoicesTitle => _page.GetByRole(AriaRole.Link, new() { Name = "Invoices" });
    private ILocator InvoicesCells => _page.Locator("tbody tr:not(.summary-row) td.number-cell");
    private ILocator InvoicesCellsAmountTotal => _page.Locator("tbody tr.summary-row td.number-cell");
    private ILocator Rows => _page.Locator("tbody tr");
    private ILocator GetCell(int rowIndex, int cellIndex)
    {
        return Rows.Nth(rowIndex).Locator("td").Nth(cellIndex);
    }
    private ILocator GetAmountCell(int rowIndex)
    {
        return Rows.Nth(rowIndex).Locator("td.number-cell");
    }
    public async Task AssertRowAmountAsync(int rowIndex, string expectedValue)
    {
        var cell = GetAmountCell(rowIndex);
        await Assertions.Expect(cell).ToHaveTextAsync(expectedValue);
    }
    public async Task AssertInvoiceNumberAsync(int rowIndex, int cellIndex, string expectedValue)
    {
        var cell = GetCell(rowIndex, cellIndex);
        await Assertions.Expect(cell).ToHaveTextAsync(expectedValue);
    }

    public async Task<bool> IsInvoicesTitleVisibleAsync()
    {
        return await InvoicesTitle.IsVisibleAsync();
    }

    public async Task ClickOnInvoicesTab()
    {
        await InvoicesTitle.ClickAsync();
    }

    public async Task<IReadOnlyList<string>> GetInvoicesCellsAsync()
    {
        return await InvoicesCells.AllInnerTextsAsync();
    }

    public async Task AssertTotalAsync(string expectedTotal)
    {
        await Assertions.Expect(InvoicesCellsAmountTotal).ToHaveTextAsync(expectedTotal);
    }
}