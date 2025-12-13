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
        public class InitRepos
        {
            public ScheduleRepository scheduleRep;
            public StationRepository stationRep;
            public ListStationRepository listStationRep;
            public BusRepository busRep;
            public RoutRepository routRep;
            public TripRepository tripRep;
            public ControlTripRepository controlTripRep;
            public ModelRepository modelRep;
            public BrandRepository brandRep;
            public ColorRepository colorRep;
            public EmployeeRepository employeeRep;
            public EmploymentHistoryRepository employmentHistoryRep;
            public PostRepository postRep;
            public StreetRepository streetRep;

            public InitRepos() 
            {
                streetRep = new StreetRepository();
                postRep = new PostRepository();
                employmentHistoryRep = new EmploymentHistoryRepository(postRep);
                employeeRep = new EmployeeRepository(postRep, streetRep, employmentHistoryRep);
                brandRep = new BrandRepository();
                modelRep = new ModelRepository(brandRep);
                colorRep = new ColorRepository();   
                busRep = new BusRepository(colorRep, modelRep);
                stationRep = new StationRepository();
                scheduleRep = new ScheduleRepository();
                listStationRep = new ListStationRepository(stationRep);
                routRep = new RoutRepository(scheduleRep, listStationRep);
                controlTripRep = new ControlTripRepository();
                tripRep = new TripRepository(routRep, employeeRep, busRep, controlTripRep);
            }
        }
        static void Main(string[] args)
        {

        }

    }
}
