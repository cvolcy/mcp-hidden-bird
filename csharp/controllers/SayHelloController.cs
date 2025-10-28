
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using ModelContextProtocol.Server;

[ApiController]
[Route("[controller]")]
[McpServerToolType]
public class SayHelloController(ILogger<SayHelloController> logger) : Controller
{
    private readonly ILogger<SayHelloController> _logger = logger;

    [McpServerTool, Description("Say hello and return a simple string")]
    [HttpGet("Hi", Name = "Hi")]
    public string Hi()
    {
        _logger.LogInformation("Saying hello from MCP server");
        return $"Hello from hidden bird MCP server! {DateTime.UtcNow.ToString("o")}";
    }
}
