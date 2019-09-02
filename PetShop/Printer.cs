using Core.ApplicationServices;

using Core.Entity;

using System;
using System.Collections.Generic;


namespace ConsoleApp
{
    class Printer : IPrinter
    {
        private IPetService _petService;
        public Printer(IPetService petService)
        {
            _petService = petService;
        }

        string[] menuItems =
        {
            "List all pets",
            "Add a pet",
            "Edit a pet",
            "Delete a pet",
            "Show pets by price",
            "Show the five cheapest pets",
            "Search for a pet by type",
            "Exit"
        };

        public void StartUI()
        {
            var selection = ShowMenu(menuItems);

            while (selection != 8)
            {
                switch (selection)
                {
                    case 1:
                        Console.Clear();
                        var pets = _petService.GetPets();
                        petList(pets);
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.Clear();
                        var Name = GetQuestion("Please enter the name: ");
                        var prevOwner = GetQuestion("Please enter the previous owner: ");
                        var Color = GetQuestion("Please enter the color: ");
                        var Type = GetQuestion("Please enter the type of animal: ");
                        var birthDate = GetQuestion("Please enter the birthdate: (YYYY/MM/DD)");
                        var Price = GetQuestion("Please enter the price: ");
                        var sellDate = GetQuestion("Please enter the sell date: (YYYY/MM/DD)");

                        var pet = _petService.NewPet(Name, prevOwner, Color, Type, birthDate, Price, sellDate);
                        _petService.CreatePet(pet);
                        Console.WriteLine("Press enter to continue...");
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        var idForEdit = FindPetById();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = GetQuestion("Please enter the name:");
                        var newPrevOwner = GetQuestion("Please enter the previous owner: ");
                        var newColor = GetQuestion("Please enter the color: ");
                        var newType = GetQuestion("Please enter the type of animal: ");
                        var newBirthday = GetQuestion("Please enter the birthdate: (YYYY/MM/DD)");
                        var newPrice = GetQuestion("Please enter the price: ");
                        var newSoldDate = GetQuestion("Please enter the sell date: (YYYY/MM/DD)");

                        _petService.UpdatePet(new Pet()
                        {
                            ID = idForEdit,
                            Name = newName,
                            PrevOwner = newPrevOwner,
                            Color = newColor,
                            petType = newType,
                            birthDate = DateTime.Parse(newBirthday),
                            Price = double.Parse(newPrice),
                            sellDate = DateTime.Parse(newSoldDate)
                        });
                        Console.WriteLine("Press enter to continue...");
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        var idForDelete = FindPetById();
                        _petService.Delete(idForDelete);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 5:
                        Console.Clear();
                        pets = _petService.PetsAscendingDescending();
                        petList(pets);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                        case 6:
                        Console.Clear();
                        pets = _petService.find5Cheapest();
                        petList(pets);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        Console.Clear();
                        var typePet = GetQuestion("Which type pet do you want to find?: ");
                        pets = _petService.GetTypePet(typePet);
                        petList(pets);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Good day!");

            Console.ReadLine();
        }
        string GetQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        private int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Please input a number to select your menu option: \n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine((i + 1) + ":" + menuItems[i]);
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 9)
            {
                Console.WriteLine("Please insert a number between 1 and 8");
            }


            return selection;
        }
        private void petList(List<Pet> pets)
        {
            Console.WriteLine("\nList of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine("ID: " + pet.ID +
                    ", \nName: " + pet.Name +
                    ", \nColor: " + pet.Color +
                    ", \nType: " + pet.petType +
                    ", \nPrice: " + pet.Price +
                    ", \nPrevious Owner: " + pet.PrevOwner +
                    ", \nBirthday: " + pet.birthDate +
                    ", \nSold Date: " + pet.sellDate + "\n");
            }
            Console.WriteLine("\n");
        }

        int FindPetById()
        {
            Console.WriteLine("Enter pet id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return id;
        }
    }

}