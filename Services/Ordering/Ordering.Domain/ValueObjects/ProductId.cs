namespace Ordering.Domain.ValueObjects;

public record ProductId
{
    public string Value { get; }

    private ProductId(string value) => Value = value;

    public static ProductId Of(string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        if (value == string.Empty)
        {
            throw new DomainException("ProductId cannot be empty.");
        }

        return new ProductId(value);
    }
}
