﻿using API_Magazynex_New.Configs;
using API_Magazynex_New.CreateDTO;
using API_Magazynex_New.CsvDTO;
using API_Magazynex_New.Encje;
using API_Magazynex_New.SimpleDTO;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
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

        public async Task<FirmaSimpleDTO> FirmaGetSpecific(int Id)
        {
            var firmy = _dbContext.Firmas.Include(x => x.Towars).ToList();

            var firma = firmy.FirstOrDefault(x => x.Id == Id);

            return new FirmaSimpleDTO(firma);
        }

        public async Task<IResult> FirmaExport()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
            };

            var firmaItems = await _dbContext.Firmas.ToListAsync();
            var returnfirma = firmaItems.Select(x => new FirmaCsvDTO(x)).ToList();

            using (var memoryStream = new MemoryStream())
            using (var writer = new StreamWriter(memoryStream))
            using (var csv = new CsvWriter(writer, csvConfig))
            {
                csv.WriteRecords(returnfirma);
                writer.Flush();

                var content = memoryStream.ToArray();
                return Results.File(content, "text/csv", "firma.csv");
            }
        }
    
        /*public async Task<int> FirmaImport(File file)
        {
            var ReadFile = File.Open(file, )
            return 0;
        }
        */
        public async Task<FirmaSimpleDTO> CreateNewFirma(FirmaCreateDTO dto)
        {
            Firma firma = new Firma
            {
                Nazwa = dto.Nazwa,
                Numer_Telefonu = dto.Numer_Telefonu
            };

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

        public async Task<bool> UpdateFirma(int Id, FirmaCreateDTO dto)
        {
            
            var firmaItem = await _dbContext.Firmas.FirstOrDefaultAsync(f => f.Id == Id);

            if (firmaItem is null) return false;

            firmaItem.Nazwa = dto.Nazwa;
            firmaItem.Numer_Telefonu = dto.Numer_Telefonu;

            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ReactivateFirma(int Id)
        {
            var firma = await _dbContext.Firmas.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == Id);
            if (firma is null) return false;
            firma.IsActive = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
