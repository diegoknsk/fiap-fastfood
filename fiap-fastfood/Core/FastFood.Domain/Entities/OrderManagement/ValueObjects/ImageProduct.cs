using FastFood.Domain.Common.Exceptions;

namespace FastFood.Domain.Entities.OrderManagement.ValueObjects
{
    public class ImageProduct
    {
        public string? Name { get; private set; }
        public string? Url { get; private set; }

        protected ImageProduct() { }

        public ImageProduct(string? name, string? url)
        {
            Validate(name, url);
            Name = name;
            Url = url;
        }

        private void Validate(string? name, string? url)
        {
            if (!string.IsNullOrWhiteSpace(name) && string.IsNullOrWhiteSpace(url))
            {
                throw new DomainException("ImageProduct URL is required when name is provided.");
            }

            if (!string.IsNullOrWhiteSpace(url) && string.IsNullOrWhiteSpace(name))
            {
                throw new DomainException("ImageProduct name is required when URL is provided.");
            }
        }

        public override string ToString()
        {
            return Url ?? string.Empty;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not ImageProduct other)
            {
                return false;
            }

            return Name == other.Name && Url == other.Url;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Url);
        }
    }
}
