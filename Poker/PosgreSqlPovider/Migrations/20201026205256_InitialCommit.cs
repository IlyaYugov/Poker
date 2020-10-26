using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PosgreSqlPovider.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NickName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardId = table.Column<int>(type: "integer", nullable: true),
                    TotalBank = table.Column<double>(type: "double precision", nullable: false),
                    GameLimit = table.Column<string>(type: "text", nullable: true),
                    SmallBlind = table.Column<double>(type: "double precision", nullable: false),
                    BigBlind = table.Column<double>(type: "double precision", nullable: false),
                    GameType = table.Column<int>(type: "integer", nullable: false),
                    MaxPlayersCount = table.Column<int>(type: "integer", nullable: false),
                    PlayersCount = table.Column<int>(type: "integer", nullable: false),
                    ButtonSeatStringPart = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatistic",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerGameSnapshotId = table.Column<int>(type: "integer", nullable: true),
                    TotalGames = table.Column<int>(type: "integer", nullable: false),
                    TotalEnterFlop = table.Column<int>(type: "integer", nullable: false),
                    TotalEnterTurn = table.Column<int>(type: "integer", nullable: false),
                    TotalEnterRiver = table.Column<int>(type: "integer", nullable: false),
                    TotalEnterShowDown = table.Column<int>(type: "integer", nullable: false),
                    WinnedMoney = table.Column<double>(type: "double precision", nullable: false),
                    WinnedBlinds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatistic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatistic_Player_PlayerGameSnapshotId",
                        column: x => x.PlayerGameSnapshotId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGame",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "integer", nullable: false),
                    PlayersId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGame", x => new { x.GamesId, x.PlayersId });
                    table.ForeignKey(
                        name: "FK_PlayerGame_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerGame_Player_PlayersId",
                        column: x => x.PlayersId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerGameSnapshot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MoneyOnStart = table.Column<double>(type: "double precision", nullable: false),
                    CollectedMoney = table.Column<double>(type: "double precision", nullable: false),
                    GaveMoneyToBank = table.Column<double>(type: "double precision", nullable: false),
                    PositionType = table.Column<int>(type: "integer", nullable: false),
                    PlayerId = table.Column<int>(type: "integer", nullable: true),
                    GameId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerGameSnapshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerGameSnapshot_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerGameSnapshot_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Round",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoundType = table.Column<int>(type: "integer", nullable: false),
                    GameId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Round", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Round_Game_GameId",
                        column: x => x.GameId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardId = table.Column<int>(type: "integer", nullable: true),
                    PlayerGameSnapshotId = table.Column<int>(type: "integer", nullable: true),
                    RoundId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Card_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_PlayerGameSnapshot_PlayerGameSnapshotId",
                        column: x => x.PlayerGameSnapshotId,
                        principalTable: "PlayerGameSnapshot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Card_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FinishedPlayerRound",
                columns: table => new
                {
                    FinishedPlayersId = table.Column<int>(type: "integer", nullable: false),
                    FinishedRoundsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishedPlayerRound", x => new { x.FinishedPlayersId, x.FinishedRoundsId });
                    table.ForeignKey(
                        name: "FK_FinishedPlayerRound_PlayerGameSnapshot_FinishedPlayersId",
                        column: x => x.FinishedPlayersId,
                        principalTable: "PlayerGameSnapshot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinishedPlayerRound_Round_FinishedRoundsId",
                        column: x => x.FinishedRoundsId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerAction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerGameSnapshotId = table.Column<int>(type: "integer", nullable: true),
                    ActionType = table.Column<int>(type: "integer", nullable: false),
                    Money = table.Column<double>(type: "double precision", nullable: false),
                    RoundId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerAction_PlayerGameSnapshot_PlayerGameSnapshotId",
                        column: x => x.PlayerGameSnapshotId,
                        principalTable: "PlayerGameSnapshot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlayerAction_Round_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StartedPlayerRound",
                columns: table => new
                {
                    StartedPlayersId = table.Column<int>(type: "integer", nullable: false),
                    StartedRoundsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StartedPlayerRound", x => new { x.StartedPlayersId, x.StartedRoundsId });
                    table.ForeignKey(
                        name: "FK_StartedPlayerRound_PlayerGameSnapshot_StartedPlayersId",
                        column: x => x.StartedPlayersId,
                        principalTable: "PlayerGameSnapshot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StartedPlayerRound_Round_StartedRoundsId",
                        column: x => x.StartedRoundsId,
                        principalTable: "Round",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Card_BoardId",
                table: "Card",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_PlayerGameSnapshotId",
                table: "Card",
                column: "PlayerGameSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_Card_RoundId",
                table: "Card",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedPlayerRound_FinishedRoundsId",
                table: "FinishedPlayerRound",
                column: "FinishedRoundsId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_BoardId",
                table: "Game",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAction_PlayerGameSnapshotId",
                table: "PlayerAction",
                column: "PlayerGameSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAction_RoundId",
                table: "PlayerAction",
                column: "RoundId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGame_PlayersId",
                table: "PlayerGame",
                column: "PlayersId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameSnapshot_GameId",
                table: "PlayerGameSnapshot",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerGameSnapshot_PlayerId",
                table: "PlayerGameSnapshot",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistic_PlayerGameSnapshotId",
                table: "PlayerStatistic",
                column: "PlayerGameSnapshotId");

            migrationBuilder.CreateIndex(
                name: "IX_Round_GameId",
                table: "Round",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_StartedPlayerRound_StartedRoundsId",
                table: "StartedPlayerRound",
                column: "StartedRoundsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropTable(
                name: "FinishedPlayerRound");

            migrationBuilder.DropTable(
                name: "PlayerAction");

            migrationBuilder.DropTable(
                name: "PlayerGame");

            migrationBuilder.DropTable(
                name: "PlayerStatistic");

            migrationBuilder.DropTable(
                name: "StartedPlayerRound");

            migrationBuilder.DropTable(
                name: "PlayerGameSnapshot");

            migrationBuilder.DropTable(
                name: "Round");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Board");
        }
    }
}
