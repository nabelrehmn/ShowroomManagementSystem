using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShowroomManagmentAPI.Migrations
{
    public partial class InitializeCampaignChannel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignChannelMappings",
                columns: table => new
                {
                    MappingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCampaignID = table.Column<int>(type: "int", nullable: false),
                    FKChannelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignChannelMappings", x => x.MappingID);
                    table.ForeignKey(
                        name: "FK_CampaignChannelMappings_Campaign_FKCampaignID",
                        column: x => x.FKCampaignID,
                        principalTable: "Campaign",
                        principalColumn: "CampaignID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignChannelMappings_Channels_FKChannelID",
                        column: x => x.FKChannelID,
                        principalTable: "Channels",
                        principalColumn: "ChannelID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CampaignCustomerSegmentMappings",
                columns: table => new
                {
                    MappingCustomerSegmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FKCampaignID = table.Column<int>(type: "int", nullable: false),
                    FKSegmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignCustomerSegmentMappings", x => x.MappingCustomerSegmentID);
                    table.ForeignKey(
                        name: "FK_CampaignCustomerSegmentMappings_Campaign_FKCampaignID",
                        column: x => x.FKCampaignID,
                        principalTable: "Campaign",
                        principalColumn: "CampaignID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CampaignCustomerSegmentMappings_CustomerSegments_FKSegmentID",
                        column: x => x.FKSegmentID,
                        principalTable: "CustomerSegments",
                        principalColumn: "SegmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignChannelMappings_FKCampaignID",
                table: "CampaignChannelMappings",
                column: "FKCampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignChannelMappings_FKChannelID",
                table: "CampaignChannelMappings",
                column: "FKChannelID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCustomerSegmentMappings_FKCampaignID",
                table: "CampaignCustomerSegmentMappings",
                column: "FKCampaignID");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignCustomerSegmentMappings_FKSegmentID",
                table: "CampaignCustomerSegmentMappings",
                column: "FKSegmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignChannelMappings");

            migrationBuilder.DropTable(
                name: "CampaignCustomerSegmentMappings");
        }
    }
}
