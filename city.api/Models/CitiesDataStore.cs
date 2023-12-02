namespace city.api.Models
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        public static CitiesDataStore current { get; } = new CitiesDataStore();  

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto() { Id = 1,Name="Tehran",
                Description="This is The Central City."},
                new CityDto() { Id = 2,Name="Esfahan",
                Description="This is The Half of world City."},
                new CityDto() { Id = 3,Name="Bandar Abas",
                Description="This is The Southest City."}
            };
        }
    }
}
