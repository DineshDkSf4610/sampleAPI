using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineLibraryApi.Data
{
    [Table("userInfo", Schema = "public")]
    public class UserInfo
    {
        // a.	UserID (Auto Increment – SF3000)
        // b.	UserName
        // c.	Gender
        // d.	Department – (Enum – ECE, EEE, CSE)
        // e.	MobileNumber
        // f.	MailID
        [Key]
        public int UserID { get; set; }

        public string UserName { get; set; }

        public string Gender { get; set; }

        public string Department { get; set; }

        public string MobileNumber { get; set; }

        public string EmailID { get; set; }

        public string Password { get; set; }

        public double Balance { get; set; }
    }
}