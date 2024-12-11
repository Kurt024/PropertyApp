using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace propertyApp
{
    class databaseHelper
    {
        private SQLiteConnection _connection; 

        public databaseHelper(string dbPath)
        {
            _connection = new SQLiteConnection(dbPath);
            _connection.CreateTable<userAccounts>();
            _connection.CreateTable<property>();
        }
        public void AddUser(userAccounts user)
        {
            _connection.Insert(user);
        }
        public userAccounts GetUserPhoneNum(string phoneNumber)
        {
            return _connection.Table<userAccounts>().FirstOrDefault(u => u.PhoneNumber == phoneNumber);
        }
        public userAccounts GetuserEmail(string email)
        {   
            return _connection.Table<userAccounts>().FirstOrDefault(u => u.Email == email);
        }
        public int SaveProperty(property property)
        {
            return _connection.Insert(property);
        }
        public List<property> GetProperties()
        {
            return _connection.Table<property>().ToList();
        }
        public property GetProperty(int id)
        {
            return _connection.Table<property>().FirstOrDefault(p => p.Id == id);
        }
        public int UpdateProperty(property property)
        {
            return _connection.Update(property);
        }
        public void DeleteProperty(int id)
        {
            var property = _connection.Table<property>().FirstOrDefault(p => p.Id == id);
            if (property != null)
            {
                _connection.Delete(property);
            }
        }

    }
}
