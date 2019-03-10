﻿// <auto-generated />
using System;
using Ddp.Data.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ddp.Data.Ef.Migrations
{
    [DbContext(typeof(DdpContext))]
    partial class DdpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Ddp.Data.Ef.Tables.ConceptAttributeTable", b =>
                {
                    b.Property<Guid>("ConceptAttributeId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("ConceptId");

                    b.Property<string>("Name");

                    b.HasKey("ConceptAttributeId");

                    b.HasIndex("ConceptId");

                    b.ToTable("ConceptAttributes");
                });

            modelBuilder.Entity("Ddp.Data.Ef.Tables.ConceptTable", b =>
                {
                    b.Property<Guid>("ConceptId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<Guid>("DomainId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ConceptId");

                    b.HasIndex("DomainId");

                    b.ToTable("Concepts");
                });

            modelBuilder.Entity("Ddp.Data.Ef.Tables.DomainTable", b =>
                {
                    b.Property<Guid>("DomainId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("DomainId");

                    b.ToTable("Domains");
                });

            modelBuilder.Entity("Ddp.Data.Ef.Tables.EventTable", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EntityId")
                        .IsRequired();

                    b.Property<string>("EntityType")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<string>("EventData");

                    b.Property<string>("EventType")
                        .IsRequired()
                        .HasMaxLength(450);

                    b.Property<int>("Version");

                    b.HasKey("EventId");

                    b.ToTable("EventTables");
                });

            modelBuilder.Entity("Ddp.Data.Ef.Tables.ConceptAttributeTable", b =>
                {
                    b.HasOne("Ddp.Data.Ef.Tables.ConceptTable")
                        .WithMany()
                        .HasForeignKey("ConceptId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Ddp.Data.Ef.Tables.ConceptTable", b =>
                {
                    b.HasOne("Ddp.Data.Ef.Tables.DomainTable")
                        .WithMany()
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
