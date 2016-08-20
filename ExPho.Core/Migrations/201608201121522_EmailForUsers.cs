namespace ExPho.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailForUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Juries", "Email", c => c.String());
            AddColumn("dbo.Learners", "Email", c => c.String());
            AddColumn("dbo.Teachers", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Email");
            DropColumn("dbo.Learners", "Email");
            DropColumn("dbo.Juries", "Email");
        }
    }
}
