Feature: Home of Yuki Automation Page
  Scenario: Open Home page
    Given I open the Home Page
    Then the welcome text should be visible

  Scenario: Open Invoices page
    When I open the Invoices Page
    Then the invoices title should be visible

  Scenario: Open Privacy page
    When I open the Privacy Page
    Then the privacy title should be visible

  Scenario: Returns to Invoices page and validate invoice number
    When I open the Invoices Page
    Then the second invoice number should be visible
    And the value of the Amount should be 423.99 EUR

  Scenario: Sum of all amounts of invoice numbers
    Then I get all the Amount values and the sum should be 963.97 EUR