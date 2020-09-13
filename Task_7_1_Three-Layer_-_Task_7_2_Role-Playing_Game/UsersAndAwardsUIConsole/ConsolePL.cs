using System;
using System.Linq;
using UsersAndAwards.Entities;
using UsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Dependences;
using static System.Console;

namespace UsersAndAwardsUIConsole
{
    public class ConsolePL
    {
        private IUserLogic userLogic = DependencyResolver.UserLogic;
        private IAwardLogic awardLogic = DependencyResolver.AwardLogic;
        private IBindingUserAwardLogic bindingUserAwardLogic = DependencyResolver.BindingUserAwardLogic;

        public void StartConsolePL()
        {
            WriteLine("Users and Awards. Implementation in the console.");
            int choice;

            do
            {
                WriteLine();
                WriteLine("This is main menu. Select one of the menu items:");
                WriteLine("0 - Exit");
                WriteLine("1 - User menu");
                WriteLine("2 - Award menu");
                WriteLine("Your choice:");
                choice = GetIntValueInput();
                switch (choice)
                {
                    case 0:
                        WriteLine("Press any key to exit");
                        break;
                    case 1:
                        ShowMenuOfUsers();
                        break;
                    case 2:
                        ShowMenuOfAwards();
                        break;
                    default:
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Select one of the existing options");
                        ResetColor();
                        break;
                }
            } while (choice != 0);
        }

        private void ShowMenuOfUsers()
        {
            int choice;

            do
            {
                WriteLine();
                WriteLine("This is a menu for working with users. Select one of the menu items:");
                WriteLine("0 - Return to Main menu");
                WriteLine("1 - Show Users");
                WriteLine("2 - Add Users");
                WriteLine("3 - Delete User");
                WriteLine("4 - Add Awards to User");
                WriteLine("5 - Remove User");

                choice = GetIntValueInput();
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        ShowUsers();
                        break;
                    case 2:
                        AddUser();
                        break;
                    case 3:
                        DeleteUser();
                        break;
                    case 4:
                        AddAdwardToUser();
                        break;
                    case 5:
                        DeleteAdwardFromUser();
                        break;
                    default:
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Select one of the existing options");
                        ResetColor();
                        break;
                }
            } while (choice != 0);
        }

        private void ShowUsers()
        {
            var users = userLogic.GetAll().ToList();

            if (users.Count == 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The list of Users is empty");
                ResetColor();
            }

            else
            {
                foreach (var item in users)
                {
                    WriteLine();
                    WriteLine($"ID: {item.ID}");
                    WriteLine($"Name: {item.Name}");
                    WriteLine($"Date of birgh: {item.DateOfBirth.ToString("MM/dd/yyyy")}");
                    WriteLine($"Age: {item.Age}");
                    Write("Awards: ");

                    var titles = from awardUser in bindingUserAwardLogic.GetAll(item.ID)
                                 join award in awardLogic.GetAll() on awardUser.AwardID equals award.ID
                                 select (award.Title);

                    foreach (var award in titles)
                    {
                        Write($"{award} ");
                    }
                    WriteLine();
                }
            }
        }

        private void AddUser()
        {
            WriteLine("Enter Name of User");
            var name = GetStringValueInput();

            Guid valueID = userLogic.Add(new User()
            {
                Name = name,
                DateOfBirth = GetDateOfBirth(),

            });

            ForegroundColor = ConsoleColor.Green;
            WriteLine($"A new user has been added. ID: {valueID}");
            ResetColor();
        }

        private void DeleteUser()
        {
            WriteLine("Enter User ID:");
            var valueID = GetGuidValueInput();

            if (IsUserInDataList(valueID))
            {
                userLogic.DeleteById(valueID);
                bindingUserAwardLogic.DeleteUser(valueID);
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The User was deleted.");
                ResetColor();
            }

            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The User with the entered ID does not exist.");
                ResetColor();
            }
        }

        private bool IsUserInDataList(Guid valueID)
        {
            var users = userLogic.GetAll().ToList();

            foreach (var item in users)
            {
                if (item.ID == valueID)
                {
                    return true;
                }
            }
            
            return false;
        }

        private void ShowMenuOfAwards()
        {
            int choice;

            do
            {
                WriteLine();
                WriteLine("This is a menu for working with users. Select one of the menu items:");
                WriteLine("0 - Return to Main menu");
                WriteLine("1 - Show Award");
                WriteLine("2 - Add Award");
                WriteLine("3 - Delete Award");

                choice = GetIntValueInput();
                switch (choice)
                {
                    case 0:
                        break;
                    case 1:
                        ShowAwards();
                        break;
                    case 2:
                        AddAward();
                        break;
                    case 3:
                        DeleteAward();
                        break;
                    default:
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Select one of the existing options");
                        ResetColor();
                        break;
                }
            } while (choice != 0);
        }

        private void ShowAwards()
        {
            var awards = awardLogic.GetAll().ToList();

            if (awards.Count() == 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The list of Awards is empty");
                ResetColor();
            }

            else
            {
                foreach (var item in awards)
                {
                    WriteLine($"ID: {item.ID}");
                    WriteLine($"Title: {item.Title}");
                }
            }
        }

        private void AddAward()
        {
            WriteLine("Enter title of Award");
            var title = GetStringValueInput();

            Guid valueID = awardLogic.Add(new Award()
            {
                Title = title
            });

            ForegroundColor = ConsoleColor.Green;
            WriteLine($"A new award has been added. ID: {valueID}");
            ResetColor();
        }

        private void DeleteAward()
        {
            WriteLine("Enter Award ID:");
            Guid valueID = GetGuidValueInput();

            if (IsAwardInDataList(valueID))
            {
                awardLogic.DeleteById(valueID);
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The Award was deleted.");
                ResetColor();
            }

            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The Award with the entered ID does not exist.");
                ResetColor();
            }
        }

        private bool IsAwardInDataList(Guid valueID)
        {
            var awards = awardLogic.GetAll().ToList();

            foreach (var item in awards)
            {
                if (item.ID == valueID)
                {
                    return true;
                }
            }
            
            return false;
        }

        private static int GetIntValueInput()
        {
            string inputID = ReadLine();
            int valueID;

            while (!int.TryParse(inputID, out valueID))
            {
                inputID = ReadLine();
            }

            return valueID;
        }

        private Guid GetGuidValueInput()
        {
            string inputID = ReadLine();
            Guid valueID;

            while (!Guid.TryParse(inputID, out valueID))
            {
                inputID = ReadLine();
            }

            return valueID;
        }

        private DateTime GetDateOfBirth()
        {
            DateTime inputDate;
            WriteLine("Enter date of birth in the format mm/dd/yyyy");

            while (!DateTime.TryParse(ReadLine(), out inputDate))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The value was entered incorrectly");
                ResetColor();
            }

            return inputDate;
        }

        private string GetStringValueInput()
        {
            string input = ReadLine();

            while (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Entered an empty value");
                ResetColor();
                input = ReadLine();
            }

            return input;
        }

        private void AddAdwardToUser()
        {
            WriteLine("Enter ID of User");
            Guid userID = GetGuidValueInput();

            if (userLogic.GetAll().Where(n => n.ID == userID).Count() == 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("A nonexistent user ID was entered");
                ResetColor();
            }

            else
            {
                WriteLine("Enter ID of Award");
                Guid awardID = GetGuidValueInput();

                if (IsBindingUserAwardInDataList(awardID, userID))
                {
                    bindingUserAwardLogic.Add(userID, awardID);
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("The Award is added to the User");
                    ResetColor();
                }

                else
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("The User already has such an Award");
                    ResetColor();
                }
            }
        }

        private void DeleteAdwardFromUser()
        {
            WriteLine("Enter ID of User");
            Guid userID = GetGuidValueInput();

            if (bindingUserAwardLogic.GetAll(userID).Count() == 0)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The User has no Awards");
                ResetColor();
            }

            else
            {
                WriteLine("Enter ID of Award");
                Guid awardID = GetGuidValueInput();

                if (!IsBindingUserAwardInDataList(userID, awardID))
                {
                    bindingUserAwardLogic.DeleteByID(userID, awardID);
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("The Award was deleted");
                    ResetColor();
                }
            }
        }

        private bool IsBindingUserAwardInDataList(Guid userID, Guid awardID)
        {
            var bindingUserAward = bindingUserAwardLogic.GetAll(userID).ToList();

            foreach (var item in bindingUserAward)
            {
                if (item.AwardID == awardID)
                {
                    return false;
                }
            }

            return true;
        }
    }
}