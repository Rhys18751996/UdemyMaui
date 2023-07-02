using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyMaui.MVVM.Models;

namespace UdemyMaui.Repositories
{
    public class CustomerRepository
    {
        SQLiteConnection connection;
        public string StatusMessage { get; set; }

        public CustomerRepository()
        {
            connection = new SQLiteConnection
                (
                    Constants.DatabasePath, 
                    Constants.Flags
                );
            // will only execute when there is no Customer table in database
            connection.CreateTable<Customer>();
        }

        public void AddOrUpdate(Customer customer)
        {
            int result = 0;
            try
            {
                if(customer.Id != 0)
                {
                    result = connection.Update(customer);
                    StatusMessage = $"{result} row(s) updated";
                }
                else
                {
                    result = connection.Insert(customer);
                    StatusMessage = $"{result} row(s) added";
                }
            }
            catch(Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
                return connection.Table<Customer>().ToList();
            }
            catch(Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public List<Customer> GetAll2()
        {
            try
            {
                return connection.Query<Customer>("SELECT * FROM Customers").ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public Customer Get(int id)
        {
            try
            {
                return connection.Table<Customer>().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }
            return null;
        }

        public void Delete(int id)
        {
            try
            {
                var customer = Get(id);
                connection.Delete(customer);
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error: {ex.Message}";
            }

        }
    }
}
