using FastFood.Domain.Common.Exceptions;

namespace FastFood.Domain.Entities.AdminManagement
{
    public class AdminUser
    {
        public Guid Id { get; private set; }

        public string? Name { get; private set; }

        public string? Email { get; private set; }

        public string? Username { get; private set; }

        public string? PasswordHash { get; private set; } // TODO: apply hashing before persisting

        public DateTime CreatedAt { get; private set; }

        protected AdminUser() { } // para o ef

        public AdminUser(string? name, string? email, string? username, string? passwordHash)
        {
            ValidationFields(name, email, username, passwordHash);

            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Username = username;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.UtcNow;
        }

        private static void ValidationFields(string? name, string? email, string? username, string? passwordHash)
        {
            DomainValidation.ThrowIfNullOrWhiteSpace(name, "Name is required.");
            DomainValidation.ThrowIfNullOrWhiteSpace(email, "Email is required.");
            DomainValidation.ThrowIf(email != null && email.Contains("@"), "Invalid email address.");
            DomainValidation.ThrowIfNullOrWhiteSpace(username, "Username is required.");
            DomainValidation.ThrowIfNullOrWhiteSpace(passwordHash, "PasswordHash is required.");
            DomainValidation.ThrowIfLengthLessThan(passwordHash,6,"PasswordHash must be at least 6 characters." );
        }
    }
}
