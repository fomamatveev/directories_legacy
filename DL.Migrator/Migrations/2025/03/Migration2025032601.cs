using System.Data.Common;
using Dapper;
using DL.Migrator.Data;

namespace DL.Migrator.Migrations._2025._03;

internal class Migration2025032601(DbConnection databaseConnection) : MigrationBase(databaseConnection, 2025032601)
{
    public override void Up()
    {
        var query = """
                    INSERT INTO "User" ("Id", "Username", "PasswordHash", "PasswordSalt", "CreatedAt")
                        VALUES (1, 'admin', decode('C5693918686F8A45564F1FA5C27DBE1DF837CD0E6B25FA781F6EDCB699A8B27638B9902BA4D53AC6975F4B0F01455521F99BDDF72B3ABA9D6263846A9F388ED74B5764AD08391EEEBFF1AAD04E32645C47EBE2B99EF9807523EA71405A37423919FD34D296F8C886125C8808A6FF43442E1323BFD97CBBC214B4D00CA240E971','hex'),decode('9BEFB69EDA88B1EA5ECB76C11ED5E7DFC898CD24BD69CF223129EF2BB924C9B829C5478C09C69CE5418829123BD41E90999B7705A9A602FD5EF266F552AB94CE','hex'), '2003-01-05')
                    """;

        DatabaseConnection.Execute(query);
    }
    
    public override void Down()
    {
        var query = @"";
        
        DatabaseConnection.Execute(query);
    }
}