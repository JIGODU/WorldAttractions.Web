using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldAttractionsExplorer.DataAccess.Models;

public class Attractions
{
    public int AttractionId { get; set; }

    public string AttractionName { get; set; }

    public ICollection<AttractionTags> AttractionTags { get; set; }

    public string Description { get; set; }

    public string AuthorId { get; set; }

    public Users Author { get; set; }

    public DateTime PublishedDate { get; set; }

    public string EditorId { get; set; }

    public Users Editor { get; set; }

    public DateTime LastModifiedOn { get; set; }

    public double AverageRating { get; set; }

    public int CountryId { get; set; }

    public Country Country { get; set; }

    public int PrimaryImageId { get; set; }

    public Images PrimaryImage { get; set; }

    public ICollection<Images> OptionalImages { get; set; }

    public ICollection<Reviews> Reviews { get; set; }
}