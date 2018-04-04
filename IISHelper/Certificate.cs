namespace IISHelper
{
    class Certificate
    {
        public string Name { get; set; }
        public string Site { get; set; }
        public string Store { get; set; }
        public string Issuer { get; set; }
        public string Subject { get; set; }
        public string Expire { get; set; }
        public byte[] Hash { get; set; }
        public string Binding { get; set; }
        public string Protocol { get; set; }
    }
}