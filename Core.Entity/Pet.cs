using System;


namespace Core.Entity
{
    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string petType { get; set; }
        public string Color { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime sellDate { get; set; }
        public double Price { get; set; }
        public string PrevOwner { get; set; }


    }
}
