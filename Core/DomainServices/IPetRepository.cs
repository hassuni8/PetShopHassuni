using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);
        Pet Delete(int deletePet);
        Pet ReadPetById(int id);
        Pet UpdatePet(Pet updatedPet);
        IEnumerable<Pet> ReadPets();
    }
}
