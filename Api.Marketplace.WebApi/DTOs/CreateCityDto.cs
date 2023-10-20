namespace Api.Marketplace.WebApi.DTOs;

public class CreateCityDto
{
    public CreateCityDto(string name, string country)
    {
        Name = name;
        Country = country;
    }

    public string Name { get; set; }
    public string Country { get; set; }
}
