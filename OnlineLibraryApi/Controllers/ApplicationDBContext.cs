using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineLibraryApi.Data;

namespace OnlineLibraryApi.Controllers
{
    public class ApplicationDBContext : DbContext, IDisposable
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<UserInfo> userList { get; set; }

        public DbSet<BookDetails> bookList { get; set; }

        public DbSet<BorrowDetails> borrowList { get; set; }
    }
}