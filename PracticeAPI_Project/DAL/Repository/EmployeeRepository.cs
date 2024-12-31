using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using Dapper;
using DapperApiDemo.Models;

namespace DapperApiDemo.Repositories
{
    public class EmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Employee>("SELECT * FROM Employees").ToList();
            }
        }

        public Employee GetEmployeeById(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.QuerySingleOrDefault<Employee>("SELECT * FROM Employees WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
