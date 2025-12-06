using CourseDB.Data;
using CourseDB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace CourseDB
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            BrandRepository brandRepository = new BrandRepository();
            ModelRepository modelRepository = new ModelRepository(brandRepository);
            ColorRepository colorRepository = new ColorRepository();

            var bus = new Bus(
                inventoryNumber: "ИНВ-001",
                registrationNumber: "А123АА77",
                model: modelRepository.GetAll()[0],
                engineNumber: "ENG-2023-001",
                bodyNumber: "BODY-2023-001",
                chassisNumber: "CH-2023-001",
                mileage: 15000,
                color: "Белый",
                manufactureDate: new DateTime(2023, 1, 15),
                state: BusState.InOperation,
                lastOverhaulDate: null
            );

            BusRepository busRepository = new BusRepository(colorRepository, modelRepository);

            busRepository.Save(bus);
            busRepository.GetAll();
            var r = busRepository.GetAll()[0];
            //PostRepository repository = new PostRepository();
            //EmploymentHistoryRepository employmentHistoryRepository = new EmploymentHistoryRepository(repository);

            // employeeRepository = new EmployeeRepository(repository, str_repository, employmentHistoryRepository);

            //employeeRepository.Save(new Employee("Tair", "Bik", Gender.M, DateTime.Now.AddYears(-20), new Address(str_repository.GetAll()[1].StreetName, "23a", "32"), repository.GetAll()[0], 0));
            //Employee emp = employeeRepository.GetAll()[0];
            //employeeRepository.SetStatusOfArchive(emp);

        }
    }
}
