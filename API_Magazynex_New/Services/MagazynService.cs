using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.Encje;
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
            var magazynitems = await _dbContext.Magazyns.Include(x => x.Towary).Include(x=>x.Pracownicy).ToListAsync();

            return magazynitems.Select(x => new MagazynSimpleDTO(x)).ToList();
        }
    
        public async Task<MagazynSimpleDTO> MagazynGetSpecific(int Id)
        {
            return new MagazynSimpleDTO(_dbContext.Magazyns.Include(x => x.Towary).Include(x => x.Pracownicy).FirstOrDefault(x => x.Id == Id));
        }
    
    
        public async Task<MagazynSimpleDTO> CreateNewMagazyn(MagazynCreateDTO dto)
        {
            Magazyn magazyn = new Magazyn();
            magazyn.Nazwa = dto.Nazwa;
            magazyn.lokalizacja = dto.lokalizacja;
            magazyn.Towary = new List<Towar>();
            magazyn.Pracownicy = new List<Pracownik>();


            _dbContext.Magazyns.Add(magazyn);
            await _dbContext.SaveChangesAsync();
        
            return(new MagazynSimpleDTO(magazyn));
        }

        public async Task<bool> DeleteMagazyn(int Id)
        {
            var magazynItem = await _dbContext.Magazyns.FirstOrDefaultAsync(f => f.Id == Id);

            if (magazynItem != null)
            {
                magazynItem.IsActive = false;
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }


    }
}
