using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaserTag_API.Core.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    is_gun = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Configs",
                columns: table => new
                {
                    config_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    code_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    config_type_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configs", x => x.config_id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    stage_id = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mac_gun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mac_vest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    current_health = table.Column<int>(type: "int", nullable: false),
                    current_bullet = table.Column<int>(type: "int", nullable: false),
                    balance = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    round_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    round_stage_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    match_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.round_id);
                });

            migrationBuilder.CreateTable(
                name: "Shared_Groups",
                columns: table => new
                {
                    group_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    group_name1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group_name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group_name3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group_name4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    group_name5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared_Groups", x => x.group_id);
                });

            migrationBuilder.CreateTable(
                name: "Upgrades",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Player_Attributes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_id = table.Column<int>(type: "int", nullable: false),
                    playerid = table.Column<int>(type: "int", nullable: false),
                    attribute_id = table.Column<int>(type: "int", nullable: false),
                    attributeid = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Attributes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Player_Attributes_Attributes_attributeid",
                        column: x => x.attributeid,
                        principalTable: "Attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Attributes_Players_playerid",
                        column: x => x.playerid,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Matches",
                columns: table => new
                {
                    player_match_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_id = table.Column<int>(type: "int", nullable: false),
                    playerid = table.Column<int>(type: "int", nullable: false),
                    match_id = table.Column<int>(type: "int", nullable: false),
                    matchid = table.Column<int>(type: "int", nullable: false),
                    team_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Matches", x => x.player_match_id);
                    table.ForeignKey(
                        name: "FK_Player_Matches_Matches_matchid",
                        column: x => x.matchid,
                        principalTable: "Matches",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Matches_Players_playerid",
                        column: x => x.playerid,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hit_Logs",
                columns: table => new
                {
                    hit_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    source_player_id = table.Column<int>(type: "int", nullable: false),
                    target_player_id = table.Column<int>(type: "int", nullable: false),
                    round_id = table.Column<int>(type: "int", nullable: false),
                    round_id1 = table.Column<int>(type: "int", nullable: false),
                    hit_type_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hit_Logs", x => x.hit_log_id);
                    table.ForeignKey(
                        name: "FK_Hit_Logs_Rounds_round_id1",
                        column: x => x.round_id1,
                        principalTable: "Rounds",
                        principalColumn: "round_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shoot_Logs",
                columns: table => new
                {
                    shoot_log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_id = table.Column<int>(type: "int", nullable: false),
                    playerid = table.Column<int>(type: "int", nullable: false),
                    round_id = table.Column<int>(type: "int", nullable: false),
                    round_id1 = table.Column<int>(type: "int", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoot_Logs", x => x.shoot_log_id);
                    table.ForeignKey(
                        name: "FK_Shoot_Logs_Players_playerid",
                        column: x => x.playerid,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoot_Logs_Rounds_round_id1",
                        column: x => x.round_id1,
                        principalTable: "Rounds",
                        principalColumn: "round_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shared_Bases",
                columns: table => new
                {
                    base_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    group_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shared_Groupgroup_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    base_name1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    base_name2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    base_name3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    base_name4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    base_name5 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sort = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shared_Bases", x => x.base_id);
                    table.ForeignKey(
                        name: "FK_Shared_Bases_Shared_Groups_shared_Groupgroup_id",
                        column: x => x.shared_Groupgroup_id,
                        principalTable: "Shared_Groups",
                        principalColumn: "group_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Upgrade_Attributes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    upgrade_id = table.Column<int>(type: "int", nullable: false),
                    upgradeid = table.Column<int>(type: "int", nullable: false),
                    attribute_id = table.Column<int>(type: "int", nullable: false),
                    attributeid = table.Column<int>(type: "int", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Upgrade_Attributes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Upgrade_Attributes_Attributes_attributeid",
                        column: x => x.attributeid,
                        principalTable: "Attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Upgrade_Attributes_Upgrades_upgradeid",
                        column: x => x.upgradeid,
                        principalTable: "Upgrades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Player_Upgrades",
                columns: table => new
                {
                    player_upgrade_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_match_id = table.Column<int>(type: "int", nullable: false),
                    player_match_id1 = table.Column<int>(type: "int", nullable: false),
                    upgrade_id = table.Column<int>(type: "int", nullable: false),
                    upgradeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player_Upgrades", x => x.player_upgrade_id);
                    table.ForeignKey(
                        name: "FK_Player_Upgrades_Player_Matches_player_match_id1",
                        column: x => x.player_match_id1,
                        principalTable: "Player_Matches",
                        principalColumn: "player_match_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Player_Upgrades_Upgrades_upgradeid",
                        column: x => x.upgradeid,
                        principalTable: "Upgrades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hit_Logs_round_id1",
                table: "Hit_Logs",
                column: "round_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Attributes_attributeid",
                table: "Player_Attributes",
                column: "attributeid");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Attributes_playerid",
                table: "Player_Attributes",
                column: "playerid");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Matches_matchid",
                table: "Player_Matches",
                column: "matchid");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Matches_playerid",
                table: "Player_Matches",
                column: "playerid");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Upgrades_player_match_id1",
                table: "Player_Upgrades",
                column: "player_match_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Player_Upgrades_upgradeid",
                table: "Player_Upgrades",
                column: "upgradeid");

            migrationBuilder.CreateIndex(
                name: "IX_Shared_Bases_shared_Groupgroup_id",
                table: "Shared_Bases",
                column: "shared_Groupgroup_id");

            migrationBuilder.CreateIndex(
                name: "IX_Shoot_Logs_playerid",
                table: "Shoot_Logs",
                column: "playerid");

            migrationBuilder.CreateIndex(
                name: "IX_Shoot_Logs_round_id1",
                table: "Shoot_Logs",
                column: "round_id1");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrade_Attributes_attributeid",
                table: "Upgrade_Attributes",
                column: "attributeid");

            migrationBuilder.CreateIndex(
                name: "IX_Upgrade_Attributes_upgradeid",
                table: "Upgrade_Attributes",
                column: "upgradeid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configs");

            migrationBuilder.DropTable(
                name: "Hit_Logs");

            migrationBuilder.DropTable(
                name: "Player_Attributes");

            migrationBuilder.DropTable(
                name: "Player_Upgrades");

            migrationBuilder.DropTable(
                name: "Shared_Bases");

            migrationBuilder.DropTable(
                name: "Shoot_Logs");

            migrationBuilder.DropTable(
                name: "Upgrade_Attributes");

            migrationBuilder.DropTable(
                name: "Player_Matches");

            migrationBuilder.DropTable(
                name: "Shared_Groups");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropTable(
                name: "Upgrades");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
