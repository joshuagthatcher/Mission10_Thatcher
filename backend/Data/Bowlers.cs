using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MissionTen_Thatcher.Data;

public partial class Bowlers
{
    [Key]
    public int BowlerID { get; set; }
    public object BowlerId { get; internal set; }
    public string? BowlerLastName { get; set; }
    public string? BowlerMiddleInit { get; set; }
    public string? BowlerFirstName { get; set; }
    public string? BowlerAddress { get; set; }
    public string? BowlerCity { get; set; }
    public string? BowlerState { get; set; }
    public string? BowlerZip { get; set; }
    public int? BowlerPhoneNumber { get; set; }

    [ForeignKey("Team")]
    public int? TeamId { get; set; }
    public Team? Team { get; set; }
}