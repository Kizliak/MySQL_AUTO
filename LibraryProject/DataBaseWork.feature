Feature: DataBaseWork
	As a user
	I want to insert data to database
	In order to store it and select later

@InsertData
Scenario Outline:  It is possible to insert data to Library DB
	When I create row in table "Person" with data
		| FirstName   | LastName   | Age   | City   |
		| <firstName> | <lastName> | <age> | <city> |
	When I select whole "Person" table
	Then Table contains data
		| FirstName   | LastName   | Age   | City   |
		| <firstName> | <lastName> | <age> | <city> |
	Examples:
		| firstName | lastName | age | city |
		| Valera    | Dron     | 23  | Kyiv |
		| Nikolay   | Gnida    | 23  | Kyiv |