using API_Magazynex_New.SimpleDTO;

namespace API_Magazynex_New.Services
{
    public class MagazynService
    {
        private DatabaseContext _dbContext;

        public MagazynService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MagazynSimpleDTO>> MagazynGetAll()
        {
            var magazynitems = await _dbContext.magazyns.Include(x => x.Towary).ToListAsync();

            return magazynitems.Select(x => new MagazynSimpleDTO(x)).ToList();
        }
    }
}
