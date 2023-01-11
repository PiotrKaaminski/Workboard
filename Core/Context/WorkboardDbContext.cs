using Microsoft.EntityFrameworkCore;
using Task = Workboard.Entities.Task;
using TaskStatus = Workboard.Entities.TaskStatus;

namespace Workboard.Context;

public partial class WorkboardDbContext : DbContext
{
    public static WorkboardDbContext Instance { get; } = new();

    public WorkboardDbContext()
    {
    }

    public WorkboardDbContext(DbContextOptions<WorkboardDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TaskStatus> TaskStatuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost; Database=workboard; Username=workboard; Password=workboard");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tasks_pk");

            entity.ToTable("tasks", "workboard");

            entity.Property(e => e.Id)
                .HasIdentityOptions(null, null, null, 2147483647L, null, null)
                .HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.Title).HasColumnName("title");

            entity.HasOne(d => d.Status).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("events_event_status_fk");
        });

        modelBuilder.Entity<TaskStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("task_statuses_pk");

            entity.ToTable("task_statuses", "workboard");

            entity.Property(e => e.Id)
                .UseIdentityAlwaysColumn()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(128)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
