using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldAttractionsExplorer.DataAccess.Models;

public class Tags
{
    public int TagId { get; set; }

    public string TagName { get; set; }

    public List<AttractionTags> AttractionTags { get; set; }
}
