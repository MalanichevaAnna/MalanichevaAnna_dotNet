using BLL.Model;
using BLL.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace TouristConsole
{
    public class PresentationMenu
    {
        private readonly HotelManagementService serviceHotel;

        private readonly ServiceManagementService service;
        
        private readonly StaffManagementService serviceStaff;
        
        private readonly TravelVoucherManagementService serviceTravelVoucher;
        
        private readonly UserManagementService serviceUser;

        public PresentationMenu(HotelManagementService serviceHotel, ServiceManagementService service, 
                                StaffManagementService serviceStaff, TravelVoucherManagementService serviceTravelVoucher,
                                UserManagementService serviceUser)
        {
            this.serviceHotel = serviceHotel;
            this.service = service;
            this.serviceStaff = serviceStaff;
            this.serviceTravelVoucher = serviceTravelVoucher;
            this.serviceUser = serviceUser;
        }

        public async Task StartAppSession()
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
                            await serviceUser.Create(user);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.Write("Input id user: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var user = serviceUser.GetItems().Result.Where(el => el.Id == id).FirstOrDefault();
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
                                await serviceUser.Update(user);
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
                            await serviceUser.Delete(id);
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
                            await serviceHotel.Create(hotel);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.Write("Input id hotel: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var hotel = serviceHotel.GetItems().Result.Where(el => el.Id == id).FirstOrDefault();
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
                                await serviceHotel.Update(hotel);
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
                            await serviceHotel.Delete(id);
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
                            await serviceTravelVoucher.Create(travelVoucher);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            Console.Write("Input id travel voucher: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var travelVoucher = serviceTravelVoucher.GetItems().Result.Where(el=>el.Id == id).FirstOrDefault();
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
                                await serviceTravelVoucher.Update(travelVoucher);
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
                            await serviceTravelVoucher.Delete(id);
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
                            await serviceStaff.Create(staff);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 11:
                        {
                            Console.Clear();
                            Console.Write("Input id staff: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var staff = serviceStaff.GetItems().Result.Where(el => el.Id == id).FirstOrDefault();
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
                                await serviceStaff.Update(staff);
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
                            await serviceStaff.Delete(id);
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
                            await service.Create(services);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 14:
                        {
                            Console.Clear();
                            Console.Write("Input id service: ");
                            var id = Convert.ToInt32(Console.ReadLine());
                            var serviceItem = service.GetItems().Result.Where(el => el.Id == id).FirstOrDefault();
                            if (service != null)
                            {
                                Console.Write("Input name service: ");
                                var name = Console.ReadLine();
                                await service.Update(serviceItem);
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
                            await service.Delete(id);
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }

                    case 16:
                        {
                            Console.Clear();
                            serviceUser.GetItems().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 17:
                        {
                            Console.Clear();
                            serviceHotel.GetItems().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 18:
                        {
                            Console.Clear();
                            serviceTravelVoucher.GetItems().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 19:
                        {
                            Console.Clear();
                            serviceStaff.GetItems().Result.ToList().ForEach(el => Console.WriteLine(el));
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                    case 20:
                        {
                            Console.Clear();
                            service.GetItems().Result.ToList().ForEach(el => Console.WriteLine(el));
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
                            await serviceTravelVoucher.MakeOrder(idTravelVoucher,idUser);
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
