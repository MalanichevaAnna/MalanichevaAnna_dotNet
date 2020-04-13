using BLL.Model;
using System;
using System.Linq;
namespace TouristConsole
{
    public class PresentationMenu
    {

        private readonly PresentationHotel presentationHotel;
        private readonly PresentationTravelVoucher presentationTravelVoucher;
        private readonly PresentationUser presentationUser;
        private readonly PresentationStaff presentationStaff;
        private readonly PresentationService presentationService;
        public PresentationMenu(PresentationHotel presentationHotel, PresentationTravelVoucher presentationTravelVoucher, 
                                PresentationUser presentationUser, PresentationStaff presentationStaff,
                                PresentationService presentationService)
        {
            this.presentationHotel = presentationHotel;
            this.presentationTravelVoucher = presentationTravelVoucher;
            this.presentationUser = presentationUser;
            this.presentationStaff = presentationStaff;
            this.presentationService = presentationService;
        }

        public void StartAppSession()
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
                            var user = new User
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                MiddleName = middleName,
                                Address = address,
                                Phone = phone,

                            };
                            presentationUser.CreateUser(user);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.Write("Input id user: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var user = presentationUser.GetCollectionUsers().Result.Where(el => el.Id == id).FirstOrDefault();
                            if(user != null)
                            {
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
                                user.FirstName = firstName;
                                user.LastName = lastName;
                                user.MiddleName = middleName;
                                user.Address = address;
                                user.Phone = phone;
                                presentationUser.UpdateUser(user);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.Write("Input id user for delete: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            presentationUser.DeleteUser(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            Console.Write("Input name: ");
                            var name = Console.ReadLine();
                            Console.Write("Input star: ");
                            var star = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Input phone: ");
                            var phone = Console.ReadLine();
                            var hotel = new Hotel
                            {
                                Name = name,
                                Star = star,
                                Phone = phone,
                            };
                            presentationHotel.CreateHotel(hotel);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.Write("Input id hotel: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var hotel = presentationHotel.GetCollectionHotels().Result.Where(el => el.Id == id).FirstOrDefault();
                            if(hotel != null)
                            {
                                Console.Write("Input name: ");
                                var name = Console.ReadLine();
                                Console.Write("Input star: ");
                                var star = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Input phone: ");
                                var phone = Console.ReadLine();
                                hotel.Name = name;
                                hotel.Star = star;
                                hotel.Phone = phone;
                                presentationHotel.UpdateHotel(hotel);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 6:
                        {
                            Console.Clear();
                            Console.Write("Input id hotel for delete: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            presentationHotel.DeleteHotel(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Console.Write("Input country: ");
                            var country = Console.ReadLine();
                            Console.Write("Input arrival: ");
                            var arrival = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Input departure: ");
                            var departure = Convert.ToDateTime(Console.ReadLine());
                            Console.Write("Input price: ");
                            var price = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Input serviceId: ");
                            var serviceId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Input hotelId: ");
                            var hotelId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Input staffId: ");
                            var staffId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Input UserId: ");
                            var userId = Convert.ToInt32(Console.ReadLine());
                            var travelVoucher = new TravelVoucher
                            {
                                Country = country,
                                Arrival = arrival,
                                Departure = departure,
                                Price = price,
                                ServicesId = serviceId,
                                HotelId = hotelId,
                                StaffId = staffId,
                                UserId = userId,
                            };
                            presentationTravelVoucher.CreateTravelVoucher(travelVoucher);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            Console.Write("Input id travel voucher: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var travelVoucher = presentationTravelVoucher.GetCollectionTravelVouchers().Result.Where(el=>el.Id == id).FirstOrDefault();
                            if (travelVoucher != null)
                            {
                                Console.Write("Input country: ");
                                var country = Console.ReadLine();
                                Console.Write("Input arrival: ");
                                var arrival = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Input departure: ");
                                var departure = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("Input price: ");
                                var price = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Input serviceId: ");
                                var serviceId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Input hotelId: ");
                                var hotelId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Input staffId: ");
                                var staffId = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Input UserId: ");
                                var userId = Convert.ToInt32(Console.ReadLine());
                                travelVoucher.Country = country;
                                travelVoucher.Arrival = arrival;
                                travelVoucher.Departure = departure;
                                travelVoucher.Price = price;
                                travelVoucher.ServicesId = serviceId;
                                travelVoucher.HotelId = hotelId;
                                travelVoucher.StaffId = staffId;
                                travelVoucher.UserId = userId;
                                presentationTravelVoucher.UpdateTravelVoucher(travelVoucher);
                            }
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            Console.Write("Input id travel voucher for delete: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            presentationTravelVoucher.DeleteTravelVoucher(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 10:
                        {
                            Console.Clear();
                            Console.Write("Input firstname: ");
                            var firstName = Console.ReadLine();
                            Console.Write("Input lastname: ");
                            var lastName = Console.ReadLine();
                            Console.Write("Input middlename: ");
                            var middleName = Console.ReadLine();
                            Console.WriteLine("Input role");
                            var role = Console.ReadLine();
                            Console.Write("Input phone");
                            var phone = Console.ReadLine();
                            Console.Write("Input salary");
                            var salary = Convert.ToInt32(Console.ReadLine());
                            var staff = new Staff
                            {
                                FirstName = firstName,
                                LastName = lastName,
                                MiddleName = middleName,
                                Phone = phone,
                                Salary = salary,
                                Role = role,
                            };
                            presentationStaff.CreateStaff(staff);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 11:
                        {
                            Console.Clear();
                            Console.Write("Input id staff: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var staff = presentationStaff.GetCollectionStaffs().Result.Where(el => el.Id == id).FirstOrDefault();
                            if (staff != null)
                            {
                                Console.Write("Input firstname: ");
                                var firstName = Console.ReadLine();
                                Console.Write("Input lastname: ");
                                var lastName = Console.ReadLine();
                                Console.Write("Input middlename: ");
                                var middleName = Console.ReadLine();
                                Console.Write("Input address: ");
                                var address = Console.ReadLine();
                                Console.WriteLine("Input role");
                                var role = Console.ReadLine();
                                Console.Write("Input phone");
                                var phone = Console.ReadLine();
                                Console.Write("Input salary");
                                var salary = Convert.ToInt32(Console.ReadLine());
                                presentationStaff.UpdateStaff(staff);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 12:
                        {
                            Console.Clear();
                            Console.Write("Input id staff for delete: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            presentationStaff.DeleteStaff(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 13:
                        {
                            Console.Clear();
                            Console.Write("Input name service: ");
                            var name = Console.ReadLine();
                            var services = new Service
                            {
                                Name = name,
                            };
                            presentationService.CreateService(services);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 14:
                        {
                            Console.Clear();
                            Console.Write("Input id service: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var service = presentationService.GetCollectionServices().Result.Where(el => el.Id == id).FirstOrDefault();
                            if (service != null)
                            {
                                Console.Write("Input name service: ");
                                var name = Console.ReadLine();
                                presentationService.UpdateService(service);
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        }
                    case 15:
                        {
                            Console.Clear();
                            Console.Write("Input id service for delete: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            presentationService.DeleteService(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                    case 16:
                        {
                            Console.Clear();
                            presentationUser.GetCollectionUsers().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 17:
                        {
                            Console.Clear();
                            presentationHotel.GetCollectionHotels().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 18:
                        {
                            Console.Clear();
                            presentationTravelVoucher.GetCollectionTravelVouchers().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 19:
                        {
                            Console.Clear();
                            presentationStaff.GetCollectionStaffs().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 20:
                        {
                            Console.Clear();
                            presentationService.GetCollectionServices().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 21:
                        {
                            Console.Clear();
                            Console.WriteLine("Input id user");
                            var idUser = Convert.ToInt32(Console.ReadLine());
                            var idTravelVoucher = Convert.ToInt32(Console.ReadLine());
                            presentationTravelVoucher.MakeOrder(idTravelVoucher,idUser);
                            Console.ReadKey();
                            Console.Clear();
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
            Console.WriteLine("Menu");
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Update user");
            Console.WriteLine("3. Delete user");
            Console.WriteLine();
            Console.WriteLine("4. Add hotel");
            Console.WriteLine("5. Update hotek");
            Console.WriteLine("6. Delete hotel");
            Console.WriteLine();
            Console.WriteLine("7. Add travel voucher");
            Console.WriteLine("8. Update travel voucher");
            Console.WriteLine("9. Delete travel voucher");
            Console.WriteLine();
            Console.WriteLine("10. Add staff");
            Console.WriteLine("11. Update staff");
            Console.WriteLine("12. Delete staff");
            Console.WriteLine();
            Console.WriteLine("13. Add service");
            Console.WriteLine("14. Update service");
            Console.WriteLine("15. Delete service");
            Console.WriteLine();
            Console.WriteLine("16. List clients");
            Console.WriteLine("17. List hotels");
            Console.WriteLine("18. List travel vouchers");
            Console.WriteLine("19. List satff");
            Console.WriteLine("20. List service");
            Console.WriteLine();
            Console.WriteLine("21. Order");
            Console.WriteLine("0. Exit");

            Console.WriteLine();
        }
    }
}
