using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace LibraryProject
{
    [Binding]
    public class DataBaseWorkSteps
    {
        private SqlConnectorHelper _sqlHelper = (SqlConnectorHelper)ScenarioContext.Current["SqlHelper"];

        [When(@"I create row in table ""(.*)"" with data")]
        public void WhenICreateRowInTableWithData(string tableName, Table table)
        {
            string query = $"INSERT INTO {tableName} (FirstName, LastName, Age, City) " +
                $"VALUES ('{table.Rows[0]["FirstName"]}', '{table.Rows[0]["LastName"]}', '{Int32.Parse(table.Rows[0]["Age"])}', '{table.Rows[0]["City"]}')";
            _sqlHelper.MakeQuery(query);
        }

        [When(@"I select whole ""(.*)"" table")]
        public void WhenISelectWholeTable(string tableName)
        {
            string query = "SELECT * FROM Person";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["AuthorsTable"] = responseTable;
        }

        [Then(@"Table contains data")]
        public void ThenTableContainsData(Table table)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["AuthorsTable"];
            int numOfRows = responseTable.Rows.Count;
            string addedUserFirstName = responseTable.Rows[numOfRows - 1]["FirstName"].ToString();
            string addedUserLastName = responseTable.Rows[numOfRows - 1]["LastName"].ToString();
            string addedUserAge = responseTable.Rows[numOfRows - 1]["Age"].ToString();
            string addedUserCity = responseTable.Rows[numOfRows - 1]["City"].ToString();
            Assert.AreEqual(addedUserFirstName, table.Rows[0]["FirstName"]);
            Assert.AreEqual(addedUserLastName, table.Rows[0]["LastName"]);
            Assert.AreEqual(addedUserAge, table.Rows[0]["Age"]);
            Assert.AreEqual(addedUserCity, table.Rows[0]["City"]);
        }
    }
}