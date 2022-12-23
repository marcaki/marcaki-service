using System.Diagnostics.CodeAnalysis;
using MarcakiService.Domain.Entities.Projections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcakiService.Repository.Mappings;

[ExcludeFromCodeCoverage]
public class ProviderMapping : IEntityTypeConfiguration<ProviderProjection>
{
    
    public void Configure(EntityTypeBuilder<ProviderProjection> builder)
    {
        builder.HasMany<PhoneProjection>()
            .WithOne(x => x.Provider)
            .HasForeignKey(x => x.ProviderId);
    }
}