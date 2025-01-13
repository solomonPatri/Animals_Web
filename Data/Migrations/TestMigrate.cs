using Animals_Web;
using FluentMigrator;

namespace Animals_Web.Data.Migrations
{
    [Migration(11112025)]
    public class TestMigrate:Migration
    {
        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            Execute.Script(@"Data/scripts/data.sql");
        }









    }
}
