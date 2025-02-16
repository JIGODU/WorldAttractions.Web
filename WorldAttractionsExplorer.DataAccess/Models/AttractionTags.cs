namespace WorldAttractionsExplorer.DataAccess.Models
{
    public class AttractionTags
    {
        public int AttractionId { get; set; }

        public Attractions Attraction { get; set; }

        public int TagId { get; set; }

        public Tags Tag { get; set; }
    }

}
