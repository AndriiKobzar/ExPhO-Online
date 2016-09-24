namespace ExPho.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VisitJuries", "Visit_Id", "dbo.Visits");
            DropForeignKey("dbo.VisitJuries", "Jury_Id", "dbo.Juries");
            DropIndex("dbo.VisitJuries", new[] { "Visit_Id" });
            DropIndex("dbo.VisitJuries", new[] { "Jury_Id" });
            CreateTable(
                "dbo.Olympiads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Juries", "Problem_Id", c => c.Int());
            AddColumn("dbo.Juries", "Olympiad_Id", c => c.Int());
            AddColumn("dbo.Visits", "Olympiad_Id", c => c.Int());
            AddColumn("dbo.Visits", "Jury_Id", c => c.Int());
            AddColumn("dbo.Problems", "Olympiad_Id", c => c.Int());
            AddColumn("dbo.Teams", "Olympiad_Id", c => c.Int());
            CreateIndex("dbo.Juries", "Problem_Id");
            CreateIndex("dbo.Juries", "Olympiad_Id");
            CreateIndex("dbo.Problems", "Olympiad_Id");
            CreateIndex("dbo.Visits", "Olympiad_Id");
            CreateIndex("dbo.Visits", "Jury_Id");
            CreateIndex("dbo.Teams", "Olympiad_Id");
            AddForeignKey("dbo.Juries", "Problem_Id", "dbo.Problems", "Id");
            AddForeignKey("dbo.Juries", "Olympiad_Id", "dbo.Olympiads", "Id");
            AddForeignKey("dbo.Problems", "Olympiad_Id", "dbo.Olympiads", "Id");
            AddForeignKey("dbo.Visits", "Olympiad_Id", "dbo.Olympiads", "Id");
            AddForeignKey("dbo.Teams", "Olympiad_Id", "dbo.Olympiads", "Id");
            AddForeignKey("dbo.Visits", "Jury_Id", "dbo.Juries", "Id");
            DropTable("dbo.VisitJuries");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VisitJuries",
                c => new
                    {
                        Visit_Id = c.Int(nullable: false),
                        Jury_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Visit_Id, t.Jury_Id });
            
            DropForeignKey("dbo.Visits", "Jury_Id", "dbo.Juries");
            DropForeignKey("dbo.Teams", "Olympiad_Id", "dbo.Olympiads");
            DropForeignKey("dbo.Visits", "Olympiad_Id", "dbo.Olympiads");
            DropForeignKey("dbo.Problems", "Olympiad_Id", "dbo.Olympiads");
            DropForeignKey("dbo.Juries", "Olympiad_Id", "dbo.Olympiads");
            DropForeignKey("dbo.Juries", "Problem_Id", "dbo.Problems");
            DropIndex("dbo.Teams", new[] { "Olympiad_Id" });
            DropIndex("dbo.Visits", new[] { "Jury_Id" });
            DropIndex("dbo.Visits", new[] { "Olympiad_Id" });
            DropIndex("dbo.Problems", new[] { "Olympiad_Id" });
            DropIndex("dbo.Juries", new[] { "Olympiad_Id" });
            DropIndex("dbo.Juries", new[] { "Problem_Id" });
            DropColumn("dbo.Teams", "Olympiad_Id");
            DropColumn("dbo.Problems", "Olympiad_Id");
            DropColumn("dbo.Visits", "Jury_Id");
            DropColumn("dbo.Visits", "Olympiad_Id");
            DropColumn("dbo.Juries", "Olympiad_Id");
            DropColumn("dbo.Juries", "Problem_Id");
            DropTable("dbo.Olympiads");
            CreateIndex("dbo.VisitJuries", "Jury_Id");
            CreateIndex("dbo.VisitJuries", "Visit_Id");
            AddForeignKey("dbo.VisitJuries", "Jury_Id", "dbo.Juries", "Id", cascadeDelete: true);
            AddForeignKey("dbo.VisitJuries", "Visit_Id", "dbo.Visits", "Id", cascadeDelete: true);
        }
    }
}
