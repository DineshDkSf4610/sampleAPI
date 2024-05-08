using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineLibraryApi.Data;

namespace OnlineLibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;

        public UserInfoController(ApplicationDBContext applicationDBContext)
        {
            _dbContext = applicationDBContext;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_dbContext.userList.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _dbContext.userList.FirstOrDefault(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult PutUser(int id, [FromBody] UserInfo user)
        {
            var index = _dbContext.userList.FirstOrDefault(m => m.UserID == id);
            if (index == null)
            {
                return NotFound();
            }
            index.EmailID = user.EmailID;
            index.Password = user.Password;
            index.MobileNumber = user.MobileNumber;
            index.Balance = user.Balance;
            _dbContext.SaveChanges();
            //You might want to return NoContent or another appropriate response
            return Ok();
        }
        [HttpPost]
        public IActionResult AddUser([FromBody] UserInfo user)
        {
            _dbContext.userList.Add(user);
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}



// create table "UserInfo"
// (
// 	"UserID" serial primary key,
// 	"UserName" varchar(250) not null,
// 	"Gender" varchar(250) not null,
// 	"Department" varchar(250) not null,
// 	"MobileNumber" varchar(250) not null,
// 	"EmailID" varchar(250) not null,
// 	"Password" varchar(250) not null
// );


// create table "BorrowDetails"
// (
// 	"BorrowID" serial primary key,
// 	"BookID" integer not null,
// 	"UserID" integer not null,
// 	"BorrowedDate" date not null,
// 	"BorrowBookCount" integer not null,
// 	"Status" varchar(250) not null,
// 	"PaidFineAmount" numeric(10,2) not null
// );

// create table "BookDetails"
// (
// 	"BookID" serial primary key,
// 	"BookName" varchar(250) not null,
// 	"AuthorName" varchar(250) not null,
// 	"BookCount" integer not null
// );

// insert into "userInfo" ("UserName","Gender","Department","MobileNumber","EmailID","Password") values ('dinesh','Male','MCA','6384225424','dinesh@gmail.com','123456');

// insert into "borrowDetails"("BookID","UserID","BorrowedDate","BorrowBookCount","Status","PaidFineAmount") values (1,1,'2024-05-05',1,'Borrowed',0);

// insert into "bookDetails"("BookName","AuthorName","BookCount") values ('C#','Author1',3);