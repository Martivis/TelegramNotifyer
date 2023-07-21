namespace Notifyer.Data.Context.Entities
{
    public class UserData
    {
        public long ChatId { get; set; }
        public virtual ICollection<NewsCathegory> SubscribedCathegories { get; set; } 
    }
}