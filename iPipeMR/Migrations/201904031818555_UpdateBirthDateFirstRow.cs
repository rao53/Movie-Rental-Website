namespace iPipeMR.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBirthDateFirstRow : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate= CAST('1998-03-12' AS DATETIME) WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
