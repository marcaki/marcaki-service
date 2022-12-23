using System.Diagnostics.CodeAnalysis;
using MarcakiService.Domain.Entities.Aggregates;
using MarcakiService.Domain.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarcakiService.Repository.Mappings;

[ExcludeFromCodeCoverage]
public class AggregateMapping : IEntityTypeConfiguration<AggregateRoot>
{
    public void Configure(EntityTypeBuilder<AggregateRoot> builder)
    {
        builder.HasMany<BaseEvent>()
            .WithOne(x => x.AggregateRoot)
            .HasForeignKey(y => y.AggregateId);
    }
}