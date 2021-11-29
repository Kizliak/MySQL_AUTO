using NUnit.Framework;
using System;
using System.Data;
using System.Threading;
using TechTalk.SpecFlow;

namespace GameShopMySqlTest
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
            string query = $"SELECT * FROM {tableName}";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["PersonTable"] = responseTable;
        }

        [Then(@"Table contains data")]
        public void ThenTableContainsData(Table table)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["PersonTable"];
            int numOfRows = responseTable.Rows.Count;
            string addedUserFirstName = responseTable.Rows[numOfRows - 1]["FirstName"].ToString();
            string addedUserLastName = responseTable.Rows[numOfRows - 1]["LastName"].ToString();
            string addedUserAge = responseTable.Rows[numOfRows - 1]["Age"].ToString();
            string addedUserCity = responseTable.Rows[numOfRows - 1]["City"].ToString();
            Assert.AreEqual(table.Rows[0]["FirstName"], addedUserFirstName);
            Assert.AreEqual(table.Rows[0]["LastName"], addedUserLastName);
            Assert.AreEqual(table.Rows[0]["Age"], addedUserAge);
            Assert.AreEqual(table.Rows[0]["City"], addedUserCity);
        }

        [Then(@"I delete added row in table ""(.*)""")]
        public void ThenIDeleteAddedRowInTable(string tableName, Table table)
        {
            string query = $"DELETE FROM {tableName} " +
            $"WHERE FirstName = '{table.Rows[0]["FirstName"]}' AND LastName = '{table.Rows[0]["LastName"]}' AND Age = {table.Rows[0]["Age"]} AND City = '{table.Rows[0]["City"]}'";
            _sqlHelper.MakeQuery(query);
        }

        [When(@"I select last row of ""(.*)"" table")]
        public void WhenISelectLastRowOfTable(string tableName)
        {
            string query = $"SELECT TOP 1 * FROM {tableName} ORDER BY ID DESC";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["LastRowInPersonTable"] = responseTable;
        }

        [Then(@"Last row of table contains data")]
        public void ThenLastRowOfTableContainsData(Table table)
        {
            DataTable responseTable = (DataTable)ScenarioContext.Current["LastRowInPersonTable"];
            int numOfRows = responseTable.Rows.Count;
            string addedUserFirstName = responseTable.Rows[numOfRows - 1]["FirstName"].ToString();
            string addedUserLastName = responseTable.Rows[numOfRows - 1]["LastName"].ToString();
            string addedUserAge = responseTable.Rows[numOfRows - 1]["Age"].ToString();
            string addedUserCity = responseTable.Rows[numOfRows - 1]["City"].ToString();
            Assert.AreEqual(table.Rows[0]["FirstName"], addedUserFirstName);
            Assert.AreEqual(table.Rows[0]["LastName"], addedUserLastName);
            Assert.AreEqual(table.Rows[0]["Age"], addedUserAge);
            Assert.AreEqual(table.Rows[0]["City"], addedUserCity);
        }

        [When(@"I replace data of last row of ""(.*)"" table")]
        public void WhenIReplaceDataOfLastRowOfTable(string tableName, Table table)
        {
            string query = $"UPDATE {tableName} " +
            $"SET FirstName = '{table.Rows[0]["FirstName"]}', LastName = '{table.Rows[0]["LastName"]}', Age = {table.Rows[0]["Age"]}, City = '{table.Rows[0]["City"]}'";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            ScenarioContext.Current["LastRowInPersonTable"] = responseTable;
        }

        [Then(@"I replace data of last row in ""(.*)"" table to origin")]
        public void ThenIReplaceDataOfLastRowInTableToOrigin(string tableName, Table table)
        {
            string query = $"UPDATE {tableName} " +
            $"SET FirstName = '{table.Rows[0]["FirstName"]}', LastName = '{table.Rows[0]["LastName"]}', Age = {table.Rows[0]["Age"]}, City = '{table.Rows[0]["City"]}'";
            _sqlHelper.MakeQuery(query);
        }

            [When(@"I update row in table ""(.*)"" with data")]
            public void WhenIUpdateRowInTableWithData(string p0, Table table)
            
            {
                int totalUpdateBy = 300;
                int quantityOfProduct;
                string query = $"UPDATE Orders Set Total = Total + {totalUpdateBy} WHERE OrderID = {13}";
                DataTable responseTable = _sqlHelper.MakeQuery(query);
                Assert.AreEqual(responseTable, table);
            }

       
        [Then(@"Table contains updated data")]
   public void ThenTableContainsUpdatedData() => Assert.That(ReferenceEquals(_sqlHelper, ScenarioContext.Current));


        [When(@"I update  data in table ""(.*)""")]
        public void WhenIUpdateDataInTable(string p0, Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Table contains new data")]
        public void ThenTableContainsNewData(Table table)
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"Table contains updated data")]
        public void ThenTableContainsUpdatedData(Table table)
        {
            ScenarioContext.Current.Pending();
        }

     }

      
      

    }



  