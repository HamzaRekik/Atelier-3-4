using Atelier3.Models;

namespace Atelier3.Repositories
{
    public interface ISchoolRepository
    {
        IList<School> GetAll();
        School GetById(int id);
        void Add(School s);
        void Edit(School s);
        void Delete(School s);
        double StudentAgeAverage(int schoolID);
        int StudentCount(int schoolID);
    }
}
