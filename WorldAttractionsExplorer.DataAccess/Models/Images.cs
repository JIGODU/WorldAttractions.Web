using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldAttractionsExplorer.DataAccess.Models;

public class Images
{
    public int ImageId { get; set; }

    public int AttractionId { get; set; }

    public Attractions Attraction { get; set; }

    public string ImagePath { get; set; }

    public int OwnerId { get; set; }

    public Users Owner { get; set; }
}
