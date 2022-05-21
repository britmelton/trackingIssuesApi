using Microsoft.EntityFrameworkCore;
using trackingApi.Models;

namespace trackingApi.Data
{
    //DbContext is a class that iterates from a class named DbContext
    public class IssueDbContext : DbContext
    {
        //declare a constructor with a parameter of type DbContext Options
        public IssueDbContext(DbContextOptions<IssueDbContext> options)
            :base(options)
        {

        }
        //declare a DbSet, which is a representation of the table in the database
        //it will allow us to manipulate data from the table Issue
        public DbSet<Issue> Issues { get; set; }
    }
    //regisiter DbContext with the dependency injection container
    //this way we can request an instance in the controller
    //registrations take place in the Program.cs file
}
