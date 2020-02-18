using DbContextAdoNet.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DbContextAdoNet
{
    class Program
    {
        public static string connectionString = @"Data Source=(localdb)\ProjectsV12;
                              Initial Catalog=EducationDB;Integrated Security=True";

        static void Main()
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

            SqlParameter par1 = new SqlParameter("Name", "MyTEST_NEW");
            SqlParameter par2 = new SqlParameter("DestroyDate", new DateTime(2020, 12, 20));
            SqlParameter par3 = new SqlParameter("PhoneNumber", "+37400000");
            SqlParameter par4 = new SqlParameter("Gender", 1);

            University univer = new University
            {
                Name = "Test",
                AddressId = 2,
                Email = "Test@test.am",
                PhoneNumber = "+3665555"
            };

            Console.WriteLine(rep.RemoveAt(1001));
            
            
        }
    }

}
