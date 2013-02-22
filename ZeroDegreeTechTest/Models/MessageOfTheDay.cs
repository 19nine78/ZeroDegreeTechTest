namespace ZeroDegreeTechTest.Models
{
    public class MessageOfTheDay
    {
        public virtual int Id { get; set; }
        public virtual int dayId { get; set; }
        public virtual string day { get; set; }
        public virtual int languageId { get; set; }
        public virtual string language { get; set; }
        public virtual string message { get; set; }
    }
}
