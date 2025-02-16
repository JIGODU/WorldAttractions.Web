using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WorldAttractionsExplorer.DataAccess.Models;

public class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; }

    public ICollection<Attractions> Attractions { get; set; }
}
