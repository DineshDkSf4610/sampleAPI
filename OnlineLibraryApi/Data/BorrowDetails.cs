using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema; 

namespace OnlineLibraryApi.Data
{
    [Table("borrowDetails", Schema = "public")]
    public class BorrowDetails
    {
        // •	BorrowID (Auto Increment – LB2000)
        // •	BookID 
        // •	UserID
        // •	BorrowedDate – ( Current Date and Time )
        // •	BorrowBookCount 
        // •	Status –  ( Enum - Default, Borrowed, Returned )
        // •	PaidFineAmount
        [Key]
        public int BorrowID { get; set; }

        public int BookID { get; set; }

        public int UserID { get; set; }

        public DateTime BorrowedDate { get; set; }

        public int BorrowBookCount { get; set; }

        public string Status { get; set; }

        public double PaidFineAmount { get; set; }

    }
}