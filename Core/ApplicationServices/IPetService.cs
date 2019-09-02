using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ApplicationServices
{
    public interface IPetService
    {
        Pet NewPet(string name, string prevOwner, string Color, string type, string birthDate, string price, string sellDate);
        Pet Delete(int id);
        Pet UpdatePet(Pet petUpdate);
        Pet CreatePet(Pet pet);
        Pet FindPetById(int id);
        List<Pet> PetsAscendingDescending();
        List<Pet> GetPets();
        List<Pet> GetTypePet(string type);
        List<Pet> find5Cheapest();

      

        
    }


}

