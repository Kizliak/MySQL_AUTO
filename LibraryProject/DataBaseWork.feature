Feature: DataBaseWork
	As a user
	I want to insert data to database
	In order to store it and select later

@InsertData
Scenario Outline:  It is possible to insert data to GameShop DB
	When I create row in table "Person" with data
		| FirstName   | LastName   | Age   | City   |
		| <firstName> | <lastName> | <age> | <city> |
	When I select whole "Person" table
	Then Table contains data
		| FirstName   | LastName   | Age   | City   |
		| <firstName> | <lastName> | <age> | <city> |
	Then I delete added row in table "Person"
		| FirstName   | LastName   | Age   | City   |
		| <firstName> | <lastName> | <age> | <city> |
	Examples:
		| firstName | lastName | age | city   |
		| Valera    | Dron     | 23  | Kyiv   |
		| Nikolay   | Gnida    | 25  | Kyiv   |
		| Sergey    | Maslov   | 24  | Odessa |

@ModifyData
Scenario Outline: It is possible to change data of row in GameShop DB
	When I select last row of "Person" table
	Then Last row of table contains data
		| FirstName | LastName | Age | City |
		| Evgen     | Kasimov  | 39  | Kyiv |
	When I replace data of last row of "Person" table
		| FirstName   | LastName   | Age   | City   |
		| <firstName> | <lastName> | <age> | <city> |
	When I select last row of "Person" table
	Then Last row of table contains data
		| FirstName   | LastName   | Age   | City   |
		| <firstName> | <lastName> | <age> | <city> |
	Then I replace data of last row in "Person" table to origin
		| FirstName | LastName | Age | City |
		| Evgen     | Kasimov  | 39  | Kyiv |
	Examples:
		| firstName | lastName | age | city   |
		| Valera    | Dron     | 23  | Kyiv   |
		| Nikolay   | Gnida    | 25  | Kyiv   |
		| Sergey    | Maslov   | 24  | Odessa |