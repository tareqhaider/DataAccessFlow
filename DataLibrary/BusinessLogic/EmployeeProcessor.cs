using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLibrary.DataAccess;
using DataLibrary.DomainModels;

namespace DataLibrary.BusinessLogic
{
    public static class EmployeeProcessor
    {
        public static int CreateEmployee(int employeeId, string firstname, string lastName, string email)
        {
            EmployeeModel data = new EmployeeModel
            {
                EmployeeId = employeeId,
                FirstName = firstname,
                LastName = lastName,
                Email = email
            };

            string sql = @"INSERT INTO dbo.Employee (EmployeeId, FirstName, LastName, Email)
                            VALUES (@EmployeeId, @FirstName, @LastName, @Email);";

            return SqlDataAccess.SaveData(sql, data);
        }

        public static List<EmployeeModel> LoadEmployees()
        {
            string sql = @"SELECT Id, EmployeeId, FirstName, LastName, Email
                            FROM dbo.Employee;";

            return SqlDataAccess.LoadData<EmployeeModel>(sql);
        }
    }

    
}
