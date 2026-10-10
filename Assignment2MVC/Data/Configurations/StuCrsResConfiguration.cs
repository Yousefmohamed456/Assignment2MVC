using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem.Models;

namespace SchoolSystem.Data.Configurations
{
    public class StuCrsResConfiguration : IEntityTypeConfiguration<StuCrsRes>
    {
        public void Configure(EntityTypeBuilder<StuCrsRes> builder)
        {
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });

            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.StuCrsRes)
                   .HasForeignKey(sc => sc.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StuCrsRes)
                   .HasForeignKey(sc => sc.CourseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
