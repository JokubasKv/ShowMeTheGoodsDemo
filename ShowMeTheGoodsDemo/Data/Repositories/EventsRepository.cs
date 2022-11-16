using System.Xml.Linq;
using System;
using System.Threading.Tasks;
using ShowMeTheGoodsDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShowMeTheGoodsDemo.Data.Repositories
{
    public interface IEventsRepository
    {
        Task<Event?> GetAsync(int eventTypeId, int eeventID);

        Task<List<Event?>> GetAsync(int eventTypeId);
        Task<IReadOnlyList<Event>> GetManyAsync();
        Task CreateAsync(Event eevent);
        Task UpdateAsync(Event eevent);
        Task DeleteAsync(Event eevent);

    }

    public class EventsRepository : IEventsRepository
    {
        private readonly ShowMeTheGoodsDbContext _smtgDbContext;
        public EventsRepository(ShowMeTheGoodsDbContext smtgDbContext)
        {

            _smtgDbContext = smtgDbContext;
        }

        public async Task<Event?> GetAsync(int eventTypeId, int eeventID)
        {
            return await _smtgDbContext.Events.FirstOrDefaultAsync(x => x.EventTypeID == eventTypeId && x.Id == eeventID);
        }
        public async Task<List<Event>> GetAsync(int eventTypeId)
        {
            return await _smtgDbContext.Events.Where(x => x.EventTypeID == eventTypeId).ToListAsync();
        }

        public async Task<IReadOnlyList<Event>> GetManyAsync()
        {
            return await _smtgDbContext.Events.ToListAsync();
        }

        public async Task CreateAsync(Event eevent)
        {
            _smtgDbContext.Events.Add(eevent);
            await _smtgDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Event eevent)
        {
            _smtgDbContext.Events.Update(eevent);
            await _smtgDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Event eevent)
        {
            _smtgDbContext.Events.Remove(eevent);
            await _smtgDbContext.SaveChangesAsync();
        }
    }
}
