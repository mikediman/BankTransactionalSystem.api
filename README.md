# Final exercise

## Card limits

You have been assigned to implement a new feature in the bank's transactional system which sets **daily transaction limits**
to cards. A **card limit** is defined as the _maximum aggregate amount that a cardholder can spend each day_ and _depends on the transaction type_.
For `CardPresent` transactions, the daily limit is configured to 1500 EUR, while for `ECommerce` 
transactions is 500 EUR. 

Each time an _Authorization request_ is received, the system should ensure that:
1. The card's **balance** is adequate for the transaction to take place.
2. The aggregate amount does not exceed the daily limit.
	
A `Card` entity must contain at least:
- the card's number
- the Available balance
	
A `Limit` entity must contain at least:
- The Transaction type it refers to (either CardPresent or Ecommerce)
- The aggregate amount of the daily transactions
- The date for which the limit applies to
	
Authorization requests are forwarded to the bank's transactional system
by [Card Schemes](https://en.wikipedia.org/wiki/Card_scheme), to an "Authorize" endpoint and contain:
- The card number
- The `TransactionType`
- The transaction's amount
	
To inform Cardholders of their current spending, you are also required to create an API endpoint which accepts:
- The card's number
And returns the daily aggregate transactions amount.


### Requirements
- Implement the application model, business layers and database schema. The project's structure
must be in accordance with the class's standards. Separate project types must be used for the API and
the Core framework.
- C# coding conventions must be followed.
- The exercise's solution must be commited and pushed to a publicly accessible GIT repository
of your choice (Github, Bitbucket etc).
- Solutions that do not build correctly or do not comply to the above-mentioned specifications will
be disregarded.
- API endpoints should be implemented with the [REST architectural approach](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design#introduction-to-rest).