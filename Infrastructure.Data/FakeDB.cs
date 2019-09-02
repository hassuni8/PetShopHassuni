using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Infrastructure.Data
{
    public static class FakeDB
    {
        internal static int id = 1;
        private static List<Pet> _pets = new List<Pet>();


        public static List<Pet> getPets()
        {
            return _pets.ToList();
        }

        public static void InitData()
        {
            Pet Lizard = new Pet()
            {
                
                Name = "Bongo",
                birthDate = new DateTime(1950, 3, 2),
                PrevOwner = "Karl",
                Color = "Blue",
                
                Price = 25000,
                petType = "Lizard",
                sellDate = new DateTime(1980, 4, 8),
                ID = id++

            };

            Pet Cat = new Pet()
            {
                
                Name = "Suzi",
                birthDate = new DateTime(2016, 4, 20),
                PrevOwner = "Sofie",
                Color = "Grey",
                Price = 800000,
                petType = "Cat",
                sellDate = new DateTime(2016, 3, 5),
                ID = id++,

            };

            Pet Dog = new Pet()
            {
                
                Name = "Vega",
                birthDate = new DateTime(1994, 1, 9),
                PrevOwner = "Jørgen",
                Color = "Grey",
                Price = 58000,
                petType = "Dog",
                sellDate = new DateTime(1998, 4, 9),
                ID = id++
            };

            Pet Dog2 = new Pet()
            {
                
                Name = "Balder",
                birthDate = new DateTime(2000, 4, 1),
                PrevOwner = "Adoption center",
                Color = "White",
                Price = 100,
                petType = "Dog",
                sellDate = new DateTime(2007, 4, 6),
                ID = id++
            };

            Pet Cat2 = new Pet()
            {
                
                Name = "Mati",
                birthDate = new DateTime(2007, 9, 12),
                PrevOwner = "Gertrude",
                Color = "White",
                Price = 30000000,
                petType = "Cat",
                sellDate = new DateTime(2010, 2, 10),
                ID = id++
            };

            Pet Goat = new Pet()
            {
                
                Name = "Goatie",
                birthDate = new DateTime(1987, 6, 4),
                PrevOwner = "Karl",
                Color = "Grey",
                Price = 19000,
                petType = "Goat",
                sellDate = new DateTime(2006, 1, 1),
                ID = id++
            };

            _pets.Add(Cat);
            _pets.Add(Dog);
            _pets.Add(Goat);
            _pets.Add(Lizard);
            _pets.Add(Dog2);
            _pets.Add(Cat2);

        }
    }
}
