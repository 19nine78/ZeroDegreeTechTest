namespace ZeroDegreeTechTest.Models
{
    public class MessageOfTheDay
    {
        public int dayId { get; set; }
        public string day { get; set; }
        public int languageId { get; set; }
        public string language { get; set; }
        public string message { get; set; }
    }
}
