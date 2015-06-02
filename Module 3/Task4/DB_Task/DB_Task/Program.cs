using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataBaseAccess
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Get provider and connection string from App.config
            string cnStr = ConfigurationManager.AppSettings["cnStr"];

            //Select data 
            //using (var cn = new SqlConnection())
            //{
            //    Console.WriteLine("Connection object --> " + cn.GetType().Name);
            //    cn.ConnectionString = cnStr;
            //    cn.Open();
            //    DisplayTop5CustomersUsingDirectRead(cn);
            //}

            //Delete EmployeeTerritories
            //using (var cn = new SqlConnection())
            //{
            //    cn.ConnectionString = cnStr;
            //    cn.Open();
            //    int deleted = DeleteEmployeeTerritories(9, 48304, cn);
            //    Console.WriteLine("Number of deleted rows: " + deleted);
            //}


            //Update Customers
            using (var cn = new SqlConnection())
            {
                cn.ConnectionString = cnStr;
                cn.Open();
                int updated = UpdateCustomers("Chop-suey1", "Chop-suey", cn);
                Console.WriteLine("Number of updated rows: " + updated);
            }



            ////Insert a customers
            //using (var cn = new SqlConnection())
            //{          
            //    cn.ConnectionString = cnStr;
            //    cn.Open();
            //    int inserted = InsertCustomers("Cola", "ColaComp", "JohnA", "Owner", "Lenina28", "Minsk", "Minsk", "4576", "Belarus", "0300074321", "0300074321", cn);
            //    Console.WriteLine("Number of inserted rows: " + inserted);
            //}

            // //Display data using stored procedure
            //using (var cn = new SqlConnection())
            //{
            //    Console.WriteLine("Connection object --> " + cn.GetType().Name);
            //    cn.ConnectionString = cnStr;
            //    cn.Open();
            //    var dt = GetSalesbyYearUsingStorProc(cn, "2000-05-05", "2015-05-05");
            //}

            Console.ReadLine();
        }


        //Select data using Direct Read
        static void DisplayTop5CustomersUsingDirectRead(SqlConnection cn)
        {
            // Create command object
            DbCommand cmd = new SqlCommand();
            Console.WriteLine("Command object --> " + cmd.GetType().Name);
            cmd.Connection = cn;
            cmd.CommandText = "SELECT  [CustomerID] ,[CompanyName],[ContactName],[ContactTitle] ,[Address], [City], [Country], [Phone] FROM Customers where country = 'Germany' order by CompanyName";

            // Read line by line using ExecuteReader::Read
            using (var dr = cmd.ExecuteReader())
            {
                Console.WriteLine("Read data object --> " + dr.GetType().Name);
                Console.WriteLine("\n*** Current content of Customer***\n");
                while (dr.Read())
                {
                    Console.WriteLine(
                        "-> CustomerID: {0}, CompanyName: {1}, ContactName: {2}, ContactTitle: {3}, Address: {4}, City: {5}, Country: {6}, Phone: {7}\n",
                        dr["CustomerID"],
                        dr["CompanyName"],
                        dr["ContactName"],
                        dr["ContactTitle"],
                        dr["Address"],
                        dr["City"],
                        dr["Country"],
                        dr["Phone"]);
                }
            }
        }

        //Delete Employees by Last Name and BirthDate
        static int DeleteEmployeeTerritories(int EmployeeID, int TerritoryID, SqlConnection connection)
        {
            int numberOfAffectedRows = 0;
            string sql = string.Format("Delete from [EmployeeTerritories] where EmployeeID = '{0}' and TerritoryID= '{1}'", EmployeeID, TerritoryID);
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

        //Update Customer's CompanyName
        static int UpdateCustomers(string OldCompanyName, string NewCompanyName, SqlConnection connection)
        {
            int numberOfAffectedRows = 0;
            string sql = string.Format("Update [Customers] set CompanyName = '{1}' where CompanyName = '{0}'", NewCompanyName, OldCompanyName);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                try
                {
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    var error = new Exception("Couldn't update the order", ex);
                    throw error;
                }
            }

            return numberOfAffectedRows;
        }

        //Insert in Customers 
        static int InsertCustomers(string CustomerID, string CompanyName, string ContactName, string ContactTitle, string Address, string City, string Region, string PostalCode, string Country, string Phone, string Fax, SqlConnection connection)
        {
            int numberOfAffectedRows = 0;
            string sql = string.Format("Insert into [Customers] (CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax);
            using (SqlCommand cmd = new SqlCommand(sql, connection))
            {
                try
                {
                    numberOfAffectedRows = cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    var error = new Exception("Couldn't insert the row(s)", ex);
                    throw error;
                }
            }

            return numberOfAffectedRows;
        }

        //Get Customer orders history using stored procedure
        private static DataTable GetSalesbyYearUsingStorProc(SqlConnection connection, string Beginning_Date, string Ending_Date)
        {
            var SalesbyYear = new DataTable();
            using (SqlCommand cmd = new SqlCommand("Sales by Year", connection))
            {
             
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter1 = new SqlParameter("@Beginning_Date", SqlDbType.DateTime);
                parameter1.Value = Beginning_Date;
                cmd.Parameters.Add(parameter1);
                SqlParameter parameter2 = new SqlParameter("@Ending_Date", SqlDbType.DateTime);
                parameter2.Value = Ending_Date;
                cmd.Parameters.Add(parameter2);
                            
                
                    var dr = cmd.ExecuteReader();       
                    SalesbyYear.Load(dr);
                        
            }

            return SalesbyYear;
        }

    }
}