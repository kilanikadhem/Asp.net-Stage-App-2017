using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Stage.Models;

namespace Stage.Migrations
{
    [DbContext(typeof(StageContext))]
    [Migration("20170815091809_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stage.Models.Formulaires", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("date_creation");

                    b.Property<DateTime>("date_fin");

                    b.Property<int>("nbreParticipant");

                    b.Property<int>("nbreQuestion");

                    b.Property<string>("sujet");

                    b.HasKey("id");

                    b.ToTable("Formulairess");
                });

            modelBuilder.Entity("Stage.Models.Question", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Formulairesid");

                    b.Property<string>("quest");

                    b.Property<string>("type");

                    b.HasKey("id");

                    b.HasIndex("Formulairesid");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Stage.Models.repense", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Questionid");

                    b.Property<string>("contenu");

                    b.Property<int>("nbreChoisie");

                    b.HasKey("id");

                    b.HasIndex("Questionid");

                    b.ToTable("repenses");
                });

            modelBuilder.Entity("Stage.Models.Question", b =>
                {
                    b.HasOne("Stage.Models.Formulaires")
                        .WithMany("Questions")
                        .HasForeignKey("Formulairesid");
                });

            modelBuilder.Entity("Stage.Models.repense", b =>
                {
                    b.HasOne("Stage.Models.Question")
                        .WithMany("repenses")
                        .HasForeignKey("Questionid");
                });
        }
    }
}
