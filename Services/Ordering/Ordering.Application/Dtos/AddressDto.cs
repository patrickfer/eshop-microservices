namespace Ordering.Application.Dtos;

public record AddressDto (
    string FirstName, 
    string LastName, 
    string EmailAddress, 
    string Country,
    string State, 
    string City, 
    string Street, 
    string ZipCode
    );
