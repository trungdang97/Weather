using Microsoft.EntityFrameworkCore;

namespace Weather.Data.V1
{
    public interface IDatabaseFactory
    {
        DbContext GetDbContext();
        string GetPrefix();
    }
}