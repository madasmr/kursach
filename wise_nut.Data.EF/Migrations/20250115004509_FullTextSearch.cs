using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wise_nut.Data.EF.Migrations
{
    /// <inheritdoc />
    public partial class FullTextSearch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("CREATE FULLTEXT CATALOG StoreFullTextCatalog AS DEFAULT", suppressTransaction: true);
			migrationBuilder.Sql("CREATE FULLTEXT INDEX ON Products(Type, Title) KEY INDEX PK_Products WITH STOPLIST = SYSTEM", suppressTransaction: true);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP FULLTEXT INDEX ON Products", suppressTransaction: true);
			migrationBuilder.Sql("DROP FULLTEXT CATALOG StoreFullTextCatalog", suppressTransaction: true);
		}
    }
}
