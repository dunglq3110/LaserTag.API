﻿// <auto-generated />
using System;
using LaserTag_API.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LaserTag_API.Core.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240929100313_InitAppDbContext")]
    partial class InitAppDbContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LaserTag_API.Core.Models.attribute", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("code_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("is_gun")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Attributes");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.config", b =>
                {
                    b.Property<string>("config_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("code_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("config_typebase_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("value5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("config_id");

                    b.HasIndex("config_typebase_id");

                    b.ToTable("Configs");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.hit_log", b =>
                {
                    b.Property<string>("hit_log_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("hit_typebase_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("round_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("source_playerid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("target_playerid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("value")
                        .HasColumnType("int");

                    b.HasKey("hit_log_id");

                    b.HasIndex("hit_typebase_id");

                    b.HasIndex("round_id");

                    b.HasIndex("source_playerid");

                    b.HasIndex("target_playerid");

                    b.ToTable("Hit_Logs");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.match", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("stagebase_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("id");

                    b.HasIndex("stagebase_id");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.player", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("balance")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("current_bullet")
                        .HasColumnType("int");

                    b.Property<int>("current_health")
                        .HasColumnType("int");

                    b.Property<string>("mac_gun")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mac_vest")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.player_attribute", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("attributeid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("playerid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("attributeid");

                    b.HasIndex("playerid");

                    b.ToTable("Player_Attributes");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.player_match", b =>
                {
                    b.Property<string>("player_match_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("matchid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("playerid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("teambase_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("player_match_id");

                    b.HasIndex("matchid");

                    b.HasIndex("playerid");

                    b.HasIndex("teambase_id");

                    b.ToTable("Player_Matches");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.player_upgrade", b =>
                {
                    b.Property<string>("player_upgrade_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("player_match_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("upgradeid")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("player_upgrade_id");

                    b.HasIndex("player_match_id");

                    b.HasIndex("upgradeid");

                    b.ToTable("Player_Upgrades");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.round", b =>
                {
                    b.Property<string>("round_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("matchid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("round_stagebase_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("round_id");

                    b.HasIndex("matchid");

                    b.HasIndex("round_stagebase_id");

                    b.ToTable("Rounds");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.shared_base", b =>
                {
                    b.Property<string>("base_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("base_name1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("base_name2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("base_name3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("base_name4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("base_name5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group_id1")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("sort")
                        .HasColumnType("int");

                    b.HasKey("base_id");

                    b.HasIndex("group_id1");

                    b.ToTable("Shared_Bases");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.shared_group", b =>
                {
                    b.Property<string>("group_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group_name1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group_name2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group_name3")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group_name4")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("group_name5")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("group_id");

                    b.ToTable("Shared_Groups");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.shoot_log", b =>
                {
                    b.Property<string>("shoot_log_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("playerid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("round_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("shoot_log_id");

                    b.HasIndex("playerid");

                    b.HasIndex("round_id");

                    b.ToTable("Shoot_Logs");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.upgrade", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("id");

                    b.ToTable("Upgrades");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.upgrade_attribute", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("attributeid")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("upgradeid")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("value")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("attributeid");

                    b.HasIndex("upgradeid");

                    b.ToTable("Upgrade_Attributes");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.config", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.shared_base", "config_type")
                        .WithMany()
                        .HasForeignKey("config_typebase_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("config_type");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.hit_log", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.shared_base", "hit_type")
                        .WithMany()
                        .HasForeignKey("hit_typebase_id");

                    b.HasOne("LaserTag_API.Core.Models.round", "round")
                        .WithMany()
                        .HasForeignKey("round_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaserTag_API.Core.Models.player", "source_player")
                        .WithMany()
                        .HasForeignKey("source_playerid");

                    b.HasOne("LaserTag_API.Core.Models.player", "target_player")
                        .WithMany()
                        .HasForeignKey("target_playerid");

                    b.Navigation("hit_type");

                    b.Navigation("round");

                    b.Navigation("source_player");

                    b.Navigation("target_player");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.match", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.shared_base", "stage")
                        .WithMany()
                        .HasForeignKey("stagebase_id");

                    b.Navigation("stage");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.player_attribute", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.attribute", "attribute")
                        .WithMany()
                        .HasForeignKey("attributeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaserTag_API.Core.Models.player", "player")
                        .WithMany()
                        .HasForeignKey("playerid");

                    b.Navigation("attribute");

                    b.Navigation("player");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.player_match", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.match", "match")
                        .WithMany()
                        .HasForeignKey("matchid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaserTag_API.Core.Models.player", "player")
                        .WithMany()
                        .HasForeignKey("playerid");

                    b.HasOne("LaserTag_API.Core.Models.shared_base", "team")
                        .WithMany()
                        .HasForeignKey("teambase_id");

                    b.Navigation("match");

                    b.Navigation("player");

                    b.Navigation("team");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.player_upgrade", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.player_match", "player_match")
                        .WithMany()
                        .HasForeignKey("player_match_id");

                    b.HasOne("LaserTag_API.Core.Models.upgrade", "upgrade")
                        .WithMany()
                        .HasForeignKey("upgradeid");

                    b.Navigation("player_match");

                    b.Navigation("upgrade");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.round", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.match", "match")
                        .WithMany()
                        .HasForeignKey("matchid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaserTag_API.Core.Models.shared_base", "round_stage")
                        .WithMany()
                        .HasForeignKey("round_stagebase_id");

                    b.Navigation("match");

                    b.Navigation("round_stage");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.shared_base", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.shared_group", "group_id")
                        .WithMany()
                        .HasForeignKey("group_id1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("group_id");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.shoot_log", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.player", "player")
                        .WithMany()
                        .HasForeignKey("playerid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaserTag_API.Core.Models.round", "round")
                        .WithMany()
                        .HasForeignKey("round_id");

                    b.Navigation("player");

                    b.Navigation("round");
                });

            modelBuilder.Entity("LaserTag_API.Core.Models.upgrade_attribute", b =>
                {
                    b.HasOne("LaserTag_API.Core.Models.attribute", "attribute")
                        .WithMany()
                        .HasForeignKey("attributeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LaserTag_API.Core.Models.upgrade", "upgrade")
                        .WithMany()
                        .HasForeignKey("upgradeid");

                    b.Navigation("attribute");

                    b.Navigation("upgrade");
                });
#pragma warning restore 612, 618
        }
    }
}
