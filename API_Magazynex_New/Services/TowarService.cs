using API_Magazynex_New.SimpleDTO;

namespace API_Magazynex_New.Services
{
    public class TowarService
    {
        private DatabaseContext _dbContext;

        public TowarService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TowarySimpleDTO>> TowaryGetAll()
        {
            var towaritems = await _dbContext.Towars.Include(x => x.Firma).Include(x => x.Magazyn).ToListAsync();
            
            return towaritems.Select(x => new TowarySimpleDTO(x)).ToList();
        }




    }
}
