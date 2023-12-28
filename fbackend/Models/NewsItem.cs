namespace fbackend.Models
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public string NewsText { get; set; }

        public NewsItem(int id, string createdBy, string newsText)
        {
            Id = id;
            CreatedBy = createdBy;
            NewsText = newsText;
        }

    }
}
