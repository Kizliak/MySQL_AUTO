using NUnit.Framework;
using System;
using System.Data;
using TechTalk.SpecFlow;

namespace GameShopMySqlTest
{
    [Binding]
    public class OrdersTableSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private SqlConnectorHelper _sqlHelper;

        public OrdersTableSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _sqlHelper = _scenarioContext.Get<SqlConnectorHelper>("SqlHelper");
        }

        [When(@"I create row in ""(.*)"" table with data")]
        public void WhenICreateRowInTableWithData(string tableName, Table table)
        {
            string query = $"INSERT INTO {tableName} (OrderNumber, ProductName, QuantityOfProduct, Total) " +
                $"VALUES ('{Int32.Parse(table.Rows[0]["OrderNumber"])}', '{table.Rows[0]["ProductName"]}', " +
                $"{Int32.Parse(table.Rows[0]["QuantityOfProduct"])}, '{Double.Parse(table.Rows[0]["Total"])}')";
            _sqlHelper.MakeQuery(query);
        }
        
        [When(@"I select whole table  ""(.*)""")]
        public void WhenISelectWholeTable(string tableName)
        {
            string query = $"SELECT * FROM {tableName}";
            DataTable responseTable = _sqlHelper.MakeQuery(query);
            _scenarioContext["OrdersTable"] = responseTable;
        }

        [Then(@"Table contains this data")]
        public void ThenLastRowInTableContainsData(Table table)
        {
            DataTable responseTable = _scenarioContext.Get<DataTable>("OrdersTable");
            int numOfRows = responseTable.Rows.Count;
            string addedOrderNumber = responseTable.Rows[numOfRows - 1]["OrderNumber"].ToString();
            string addedProductName = responseTable.Rows[numOfRows - 1]["ProductName"].ToString();
            string addedQuantityOfProduct = responseTable.Rows[numOfRows - 1]["QuantityOfProduct"].ToString();
            string addedTotal = responseTable.Rows[numOfRows - 1]["Total"].ToString();
            Assert.AreEqual(addedOrderNumber, table.Rows[0]["OrderNumber"]);
            Assert.AreEqual(addedProductName, table.Rows[0]["ProductName"]);
            Assert.AreEqual(addedQuantityOfProduct, table.Rows[0]["QuantityOfProduct"]);
            Assert.AreEqual(addedTotal, table.Rows[0]["Total"]);
        }

        //[When(@"I delete last rows in table ""(.*)""")]
        //public void WhenIDeleteLastRowsInTable(string tableName)
        //{
        //    DataTable responseTable = _scenarioContext.Get<DataTable>("OrdersTable");
        //    int numOfRows = responseTable.Rows.Count;
        //    int lastOrderId = int.Parse(responseTable.Rows[numOfRows - 1]["OrderID"].ToString());
        //    string query = $"DELETE FROM {tableName} WHERE OrderID={lastOrderId};";
        //    _sqlHelper.MakeQuery(query);
        //}
    }
}
