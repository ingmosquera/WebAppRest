namespace Data.Model.Entities
{
    public class Politica
    {
        public string Id { get; set; }
        public string AmountInsured { get; set; }
        public string Email { get; set; }
        public string InceptionDate { get; set; }
        public string InstallmentPayment { get; set; }
        public string ClientId { get; set; }
    }


    public class PoliticaXUsuario
    {
        public string IdUsuario { get; set; }
        public string Name { get; set; }
        public string EmailUsusario { get; set; }
        public string Role { get; set; }
        public string IdPolitica { get; set; }
        public string AmountInsured { get; set; }
        public string EmailPolitica { get; set; }
        public string InceptionDate { get; set; }
        public string InstallmentPayment { get; set; }

    }

}
