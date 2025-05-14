using AutoMapper;
using BoardgameApi.Model;
using BoardgameApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace BoardgameApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchController : ControllerBase
{
    private readonly ILogger<MatchController> _logger;
    private readonly IMatchService _matchService;
    private readonly IMapper _mapper;

    public MatchController(
        ILogger<MatchController> logger,
        IMatchService matchService,
        IMapper mapper)
    {
        _logger = logger;
        _matchService = matchService;
        _mapper = mapper; 
    }

    // GET: Match/id
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
        var result = _matchService.GetMatch(id);

        return result == null ? new NotFoundResult() : new OkObjectResult(result);
    }

    // GET: Match?playername=
    [HttpGet]
    public IActionResult GetAll(string playerName)
    {
        var result = _matchService.GetMatches(playerName);

        return new OkObjectResult(result);
    }

    // POST: Match
    [HttpPost]
    public ActionResult Create(NewMatchRequest createMatchRequest)
    {
        var match = _mapper.Map<Match>(createMatchRequest);
            
        var result = _matchService.Create(match);
        
        return new CreatedResult("match", result);
    }

    // PATCH: Match/id
    [HttpPatch("{id}")]
    public ActionResult Edit([FromRoute] Guid id, NewMatchRequest createMatchRequest)
    {
        var match = _mapper.Map<Match>(createMatchRequest);

        var result = _matchService.UpdateMatch(id, match);
        return result ? new OkResult() : new NotFoundResult();
    }

    // DELETE: Match/id
    [HttpDelete]
    public ActionResult Delete(Guid id)
    {
        var result = _matchService.DeleteMatch(id);
        return result ? new OkResult() : new NotFoundResult();
    }
}
