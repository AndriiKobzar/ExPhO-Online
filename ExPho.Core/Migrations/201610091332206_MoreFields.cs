namespace ExPho.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Juries", "Institution", c => c.String());
            AddColumn("dbo.Juries", "Surname", c => c.String());
            AddColumn("dbo.Juries", "Phone", c => c.String());
            AddColumn("dbo.Learners", "Surname", c => c.String());
            AddColumn("dbo.Learners", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Learners", "Phone");
            DropColumn("dbo.Learners", "Surname");
            DropColumn("dbo.Juries", "Phone");
            DropColumn("dbo.Juries", "Surname");
            DropColumn("dbo.Juries", "Institution");
        }
    }
}
