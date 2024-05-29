namespace API_Magazynex_New.ForeingAPI
{
    public class NationalizeResponse
    {
        public string Name { get; set; }
        public List<Country> Country { get; set; }
    }

    public class Country
    {
        public string CountryId { get; set; }
        public double Probability { get; set; }
    }

}
