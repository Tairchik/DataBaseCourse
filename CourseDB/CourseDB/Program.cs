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
            // Создание репозиториев
            var stationRepository = new StationRepository();
            var scheduleRepository = new ScheduleRepository();
            var listStationRepository = new ListStationRepository(stationRepository);
            var routRepository = new RoutRepository(scheduleRepository, listStationRepository);

            foreach (var v in stationRepository.GetAll()) 
            {
                stationRepository.Delete(v.Id);
            }

        }
    }
}
