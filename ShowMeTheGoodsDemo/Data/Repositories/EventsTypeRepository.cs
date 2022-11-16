using System.Xml.Linq;
using System;
using System.Threading.Tasks;
using ShowMeTheGoodsDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ShowMeTheGoodsDemo.Data.Repositories
{
    public interface IEventsTypeRepository
    {
        Task<EventType?> GetAsync(int eventId);
        Task<IReadOnlyList<EventType>> GetManyAsync();
        Task CreateAsync(EventType eevent);
        Task UpdateAsync(EventType eevent);
        Task DeleteAsync(EventType eevent);

    }

    public class EventsTypeRepository : IEventsTypeRepository
    {
        private readonly ShowMeTheGoodsDbContext _smtgDbContext;
        public EventsTypeRepository(ShowMeTheGoodsDbContext smtgDbContext)
        {

            _smtgDbContext = smtgDbContext;
        }

        public async Task<EventType?> GetAsync(int eventId)
        {
            return await _smtgDbContext.EventsType.FirstOrDefaultAsync(x => x.Id == eventId);
        }

        public async Task<IReadOnlyList<EventType>> GetManyAsync()
        {
            return await _smtgDbContext.EventsType.ToListAsync();
        }

        public async Task CreateAsync(EventType eevent)
        {
            _smtgDbContext.EventsType.Add(eevent);
            await _smtgDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(EventType eevent)
        {
            _smtgDbContext.EventsType.Update(eevent);
            await _smtgDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(EventType eevent)
        {
            _smtgDbContext.EventsType.Remove(eevent);
            await _smtgDbContext.SaveChangesAsync();
        }
    }
}
