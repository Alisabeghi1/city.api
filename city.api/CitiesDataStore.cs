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
                Description="This is The Central City."
                ,PointsOfInterest=new List<PointsOfInterestDto>()
                {
                    new PointsOfInterestDto()
                    {
                        Id=1,
                        Name="Palace 1",
                        Description="This is Palace 1 "
                    },
                    new PointsOfInterestDto ()
                    {
                        Id = 2,
                        Name = "palace 2",
                        Description= "This is Palace 2 "
                    }
                }

                },
                new CityDto() { Id = 2,Name="Esfahan",
                Description="This is The Half of world City."
                ,PointsOfInterest=new List<PointsOfInterestDto>()
                {
                    new PointsOfInterestDto()
                    {
                        Id=3,
                        Name="Palace 3",
                        Description="This is Palace 3 "
                    },
                    new PointsOfInterestDto ()
                    {
                        Id = 4,
                        Name = "palace 4",
                        Description= "This is Palace 4 "
                    }
                }
                },
                new CityDto() { Id = 3,Name="Bandar Abas",
                Description="This is The Southest City."
                ,PointsOfInterest=new List<PointsOfInterestDto>()
                {
                    new PointsOfInterestDto()
                    {
                        Id=5,
                        Name="Palace 5",
                        Description="This is Palace 5 "
                    },
                    new PointsOfInterestDto ()
                    {
                        Id = 6,
                        Name = "palace 6",
                        Description= "This is Palace 6 "
                    }
                }
                }
            };
        }
    }
}
