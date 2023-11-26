using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FreddyBot.Data.Tables.KeyBases;

public abstract class GuildKeyed
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1102:Make class static.", Justification = "Allow for inheritance")]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Suppression is required")]
    public class ColumnNames
    {
        public const string GuildID = "GuildID";
    }

    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column(ColumnNames.GuildID)]
    public ulong GuildID { get; set; }
}