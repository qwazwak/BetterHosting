using System.ComponentModel.DataAnnotations.Schema;
using FreddyBot.Data.Tables.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreddyBot.Data.Tables;

[Table(TableName)]
[PrimaryKey(ColumnNames.ID)]
public class BadPassword : IDBTable
{
    public const string TableName = "BadPasswords";
    static string IDBTable.TableName => TableName;

    public static class ColumnNames
    {
        public const string ID = "ID";
        public const string Password = "Password";
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(ColumnNames.ID)]
    public int ID { get; set; } = 1;

    [Column(ColumnNames.Password)]
    public string Password { get; set; } = default!;

    public BadPassword Copy() => new()
    {
        Password = Password,
    };
}