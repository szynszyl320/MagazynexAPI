using API_Magazynex_New.Configs;
using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.Encje;
using API_Magazynex_New.SimpleDTO;

namespace API_Magazynex_New.Services
{
    public class FirmaService
    {
        private DatabaseContext _dbContext;

        public FirmaService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<List<FirmaSimpleDTO>> FirmaGetAll()
        {
            var firmaItems = await _dbContext.Firmas.Include(x => x.Towars).ToListAsync();
            return firmaItems.Select(x => new FirmaSimpleDTO(x)).ToList();
        }

        public async Task<FirmaSimpleDTO>  FirmaGetSpecific(int Id)
        {
            return new FirmaSimpleDTO(_dbContext.Firmas.Include(x => x.Towars).FirstOrDefault(x => x.Id == Id));
        }
    
        public async Task<FirmaSimpleDTO> CreateNewFirma(FirmaCreateDTO dto)
        {
            Firma firma = new Firma();
            
            firma.Nazwa = dto.Nazwa;
            firma.Numer_Telefonu = dto.Numer_Telefonu;

            _dbContext.Firmas.Add(firma);
            await _dbContext.SaveChangesAsync();

            return new FirmaSimpleDTO(firma);
        }
    
    
        public async Task<bool> DeleteFrima(int Id)
        {
            var firmaItem = await _dbContext.Firmas.FirstOrDefaultAsync(f => f.Id == Id);

            if (firmaItem != null)
            {
                firmaItem.IsActive = false;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
