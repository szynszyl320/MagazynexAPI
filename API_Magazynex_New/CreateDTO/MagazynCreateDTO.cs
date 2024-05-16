namespace API_Magazynex_New.CreateDTO
{
    public class MagazynCreateDTO
    {
        public string? lokalizacja { get; set; }
        public enum Mozliwosc_Pechowywania_Materialow
        {
            Safe_Materials,
            Explosive_Materials,
            Gaseous_Materials,
            Liquid_Flammable_Materials,
            Prone_Self_Combusting_Materials,
            Oxidizing_Materials,
            Toxic_Materials,
            Radioactive_Materials,
            Corrosive_Materials,
            Doesnt_Fit_In_Another_Category
        }
        public string? Nazwa { get; set; }
    }
}
