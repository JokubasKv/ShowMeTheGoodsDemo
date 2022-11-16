using Microsoft.EntityFrameworkCore;
using ShowMeTheGoodsDemo.Data.Entities;

namespace ShowMeTheGoodsDemo.Data.Reposotories
{
    public interface ICommentsRepository
    {
        Task<Comment> GetAsync(int eeventId, int commentId);
        Task<List<Comment?>> GetAsync();
        //Task<IReadOnlyList<Comment>> GetManyAsync();
        Task CreateAsync(Comment comment);
        Task UpdateAsync(Comment comment);
        Task DeleteAsync(Comment comment);

    }

    public class CommentsRepository : ICommentsRepository
    {
        private readonly ShowMeTheGoodsDbContext _smtgDbContext;
        public CommentsRepository(ShowMeTheGoodsDbContext smtgDbContext)
        {
            _smtgDbContext = smtgDbContext;
        }

        public async Task<Comment?> GetAsync( int eeventId, int commentId)
        {
            return await _smtgDbContext.Comments.FirstOrDefaultAsync(x => x.EventID == eeventId && x.Id == commentId);
        }

        public async Task<List<Comment>> GetAsync()
        {
            return await _smtgDbContext.Comments.ToListAsync();
        }

        public async Task CreateAsync(Comment comment)
        {
            _smtgDbContext.Comments.Add(comment);
            await _smtgDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _smtgDbContext.Comments.Update(comment);
            await _smtgDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Comment comment)
        {
            _smtgDbContext.Comments.Remove(comment);
            await _smtgDbContext.SaveChangesAsync();
        }
    }
}
