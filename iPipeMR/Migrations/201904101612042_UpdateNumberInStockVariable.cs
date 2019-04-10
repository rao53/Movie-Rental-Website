namespace iPipeMR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNumberInStockVariable : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MOVIES SET MOVIES.NumberAvailable = MOVIES.NumberInStock");
        }
        
        public override void Down()
        {
        }
    }
}
