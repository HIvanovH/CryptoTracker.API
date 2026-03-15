using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CryptoTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedAssets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "Id", "CurrentPrice", "LastUpdated", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("30bc7bcd-633a-4e47-adf8-a9620042e94b"), 3000m, new DateTime(2026, 3, 14, 19, 12, 6, 557, DateTimeKind.Utc).AddTicks(3294), "Ethereum", "ETH" },
                    { new Guid("9ef730f7-e684-4bd0-b1a5-05dc92b853d6"), 150m, new DateTime(2026, 3, 14, 19, 12, 6, 557, DateTimeKind.Utc).AddTicks(3296), "Solana", "SOL" },
                    { new Guid("d0c13454-46be-4ede-9659-4df05b672b3b"), 50000m, new DateTime(2026, 3, 14, 19, 12, 6, 557, DateTimeKind.Utc).AddTicks(3290), "Bitcoin", "BTC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("30bc7bcd-633a-4e47-adf8-a9620042e94b"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("9ef730f7-e684-4bd0-b1a5-05dc92b853d6"));

            migrationBuilder.DeleteData(
                table: "Assets",
                keyColumn: "Id",
                keyValue: new Guid("d0c13454-46be-4ede-9659-4df05b672b3b"));
        }
    }
}
