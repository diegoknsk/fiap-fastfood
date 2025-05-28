namespace FastFood.Application.Models.CustomerIdentification
{
    public class CustomerModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string CustomerType { get; set; } = string.Empty;
    }
}
