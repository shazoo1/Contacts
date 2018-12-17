namespace Contacts.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExtendPhoneNumberConstraint : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "PhoneNumber", c => c.String(nullable: false, maxLength: 17));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "PhoneNumber", c => c.String(nullable: false, maxLength: 15));
        }
    }
}
