using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class Post
    {
        private decimal _salary;
        private string _namePost;

        public decimal Salary
        {
            get 
            {
                return _salary; 
            }
            set 
            { 
                if (value < 0) throw new ArgumentException("Оклад не может быть отрицательным.");
                _salary = value;
            }
        }
        
        public string NamePost
        {
            get { return _namePost; }
            set 
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Название должности не может быть пустым.");
                _namePost = value;
            }
        }
        public Post(string name, decimal salary) 
        {
            _namePost = name;
            _salary = salary;
        }
        public Post(string name, int salary) 
        {
            _namePost = name;
            _salary = salary;
        }

        public Post() { }
    }
}
