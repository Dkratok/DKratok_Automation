using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess
{
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;

    internal class Program
    {
        public static void Main(string[] args)
        {
            // Get provider and connection string from App.config
            string cnStr = ConfigurationManager.AppSettings["cnStr"];

            // Display data using stored procedure
            using (var cn = new SqlConnection())
            {
                Console.WriteLine("Connection object --> " + cn.GetType().Name);
                cn.ConnectionString = cnStr;
                cn.Open();
                var dt = GetCustomerHistoryUsingStorProc(cn, "ANTON");
            }

            //Delete not parametrized
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();
                int deleted = DeleteOrder("10267", cn);
                Console.WriteLine("Number of deleted rows: " + deleted);
            }

            //DeleteParametrized
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();
                int deleted = DeleteOrderParametrized("10268", cn);
                Console.WriteLine("Number of deleted rows: " + deleted);
            }

            // Display data using queries
            using (var cn = new SqlConnection())
            {
                Console.WriteLine("Connection object --> " + cn.GetType().Name);
                cn.ConnectionString = cnStr;
                cn.Open();
                DisplayTop5CustomersUsingDataTable(cn);
                DisplayTop5CustomersUsingDirectRead(cn);
            }

            Console.ReadLine();
        }

        //Get data using Load to DataTable object
        private static void DisplayTop5CustomersUsingDataTable(SqlConnection cn)
        {
            // Create command object
            DbCommand cmd = new SqlCommand();
            Console.WriteLine("Command object --> " + cmd.GetType().Name);
            cmd.Connection = cn;
            cmd.CommandText = "Select top 5 * From Customers";

            //read using DataTable
            var customers = new DataTable();
            using (var dr = cmd.ExecuteReader())
            {
                customers.Load(dr);
            }

            foreach (DataRow row in customers.Rows)
            {
                Console.WriteLine(
                    "-> CustomerID: {0}, CompanyName{1}, Customer name: {2}, Address: {3}, Region {4}\n",
                    row["CustomerID"],
                    row["CompanyName"],
                    row["ContactName"],
                    row["Address"],
                    row["Region"]);
            }
        }

        //Get data using Direct Read
        private static void DisplayTop5CustomersUsingDirectRead(SqlConnection cn)
        {
            // Create command object
            DbCommand cmd = new SqlCommand();
            Console.WriteLine("Command object --> " + cmd.GetType().Name);
            cmd.Connection = cn;
            cmd.CommandText = "Select top 5 * From Customers";

            // Read line by line using ExecuteReader::Read
            using (var dr = cmd.ExecuteReader())
            {
                Console.WriteLine("Read data object --> " + dr.GetType().Name);
                Console.WriteLine("\n*** Current content of Customer***\n");
                while (dr.Read())
                {
                    Console.WriteLine(
                        "-> CustomerID: {0}, CompanyName{1}, Customer name: {2}, Address: {3}, Region {4}\n",
                        dr["CustomerID"],
                        dr["CompanyName"],
                        dr["ContactName"],
                        dr["Address"],
                        dr["Region"]);
                }
            }
        }

        //Delete OrderDetails by id
        private static int DeleteOrder(string id, SqlConnection connection)
        {
            int numberOfAffectedRows = 0;
            string sql = string.Format("Delete from [Order Details] where OrderID = '{0}'", id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                try
                {
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    var error = new Exception("Couldn't delete the order", ex);
                    throw error;
                }
            }

            return numberOfAffectedRows;
        }

        //Delete OrderDetails by id
        private static int DeleteOrderParametrized(string id, SqlConnection connection)
        {
            int numberOfAffectedRows = 0;
            string sql = string.Format("Delete from [Order Details] where OrderID = @OrderID", id);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                try
                {
                    cmd.Parameters.AddWithValue("@OrderID", id);
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    var error = new Exception("Couldn't delete the order", ex);
                    throw error;
                }
            }

            return numberOfAffectedRows;
        }

        //Get Customer orders history using stored procedure
        private static DataTable GetCustomerHistoryUsingStorProc(SqlConnection connection, string customerId)
        {
            var customerOrders = new DataTable();
            using (SqlCommand cmd = new SqlCommand("CustOrderHist", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@CustomerID", SqlDbType.NChar, 5);
                parameter.Value = customerId;
                cmd.Parameters.Add(parameter);
                var dr = cmd.ExecuteReader();
                customerOrders.Load(dr);
            }

            return customerOrders;
        }
    }
}
