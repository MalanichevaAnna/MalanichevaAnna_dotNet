using BLL.Model;
using BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace TouristConsole
{
    public class PresentationMenu
    {
        private readonly PresentationHotel presentationHotel;
        private readonly PresentationTravelVoucher presentationTravelVoucher;
        private readonly PresentationUser presentationUser;
        public PresentationMenu(PresentationHotel presentationHotel, PresentationTravelVoucher presentationTravelVoucher, PresentationUser presentationUser)
        {
            this.presentationHotel = presentationHotel;
            this.presentationTravelVoucher = presentationTravelVoucher;
            this.presentationUser = presentationUser;
        }

        public void PrintMenu()
        {
            int numberMenu = -1;
            while (numberMenu != 0)
            {
                Menu();
                Console.Write("\t:");
                numberMenu = Convert.ToInt32(Console.ReadLine());

                switch (numberMenu)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.Write("Input firstname: ");
                            var firstName = Console.ReadLine();
                            Console.Write("Input lastname: ");
                            var lastName = Console.ReadLine();
                            Console.Write("Input middlename: ");
                            var middleName = Console.ReadLine();
                            Console.Write("Input address: ");
                            var address = Console.ReadLine();
                            Console.Write("Input phone");
                            var phone = Console.ReadLine();
                            var user = new UserDTO
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                MiddleName = middleName,
                                Address = address,
                                Phone = phone,

                            };
                            presentationUser.CreateUser(user);
                            break;
                        }
                    //case 2:
                    //    {
                    //        Console.Clear();
                    //        PresentationUser.UpdateUser();
                    //        break;
                    //    }
                    case 3:
                        {
                            Console.Clear();
                            var user = new UserDTO
                            {
                                Id = 1,
                                FirstName = "Anna",
                                LastName = "Malanicheva",
                                MiddleName = "Srgeevna",
                                Address = "Z. Kosmodem",
                                Phone = "1233112",

                            };
                           
                            presentationUser.DeleteUser(user);
                            break;
                        }

                    //case 4:
                    //    {
                    //        Console.Clear();
                    //        PresentationHotel.CreateHotel();
                    //        break;
                    //    }
                    //case 5:
                    //    {
                    //        Console.Clear();
                    //        PresentationHotel.UpdateHotel();
                    //        break;
                    //    }
                    //case 6:
                    //    {
                    //        Console.Clear();
                    //        PresentationHotel.DeleteHotel();
                    //        break;
                    //    }
                    //case 7:
                    //    {
                    //        Console.Clear();
                    //        PresentationTravelVoucher.CreateTravelVoucher();
                    //        break;
                    //    }
                    //case 8:
                    //    {
                    //        Console.Clear();
                    //        PresentationTravelVoucher.UpdateTravelVoucher();
                    //        break;
                    //    }
                    //case 9:
                    //    {
                    //        Console.Clear();
                    //        PresentationTravelVoucher.DeleteTravelVoucher();
                    //        break;
                    //    }
                    case 10:
                        {
                            Console.Clear();
                            presentationUser.GetCollectionUsers().ToList().ForEach(el => Console.WriteLine(el));
                            break;
                        }
                    case 11:
                        {
                            Console.Clear();
                            presentationHotel.GetCollectionHotels().ToList().ForEach(el => Console.WriteLine(el));
                            
                            break;
                        }
                    case 12:
                        {
                            Console.Clear();
                            presentationTravelVoucher.GetCollectionTravelVouchers().ToList().ForEach(el => Console.WriteLine(el));
                            break;
                        }
                    case 0:
                        {
                            numberMenu = 0;
                            break;
                        }
                }
            }
        }
        private void Menu()
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1. Добавить клиента");
            Console.WriteLine("2. Обновить клиента");
            Console.WriteLine("3. Удалить клинта");
            Console.WriteLine("");
            Console.WriteLine("4. Добавить отель");
            Console.WriteLine("5. Обновить отель");
            Console.WriteLine("6. Удалить отель");
            Console.WriteLine();
            Console.WriteLine("7. Добавить путевку");
            Console.WriteLine("8. Обновить путевку");
            Console.WriteLine("9. Удалить путевку");
            Console.WriteLine("");
            Console.WriteLine("10. Вывести список клиентов");
            Console.WriteLine("11. Вывести список отелей");
            Console.WriteLine("12. Вывести списк путевок");
            Console.WriteLine();
            Console.WriteLine("0. Выход");

            Console.WriteLine();
        }
    }
}
