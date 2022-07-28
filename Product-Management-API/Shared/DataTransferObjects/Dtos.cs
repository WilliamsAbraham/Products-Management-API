using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record ProductResponseDto
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public bool IsEnabled { get; set; } = true;
        public DateTime CreatedDate { get; set; }
        public decimal? Price { get; set; }

    }
    public record ProductCreationDto
    {
        public int ? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? Price { get; set; }
    }
    public record ProductUpdateDto
    {
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal? Price { get; set; }
        public bool Enabled { get; set; }
    }
    public record UserForRegistrationDto
    {
        public string? FirstName { get; init; }
        public string? LastName { get; init; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; init; }
        public string? Email { get; init; }
        public string? PhoneNumber { get; init; }
        public string? Role { get; init; }
    }
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "User Email is required")]
        public string? Email { get; init; }
        [Required(ErrorMessage = "Password  is required")]
        public string? Password { get; init; }
    }
}
