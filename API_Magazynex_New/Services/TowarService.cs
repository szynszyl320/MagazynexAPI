using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.Encje;
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
        public async Task<TowarySimpleDTO> TowarGetSpecific(int Id)
        {
            return new TowarySimpleDTO(_dbContext.Towars.Include(x => x.Firma).Include(x => x.Magazyn).FirstOrDefault(x => x.id == Id));
        }

        public async Task<TowarySimpleDTO> CreateNewTowar(TowarCreateDTO dto)
        {
            Towar nowyTowar = new Towar();
            nowyTowar.Nazwa_Produktu = dto.Nazwa_Produktu;
            nowyTowar.Opis_Produktu = dto.Opis_Produktu;
            nowyTowar.Cena_Netto_Za_Sztuke = dto.Cena_Netto_Za_Sztuke;
            nowyTowar.Ilosc = dto.Ilosc;

            Firma? firma = _dbContext.Firmas.FirstOrDefault(x => x.Id == dto.Id_Firmy);
            Magazyn? magazyn = _dbContext.Magazyns.FirstOrDefault(x => x.Id == dto.Id_Magazynu);

            nowyTowar.Firma = firma;
            nowyTowar.Magazyn = magazyn;
            nowyTowar.MagazynId = magazyn.Id;

            _dbContext.Towars.Add(nowyTowar);
            await _dbContext.SaveChangesAsync();

            return new TowarySimpleDTO(nowyTowar);
        }
        public async Task<bool> DeleteTowar(int Id)
        {
            var towarItem = await _dbContext.Towars.FirstOrDefaultAsync(f => f.id == Id);

            if (towarItem != null)
            {
                _dbContext.Towars.Remove(towarItem);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

    }
}
