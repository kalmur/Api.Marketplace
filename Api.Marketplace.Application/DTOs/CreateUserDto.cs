using System.ComponentModel.DataAnnotations;

namespace Api.Marketplace.Application.DTOs;
public class CreateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
}
