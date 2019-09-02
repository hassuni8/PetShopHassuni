using System;
using System.Collections.Generic;
using System.Linq;

using Core.DomainServices;
using Core.Entity;

namespace Core.ApplicationServices.Impl
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public Pet NewPet(string name, string prevOwner, string Color, string type, string birthday, string price, string soldDate)
        {
            var pet = new Pet()
            {
                Name = name,
                PrevOwner = prevOwner,
                Color = Color,
                petType = type,
                birthDate = DateTime.Parse(birthday),
                Price = double.Parse(price),
                sellDate = DateTime.Parse(soldDate)
            };

            return pet;
        }


        public List<Pet> GetTypePet(string type)
        {
            var list = _petRepository.ReadPets();

            var sortedList = list.Where(pet => pet.petType.Equals(type));
            return sortedList.ToList();
        }


        public Pet FindPetById(int id)
        {
            return _petRepository.ReadPetById(id);
        }

        public Pet CreatePet(Pet pet)
        {
            return _petRepository.CreatePet(pet);
        }


        public List<Pet> find5Cheapest()
        {
            var list = PetsAscendingDescending();

            var sortedList = list.OrderBy(pet => pet.Price).Take(5);
            return sortedList.ToList();
        }

        public List<Pet> PetsAscendingDescending()
        {
            var list = _petRepository.ReadPets();

            var orderedList = list.OrderBy(pet => pet.Price);
            return orderedList.ToList();
        }



        public List<Pet> GetPets()
        {
            return _petRepository.ReadPets().ToList();
        }





        

        public Pet UpdatePet(Pet petUpdate)
        {
            var pet = FindPetById(petUpdate.ID);

            pet.Name = petUpdate.Name;
            pet.PrevOwner = petUpdate.PrevOwner;
            pet.Color = petUpdate.Color;
            pet.petType = petUpdate.petType;
            pet.birthDate = petUpdate.birthDate;
            pet.Price = petUpdate.Price;
            pet.sellDate = petUpdate.sellDate;
            return pet;
        }

        public Pet Delete(int id)
        {
            return _petRepository.Delete(id);
        }
    }
}
