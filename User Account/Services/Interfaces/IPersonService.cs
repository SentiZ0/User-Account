using User_Account.Models;

namespace User_Account.Services.Interfaces
{
    public interface IPersonService
    {
        public void AddEntry(Person person);

        public List<Person> GetAllEntries();

        public List<Person> GetEntriesFromToday();
    }
}
