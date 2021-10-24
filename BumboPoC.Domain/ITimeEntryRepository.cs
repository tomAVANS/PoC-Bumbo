namespace BumboPoC.Domain
{
    public interface ITimeEntryRepository
    {
        TimeEntry Update(TimeEntry entry);
        bool Delete(int Id);
    } 
}