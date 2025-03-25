namespace Ordering.Domain.ValueObjects;
public record Address
{
    public string FirstName { get; } = default!;
    public string LastName { get; } = default!;
    public string? EmailAddress { get; } = default!;
    public string Country { get; } = default!;
    public string State { get; } = default!;
    public string City { get; } = default!;
    public string Street { get; } = default!;
    public string ZipCode { get; } = default!;

    protected Address()
    {
    }

    private Address(string firstName, string lastName, string emailAddress, string country, 
        string state, string city, string street, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        Country = country;
        State = state;
        City = city;
        Street = street;
        ZipCode = zipCode;
    }

    public static Address Of(string firstName, string lastName, string emailAddress, string country, 
        string state,string city, string street, string zipCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(emailAddress);
        ArgumentException.ThrowIfNullOrWhiteSpace(country);
        ArgumentException.ThrowIfNullOrWhiteSpace(state);
        ArgumentException.ThrowIfNullOrWhiteSpace(city);
        ArgumentException.ThrowIfNullOrWhiteSpace(zipCode);

        return new Address(firstName, lastName, emailAddress, country, state, city, street, zipCode);
    }
}
