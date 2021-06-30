using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EmployeeRegistration.Services
{
    public class ConnectionClass
    {
            protected string connectionString = "Server=DESKTOP-PPQEESA;Database=Employee;Trusted_Connection=True;";

            protected SqlConnection sqlConnection;
            protected SqlCommand sqlCommand;

            protected void connection()
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                   }
    }
}