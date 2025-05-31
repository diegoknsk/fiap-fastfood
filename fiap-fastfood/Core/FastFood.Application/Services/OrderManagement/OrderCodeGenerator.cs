namespace FastFood.Application.Services.OrderManagement
{
    public static class OrderCodeGenerator
    {
        public static string Generate(Guid customerId)
        {
            string letters = customerId.ToString("N")
                .Where(char.IsLetter)
                .Take(3)
                .Select(char.ToUpper)
                .Aggregate("", (acc, c) => acc + c);

            string numbers = DateTime.UtcNow.ToString("HHmmssfff")[5..9];

            return $"{letters}-{numbers}";
        }
    }
}
