Feature: DataBaseOrderTableWork
	As a user
	I want to insert data to database
	In order to store it and select later

@InsertDataInOrdersTable
Scenario Outline: It is possible to insert data to GameStore DB
	When I create row in "Orders" table with data
		| OrderNumber   | ProductName   | QuantityOfProduct   | Total    |
		| <orderNumber> | <productName> | <quantityOfProduct> | <total>  |
	When I select whole table  "Orders"
	Then Table contains this data
		| OrderNumber   | ProductName   | QuantityOfProduct   | Total    |
		| <orderNumber> | <productName> | <quantityOfProduct> | <total>  |
  #  When I delete last rows in table "Orders"
	 #   | OrderNumber   | ProductName   | QuantityOfProduct   | Total    |
		#| <orderNumber> | <productName> | <quantityOfProduct> | <total>  |
	Examples:
		| orderNumber | productName             | quantityOfProduct | total    |
		| 21          | Assassin Creed Valhalla | 2                 | 100.0000 |     
		| 22          | Daemon X Machina        | 0                 | 0.0000   |
		| 0           | 0                       | 0                 | 0.0000   |
      