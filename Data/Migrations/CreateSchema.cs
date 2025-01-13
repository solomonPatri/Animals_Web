using FluentMigrator;

namespace Animals_Web.Data.Migrations
{
    [Migration(11012025)]
    public class CreateSchema : Migration
    {

        public override void Down()
        {



        }

        public override void Up()
        {
            Create.Table("users")
              .WithColumn("Id").AsInt32().PrimaryKey().Identity()
              .WithColumn("Types").AsString(130).NotNullable()
              .WithColumn("Name").AsString(130).NotNullable()
              .WithColumn("Weight").AsDouble().NotNullable()
              .WithColumn("Country").AsString(130).NotNullable()
              .WithColumn("Age").AsInt32().NotNullable();



        }




    }













}