using Microsoft.AspNetCore.Mvc;
using MissionTen_Thatcher.Data;

namespace MissionTen_Thatcher.Controllers

{
    [Route("[controller]")]
    [ApiController]
    public class BowlingLeagueController : ControllerBase
    {
        private IBowlerRepository _bowlerRepository;
        public BowlingLeagueController(IBowlerRepository temp)
        {
            _bowlerRepository = temp;
        }

        [HttpGet]
        public IEnumerable<object> Get()
        {
            var bowlerData = from Bowlers in _bowlerRepository.Bowlers
                             join Teams in _bowlerRepository.Teams
                             on Bowlers.TeamId equals Teams.TeamId
                             where Teams.TeamName == "Marlins" || Teams.TeamName == "Sharks"
                             select new
                             {
                                 BowlerId = Bowlers.BowlerId,
                                 BowlerLastName = Bowlers.BowlerLastName,
                                 BowlerFirstName = Bowlers.BowlerFirstName,
                                 BowlerMiddleInit = Bowlers.BowlerMiddleInit,
                                 BowlerAddress = Bowlers.BowlerAddress,
                                 BowlerCity = Bowlers.BowlerCity,
                                 BowlerState = Bowlers.BowlerState,
                                 BowlerZip = Bowlers.BowlerZip,
                                 BowlerPhoneNumber = Bowlers.BowlerPhoneNumber,
                                 TeamName = Teams.TeamName
                             };

            return bowlerData.ToList();
        }
    }
}