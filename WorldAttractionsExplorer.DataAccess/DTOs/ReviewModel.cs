using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldAttractionsExplorer.DataAccess.Models;

namespace WorldAttractionsExplorer.DataAccess.DTOs
{
    public class ReviewModel
    {
        public int ReviewId { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUserName { get; set; }

        public int AttractionId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double Rating { get; set; }

        public DateTime PublishingDate { get; set; }
        
        public DateTime LastModifiedOn { get; set; }
    }
}
