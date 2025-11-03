
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using ModelContextProtocol.Server;

[ApiController]
[Route("[controller]")]
[McpServerToolType]
public class SayHelloController(ILogger<SayHelloController> logger) : Controller
{
    private readonly ILogger<SayHelloController> _logger = logger;

    [McpServerTool(Name = "SayHello"), Description("Say hello and return a simple string")]
    [HttpGet("Hi")]
    public string SayHello()
    {
        _logger.LogInformation("Saying hello from MCP server");
        return $"Hello from hidden bird MCP server! {DateTime.UtcNow.ToString("o")}";
    }

    [McpServerTool(Name = "SayGoodbye"), Description("Say goodbye and return a simple string")]
    [HttpGet("Bye")]
    public string SayGoodbye()
    {
        _logger.LogInformation("Saying goodbye from MCP server");
        return $"Ciao from hidden bird MCP server! {DateTime.UtcNow.ToString("o")}";
    }
}
