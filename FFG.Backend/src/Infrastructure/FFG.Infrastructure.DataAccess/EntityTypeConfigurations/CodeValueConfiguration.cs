using FFG.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FFG.Infrastructure.DataAccess.EntityTypeConfigurations
{
    internal class CodeValueConfiguration : IEntityTypeConfiguration<CodeValue>
    {
        public void Configure(EntityTypeBuilder<CodeValue> builder) 
        {
            builder.HasKey(codeValue => codeValue.Id);
            builder.HasIndex(codeValue => codeValue.Id).IsUnique();
            builder.Property(codeValue => codeValue.Code).IsRequired();
            builder.Property(codeValue => codeValue.Value).IsRequired().HasMaxLength(100);
        }
    }
}
