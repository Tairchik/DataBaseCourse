using CourseDB.Data;
using CourseDB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CourseDB
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            StreetRepository str_repository = new StreetRepository();
            PostRepository repository = new PostRepository();
            EmploymentHistoryRepository employmentHistoryRepository = new EmploymentHistoryRepository(repository);
            
            EmployeeRepository employeeRepository = new EmployeeRepository(repository, str_repository, employmentHistoryRepository);

            //employeeRepository.Save(new Employee("Tair", "Bik", Gender.M, DateTime.Now.AddYears(-20), new Address(str_repository.GetAll()[1].StreetName, "23a", "32"), repository.GetAll()[0], 0));
            //Employee emp = employeeRepository.GetAll()[0];
            //employeeRepository.SetStatusOfArchive(emp);

        }
    }
}
