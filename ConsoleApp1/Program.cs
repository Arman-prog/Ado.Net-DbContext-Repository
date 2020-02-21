using Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Repository.Models;
using DbContextAdoNet.DataAccess;

namespace ConsoleApp1
{
    class Program
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV12;
                              Initial Catalog=EducationDB;Integrated Security=True";
        static void Main(string[] args)
        {
            var context = new DbContext(connectionString);

            /*
            BaseRepository<Student> studentrep = new BaseRepository<Student>(context);
            var studentlist = studentrep.AsEnumerable().ToList();

            BaseRepository<Teacher> teacherrep = new BaseRepository<Teacher>(context);
            var teacherlist = teacherrep.AsEnumerable().ToList();

            BaseRepository<University> univerrep = new BaseRepository<University>(context);
            var univerlist = univerrep.AsEnumerable().ToList();

            BaseRepository<Teacher_University> teach_univerrep = new BaseRepository<Teacher_University>(context);
            var teach_univerlist = teach_univerrep.AsEnumerable().ToList();

            BaseRepository<Address> addressrep = new BaseRepository<Address>(context);
            var addresslist = addressrep.AsEnumerable().ToList();


            var query1 = from s in studentlist
                        from u in univerlist
                        where u.Id == s.UniversityId
                        from a in addresslist
                         where a.Id == s.AddressId
                        select (s.FirstName, s.LastName,
                                a.City, a.StreetOrDistrict, a.House, a.Appartment,
                                u.Name);

           var stquery = query1.ToList();

           var query2 = from tu in teach_univerlist
                        from t in teacherlist
                        where t.Id == tu.TeacherId
                        from u in univerlist
                        where u.Id == tu.UniversityId
                        from a in addresslist
                        where a.Id == u.AddressId
                        select (t.FirstName, t.LastName,
                               u.Name, a.City);

           var teachersquery = query2.ToList();


           Console.WriteLine("QUERY - Students\n");
           foreach (var item in stquery)
           {
               Console.WriteLine(item);
           }
           Console.WriteLine();

           Console.WriteLine("QUERY - Teachers\n");
           foreach (var item in teachersquery)
           {
               Console.WriteLine(item);
           }

           */
            var rep = new BaseRepository<University>(context);

            University univer1 = new University
            {
                Name = "Taterakan",
                AddressId = 2,
                Email = "ttttt@aaaa.am",
                PhoneNumber = "+374333333"
            };

            Console.WriteLine("ADD " + rep.Add(univer1));

            Console.WriteLine("UPDATE "+rep.Update(2011,new University { DestroyDate=DateTime.Now}));

            Console.WriteLine("REMOVE "+rep.RemoveAt(4001));




        }
    }

}
