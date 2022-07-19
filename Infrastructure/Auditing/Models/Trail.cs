namespace Infrastructure.Auditing.Models
{
    public class Trail
    {
        public Guid UserId { get; set; }
        public object Type { get; set; }
        public string TableName { get; set; }
        public DateTime DateTime { get; set; }
        public string PrimaryKey { get; set; }
        public string OldValues { get; set; }
        public string NewValues { get; set; }
        public string AffectedColumns { get; set; }
    }
}