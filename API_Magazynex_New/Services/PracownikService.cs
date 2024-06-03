using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.CsvDTO;
using API_Magazynex_New.Encje;
using API_Magazynex_New.SimpleDTO;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using API_Magazynex_New.ForeingAPI;


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

        public async Task<IResult> PracownikExport()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            var PracownikItems = await _dbContext.Pracowniks.ToListAsync();
            var returnPracownik = PracownikItems.Select(x => new PracownikCsvDTO(x)).ToList();

            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                csv.WriteRecords(returnPracownik);
                writer.Flush();

                var content = memoryStream.ToArray();
                return Results.File(content, "text/csv", "pracownik.csv");
            }
        }

        public async Task<int> PracownikImport(IFormFile file)
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            using (var reader = new StreamReader(file.OpenReadStream()))
            using (var csv = new CsvReader(reader, csvConfig))
            {
                var records = csv.GetRecords<PracownikCsvDTO>();

                int Duplikaty = 0;
                foreach (var item in records)
                {
                    Pracownik pracownik = new Pracownik();
                    var pracowniks = _dbContext.Pracowniks.Select(x => x.Id).ToList();
                    if (!pracowniks.Contains(item.Id))
                    {
                        pracownik.Imie = item.Imie;
                        pracownik.Nazwisko = item.Nazwisko;
                        pracownik.Stanowisko = item.Stanowisko;
                        pracownik.Id = item.Id;
                        pracownik.Numer_Telefonu = item.Numer_Telefonu;
                        pracownik.MagazynId = item.MagazynId;
                        pracownik.Magazyn = await _dbContext.Magazyns.FirstOrDefaultAsync(x => x.Id == item.MagazynId);

                        _dbContext.Pracowniks.Add(pracownik);
                        await _dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        Duplikaty += 1;
                    }
                }
                return Duplikaty;
            }
        }

        public async Task<PracownikSimpleDTO> CreateNewPracownik(PracownikCreateDTO dto)
        {
            HttpClient httpClient = new HttpClient();
            
            Pracownik pracownik = new Pracownik();
            pracownik.Imie = dto.Imie;
            pracownik.Nazwisko = dto.Nazwisko;
            pracownik.Stanowisko = dto.Stanowisko;
            pracownik.Numer_Telefonu = dto.Numer_Telefonu;
           

            Magazyn? magazyn = _dbContext.Magazyns.FirstOrDefault(x => x.Id == dto.Id_Magazynu);

            pracownik.Magazyn = magazyn;
            pracownik.MagazynId = magazyn.Id;

            var AgeRespone = await httpClient.GetFromJsonAsync<AgifyRespone>($"https://api.agify.io?name={pracownik.Imie}");
            pracownik.AproxAge = AgeRespone.Age;

            NationalizeResponse NationRespone = await httpClient.GetFromJsonAsync<NationalizeResponse>($"https://api.nationalize.io/?name={pracownik.Imie}");
            pracownik.AproxNat = NationRespone.Country.First().country_id;


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