using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLibraryApi.Data
{
    [Table("bookDetails", Schema = "public")]
    public class BookDetails
    {
        // 1.	BookID (Auto Increment - BID1000)
        // 2.	BookName
        // 3.	AuthorName
        // 4.	BookCount
        [Key]
        public int BookID { get; set; }

        public string BookName { get; set; }

        public string AuthorName { get; set; }

        public int BookCount { get; set; }


    }
}