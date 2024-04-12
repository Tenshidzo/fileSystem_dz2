using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace fileSystem_dz
{

    public class Client
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
        public string City { get; set; }
        public int RoomId { get; set; }
        public Residence Residence { get; set; }

        public Client(int id, string lastName, string firstName, string middleName, string passportSeries, string passportNumber, string city, int roomId, Residence residence)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            MiddleName = middleName;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            City = city;
            RoomId = roomId;
            Residence = residence;
        }
    }

    public class Residence
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public decimal Cost { get; set; }
        public int Floor { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public Residence(int id, int roomId, string roomType, decimal cost, int floor, DateTime arrivalDate, DateTime departureDate)
        {
            Id = id;
            RoomId = roomId;
            RoomType = roomType;
            Cost = cost;
            Floor = floor;
            ArrivalDate = arrivalDate;
            DepartureDate = departureDate;
        }
    }

    public class Room
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public decimal Cost { get; set; }
        public int Capacity { get; set; }
        public int Floor { get; set; }

        public Room(int id, int roomTypeId, decimal cost, int capacity, int floor)
        {
            Id = id;
            RoomTypeId = roomTypeId;
            Cost = cost;
            Capacity = capacity;
            Floor = floor;
        }
    }

    public class RoomType
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public decimal Cost { get; set; }

        public RoomType(int id, int capacity, decimal cost)
        {
            Id = id;
            Capacity = capacity;
            Cost = cost;
        }
    }
    public class ServiceHotel : IDisposable
    {
        private static List<Client> _clients = new List<Client>();
        private static List<Residence> _residences = new List<Residence>();
        private static List<Room> _rooms = new List<Room>();
        private static List<RoomType> _roomTypes = new List<RoomType>();

        public void AddClient(Client client)
        {
            client.Id = _clients.Count + 1; // Assign a unique ID
            _clients.Add(client);
        }

        public Client GetClientById(int id)
        {
            return _clients.FirstOrDefault(c => c.Id == id);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var service = new ServiceHotel())
            {
                service.AddClient(new Client(
                    1,
                    "Doe",
                    "Jhon",
                    "Biberson",
                    "AH-11111",
                    "221233",
                    "Kiev",
                    1, 
                    null 
                ));
                var client = service.GetClientById(1);
                Console.WriteLine($"Client: {client.FirstName} {client.LastName}");
            }
        }
    }
}
