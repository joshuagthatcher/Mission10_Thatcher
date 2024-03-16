namespace MissionTen_Thatcher.Data;
using Microsoft.EntityFrameworkCore;

public interface IBowlerRepository
{
    IEnumerable<Bowlers> Bowlers { get; }
    IEnumerable<Team> Teams { get; }
}