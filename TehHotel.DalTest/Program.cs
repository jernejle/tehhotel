using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TehHotel.Contracts.Data;
using TehHotel.Dal;
using TehHotel.Dal.Models.Dao;

namespace TehHotel.DalTest
{
    class Program
    {
        //private static void Main(string[] args)
        //{
        //    using (var db = new TehHotelContext())
        //    {
        //        db.Database.Initialize(true);
        //        Console.WriteLine("DATABASE INITIALIZED");
        //        Console.ReadLine();
        //    }

        //}

        private static void Main(string[] args)
        {
            ZaposleniEFDao z = new ZaposleniEFDao();
            Zaposleni z2 = z.Read(23);
            z2.Ime="asdsada";
            z.Update(z2);

            Console.Write("DONE");
            Console.ReadLine();

        }
    }
}
