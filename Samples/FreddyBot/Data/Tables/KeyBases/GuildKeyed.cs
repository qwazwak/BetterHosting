using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreddyBot.Data.Tables.KeyBases;

public abstract class GuildKeyed
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1102:Make class static.", Justification = "<Pending>")]
    public class ColumnNames
    {
        public const string GuildID = "GuildID";
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(ColumnNames.GuildID)]
    public ulong GuildID { get; set; }
}