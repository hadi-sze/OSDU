using Microsoft.EntityFrameworkCore;
namespace OSDU.Data;
public class Asset {
 public int Id { get; set; }
 public string Name { get; set; } = "";
 public string? Description { get; set; }
 public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
}
public class OsduDbContext(DbContextOptions<OsduDbContext> options) : DbContext(options) {
 public DbSet<Asset> Assets => Set<Asset>();
 protected override void OnModelCreating(ModelBuilder b) {
  b.Entity<Asset>().ToTable("Assets");
  b.Entity<Asset>().Property(x=>x.Name).HasMaxLength(200).IsRequired();
  b.Entity<Asset>().Property(x=>x.Description).HasMaxLength(2000);
 }
}
public class AssetRepository(OsduDbContext db) {
 public Task<List<Asset>> List(CancellationToken ct) => db.Assets.AsNoTracking().OrderBy(x=>x.Id).Take(100).ToListAsync(ct);
 public Task<Asset?> Find(int id, CancellationToken ct) => db.Assets.SingleOrDefaultAsync(x=>x.Id==id,ct);
 public async Task Add(Asset asset,CancellationToken ct) { db.Assets.Add(asset); await db.SaveChangesAsync(ct); }
 public Task Save(CancellationToken ct) => db.SaveChangesAsync(ct);
 public async Task Delete(Asset asset,CancellationToken ct) { db.Assets.Remove(asset); await db.SaveChangesAsync(ct); }
}
