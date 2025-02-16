using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldAttractionsExplorer.DataAccess.Models;

public class Reviews
{
    public int ReviewId { get; set; }

    public int AuthorId { get; set; }

    public Users Author { get; set; }

    public int  AttractionId { get; set; }

    public Attractions Attraction { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public double Rating { get; set; }

    public virtual DateTime PublishingDate { get; set; }
}
