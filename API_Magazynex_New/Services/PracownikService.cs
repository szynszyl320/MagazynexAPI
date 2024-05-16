using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.Encje;
using API_Magazynex_New.SimpleDTO;

namespace API_Magazynex_New.Services
{
    public class PracownikService
    {
        private DatabaseContext _dbContext;

        public PracownikService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PracownikSimpleDTO>> PracownikGetAll()
        {
            var pracownikitems = await _dbContext.Pracowniks.Include(x => x.Magazyn).ToListAsync();

            return pracownikitems.Select(x => new PracownikSimpleDTO(x)).ToList();
        }

        public async Task<PracownikSimpleDTO> PracownikGetSpecific(int Id)
        {
            return new PracownikSimpleDTO(_dbContext.Pracowniks.Include(x => x.Magazyn).FirstOrDefault(x => x.Id == Id));
        }

        public async Task<PracownikSimpleDTO> CreateNewPracownik(PracownikCreateDTO dto)
        {
            Pracownik pracownik = new Pracownik();
            pracownik.Imie = dto.Imie;
            pracownik.Nazwisko = dto.Nazwisko;
            pracownik.Stanowisko = dto.Stanowisko;
            pracownik.Numer_Telefonu = dto.Numer_Telefonu;
            
            Magazyn? magazyn = _dbContext.Magazyns.FirstOrDefault(x => x.Id == dto.Id_Magazynu);

            pracownik.Magazyn = magazyn;
            pracownik.MagazynId = magazyn.Id;
            
            _dbContext.Pracowniks.Add(pracownik);
            await _dbContext.SaveChangesAsync();
            
            return new PracownikSimpleDTO(pracownik);
        }


        public async Task<bool> DeletePracownik(int Id)
        {
            var pracownikItem = await _dbContext.Pracowniks.FirstOrDefaultAsync(f => f.Id == Id);

            if (pracownikItem != null)
            {
                _dbContext.Pracowniks.Remove(pracownikItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> UpdatePracownik(int Id, PracownikCreateDTO dto)
        {
            var pracownikItem = await _dbContext.Pracowniks.FirstOrDefaultAsync(f => f.Id == Id);
            if (pracownikItem == null) return false;
            pracownikItem.Imie = dto.Imie;
            pracownikItem.Nazwisko = dto.Nazwisko;
            pracownikItem.Stanowisko = dto.Stanowisko;
            pracownikItem.Numer_Telefonu = dto.Numer_Telefonu;
            pracownikItem.MagazynId = dto.Id_Magazynu;
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
