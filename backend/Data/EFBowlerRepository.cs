namespace MissionTen_Thatcher.Data;
using Microsoft.EntityFrameworkCore;

public class EFBowlerRepository : IBowlerRepository
{
    private BowlerContext _bowlerContext;
    public EFBowlerRepository(BowlerContext temp)
    {
        _bowlerContext = temp;
    }
    public IEnumerable<Bowlers> Bowlers => _bowlerContext.Bowlers
        .Include(t => t.Team);

    public IEnumerable<Team> Teams => _bowlerContext.Teams;
}