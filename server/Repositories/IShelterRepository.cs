using sheltermini.Shared;
using System;

namespace sheltermini.server.Repositories
{
    public interface IShelterRepository
    {
        List<Shelter> getAll();
        Shelter getSingle(string shelterId);
        void Add(Shelter shelter);

    
    }
}
