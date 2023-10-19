namespace Service
{
    public class Recovery
    {
        public int Id { get; set; }
        public int FailureId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Status { get; set; }
    }
}
