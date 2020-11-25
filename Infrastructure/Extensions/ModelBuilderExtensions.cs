using System;
using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<PlotType>().HasData(
            //    new PlotType
            //    {
            //        Id = 1,
            //        Name = "BRONZE"
            //    },
            //    new PlotType
            //    {
            //        Id = 2,
            //        Name = "SILVER"
            //    },
            //    new PlotType
            //    {
            //        Id = 3,
            //        Name = "GOLD"
            //    }
            //);

            //modelBuilder.Entity<Plot>().HasData(

                //new Plot { Id = 2, Name = "Plot 126 - Arkansas", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 3, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 3, Name = "Plot 512 - Arizona", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 2, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 4, Name = "Plot 100C - Junea", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 5, Name = "Plot 610 - Anchorage", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 3, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 6, Name = "Plot 100B - Phonenix", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 2, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 7, Name = "Plot 181A - Sacramento", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 8, Name = "Plot 162 - Hartford", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 9, Name = "Plot 812 - Dover", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 3, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 10, Name = "Plot 809 - Tallahassee", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 3, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 11, Name = "Plot 132 - Honolulu)", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 3, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 12, Name = "Plot 113 - Topeka", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 2, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 13, Name = "Plot 103 - Des Moines", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 2, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 14, Name = "Plot 100A - Boston Lansing", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 2, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 15, Name = "Plot 201 - Louisville", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 3, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 16, Name = "Plot 197 - Nankling Tushe, West Bridge", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 17, Name = "Plot 1960 - Augusta Manopolis", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 18, Name = "Plot 111 - Cheyenne", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 19, Name = "Plot 122 - Virginia Campton", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 2, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 20, Name = "Plot 121B - Madison", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 2, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },


                //new Plot { Id = 21, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 22, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 23, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 24, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 25, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 26, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 27, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 28, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 29, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 30, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 31, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 32, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 33, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 34, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 35, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 36, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 37, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 38, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 39, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 40, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },


                //new Plot { Id = 41, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 42, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 43, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 44, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 45, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 46, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 47, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 48, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 49, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 50, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 51, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 52, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 53, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 54, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 55, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 56, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 57, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 58, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 59, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now },
                //new Plot { Id = 60, Name = "Plot ", Acres = 30.0, Address = "Block 8A Balogun Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now }
                //new Plot { Id = 61, Name = "Plot 1289, Road 6B - Alabama", Acres = 30.0, Address = "1289 Road, Alabama Ogundaide Street, Orange Island", PlotTypeId = 1, Lattitude = 33.4, Longitude = 45.9, IsAvailable = true, IsEnabled = true, DateCreated = DateTime.Now, DateModified = DateTime.Now }
            //);
        }
    }
}
