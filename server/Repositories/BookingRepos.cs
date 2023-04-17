using MongoDB.Bson;
using MongoDB.Driver;
using sheltermini.Shared;

namespace server.Repositories
{
    public class BookingRepos : IBookingRepos
    {
        private List<Booking> bookings;

        private IMongoCollection<Booking> collection;

        public BookingRepos()
        {
            bookings = new();
        }
        public Booking[] getAll(Shelter s)
        {
            bookings.Clear();
            var client = new MongoClient("mongodb+srv://eaajakhj:kajkage02@sheltermini.f1ql71j.mongodb.net/test");
            var database = client.GetDatabase("sheltermini");
            var collection = database.GetCollection<BsonDocument>("shelter_bookings");
            var documents = collection.Find($"{{}}").ToList();

            foreach (var doc in documents)
            {
                var StartDate = doc["startDate"].ToString();
                var SlutDate = doc["endDate"].ToString();
                var NumberOfPeople = doc["numberOfPeople"].ToInt32();
                var BookingId = doc["bookingId"].ToInt32();
                var FullName = doc["fullName"].ToString();
                var Email = doc["email"].ToString();
                var Phone = doc["phone"].ToString();
                var ShelterFromDatabase = doc["shelter"].ToBsonDocument();
                Shelter Shelter = new Shelter { Name = ShelterFromDatabase["name"].ToString(), ShelterId = ShelterFromDatabase["shelterid"].ToString() };

                var mbook = new Booking(Shelter) { Startdate = StartDate, Slutdate = SlutDate, NumberOfPeople = NumberOfPeople, BookingId = BookingId, FullName = FullName, Email = Email, Phone = Phone };



                bookings.Add(mbook);

            }
            return bookings.ToArray();
        }

        public void AddBook(Booking booking)
        {
            var client = new MongoClient("mongodb+srv://eaajakhj:kajkage02@sheltermini.f1ql71j.mongodb.net/test");
            var database = client.GetDatabase("sheltermini");
            var collection = database.GetCollection<BsonDocument>("shelter_bookings");
            var document = new BsonDocument
            {
                { "startDate", booking.Startdate},
                { "endDate", booking.Slutdate},
                { "numberOfPeople", booking.NumberOfPeople},
                { "bookingId", booking.BookingId},
                { "fullName", booking.FullName},
                { "email", booking.Email},
                { "phone", booking.Phone},
                { "shelter", new BsonDocument{
                    {"name", booking.Shelter.Name },
                    {"kommunenavn", booking.Shelter.KommuneName },
                    {"contact", booking.Shelter.Contact},
                    {"capacity", booking.Shelter.Capacity },
                    {"description", booking.Shelter.Description},
                    {"availability", booking.Shelter.IsAvailable },
                    {"lattitude", booking.Shelter.lat },
                    {"longitude", booking.Shelter.longitude },
                    {"picture", booking.Shelter.Picture},
                    {"shelterid", booking.Shelter.ShelterId} 
                } }
 
                //{ "shelter.KommuneName", booking.Shelter.KommuneName } 
            };

            collection.InsertOne(document);
        }

            public void DeleteSingle(string shelterId)
            {
                var client = new MongoClient("mongodb+srv://eaajakhj:kajkage02@sheltermini.f1ql71j.mongodb.net/test");
                var database = client.GetDatabase("sheltermini");
                var collection = database.GetCollection<BsonDocument>("shelter_bookings");
                var filter = Builders<BsonDocument>.Filter.Eq("shelter.shelterid", shelterId);

               collection.DeleteOne(filter);

        }
    }
}
