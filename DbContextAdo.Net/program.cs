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
           var students = context.AsEnumerable<Student>("SELECT * FROM Student").ToList();
           var teachers = context.AsEnumerable<Teacher>("SELECT * FROM Teacher").ToList();
           var universities = context.AsEnumerable<University>("SELECT * FROM University").ToList();
           var addresses = context.AsEnumerable<Address>("SELECT * FROM Address").ToList();
           var teachersuniversity = context.AsEnumerable<Teacher_University>("SELECT * FROM Teacher_University").ToList();

           var query1 = from s in students
                        from u in universities
                        where u.Id == s.UniversityId
                        from a in addresses
                        where a.Id == s.AddressId
                        select (s.FirstName, s.LastName,
                                a.City, a.StreetOrDistrict, a.House, a.Appartment,
                                u.Name);

           var stquery = query1.ToList();

           var query2 = from tu in teachersuniversity
                        from t in teachers
                        where t.Id == tu.TeacherId
                        from u in universities
                        where u.Id == tu.UniversityId
                        from a in addresses
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

            rep.Add(univer);
            var list = rep.AsEnumerable("SELECT * FROM University").ToList();

            foreach (University item in list)
            {
                Console.WriteLine(item);
            }

        }
    }

}
