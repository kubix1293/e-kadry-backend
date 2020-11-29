using System.Linq;
using System.Threading.Tasks;
using EKadry.Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace EKadry.Infrastructure.Database
{
    public class Pagination<T> : IPagination<T> where T : class
    {
        private readonly IQueryable<T> _dbSet;
        private int _page;
        private readonly int _perPage;
        private IQueryable<T> _data;
        private int _totalResults;

        public Pagination(
            IQueryable<T> dbSet,
            int page = 1,
            int perPage = 15
        )
        {
            _dbSet = dbSet;
            _page = page;
            _perPage = perPage;
            
            CheckIntegrityBefore();
        }

        private void CheckIntegrityBefore()
        {
            if (_page < 1)
            {
                _page = 1;
            }
        }

        public async Task<PagedList<T>> ToList()
        {
            _data = _dbSet
                .Skip((_page - 1) * _perPage)
                .Take(_perPage);

            _totalResults = await _dbSet
                .CountAsync();

            return new PagedList<T>(await _data.ToListAsync(), _page, _perPage, _totalResults);
        }
    }
}