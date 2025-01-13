using Animals_Web;
using FluentMigrator;

namespace Animals_Web.Data.Migrations
{
    [Migration(1112025)]
    public class TestMigrate:Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Script(@"Data/Scripts/data.sql");
        }









    }
}
