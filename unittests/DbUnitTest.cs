using Xunit;
using Microsoft.EntityFrameworkCore;
using MarsWeatherApi.Contexts;

namespace unittests;

public class DbUnitTest
{
    private readonly ApplicationDbContext _context;

    public DbUnitTest()
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        string connectionstring = "server=localhost\\sqlexpress;database=marsweatherapidb;trusted_connection=true";
        optionsBuilder.UseSqlServer(connectionstring);
        _context = new ApplicationDbContext(optionsBuilder.Options);
    }

    [Fact]
    public void DbConnectionExists()
    {
        Assert.True(_context.Database.CanConnect(), "No database connection exists");
    }

    [Fact]
    public void DbIsRelational()
    {
        Assert.True(_context.Database.IsRelational(), "Database is not relational");
    }

    [Fact]
    public void DbIsNotInMemory()
    {
        Assert.False(_context.Database.IsInMemory(), "Database is InMemory");
    }

    [Fact]
    public void DbIsSqlServer()
    {
        Assert.True(_context.Database.IsSqlServer(), "Database is not SQLServer");
    }

}