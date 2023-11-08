using System.ComponentModel.DataAnnotations.Schema;
using FreddyBot.Data.Tables.Interfaces;
using FreddyBot.Data.Tables.KeyBases;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreddyBot.Data.Tables;

[Table(TableName)]
[PrimaryKey(ColumnNames.GuildID)]
public class SwearJar : GuildKeyed, IDBTable
{
    public const string TableName = "SwearJars";
    static string IDBTable.TableName => TableName;

    public new class ColumnNames : GuildKeyed.ColumnNames
    {
        public new const string GuildID = GuildKeyed.ColumnNames.GuildID;
        public const string ValueOfSingleSwear = "ValueOfSingleSwear";
        public const string SwearCount = "SwearCount";
    }

    [Column(ColumnNames.ValueOfSingleSwear, TypeName = "REAL")]
    public decimal ValueOfSingleSwear { get; set; } = 0.25m;

    [Column(ColumnNames.SwearCount)]
    public int SwearCount { get; set; } = 1;

    [NotMapped]
    public decimal CurrentJarValue => ValueOfSingleSwear * SwearCount;
}