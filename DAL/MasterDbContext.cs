using Microsoft.EntityFrameworkCore;
using System;
namespace DAL
{
    public class MasterDbContext:DbContext
    {

        public MasterDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
