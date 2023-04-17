using sheltermini.Shared;

namespace server.Repositories
{
    public interface IBookingRepos 
    {
    //     Booking[] getAll(Shelter s);
        Booking[] getAll(Shelter s);
        void AddBook(Booking booking);

        public void DeleteSingle(string shelterId);
        


    }
}
