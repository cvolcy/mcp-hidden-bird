use anyhow::Result;
use rmcp::{
    handler::server::{router::tool::ToolRouter, ServerHandler},
    model::{CallToolResult, Content, ServerCapabilities, ServerInfo},
    tool,
    tool_handler,
    tool_router,
    ServiceExt,
    transport::stdio,
};

#[derive(Clone)]
pub struct SayHelloServiceServer {
    tool_router: ToolRouter<Self>,
}

#[tool_router]
impl SayHelloServiceServer {
    pub fn new() -> Self {
        Self {
            tool_router: Self::tool_router(),
        }
    }

    #[tool(description = "Say hello and return a simple string")]
    async fn say_hello(&self) -> Result<CallToolResult, rmcp::ErrorData> {
        Ok(CallToolResult::success(vec![Content::text(
            "Hello from MCP server!".to_string(),
        )]))
    }
}

#[tool_handler]
impl ServerHandler for SayHelloServiceServer {
    fn get_info(&self) -> ServerInfo {
        ServerInfo {
            instructions: Some("A simple service that says hello.".into()),
            capabilities: ServerCapabilities::builder().enable_tools().build(),
            ..Default::default()
        }
    }
}

#[tokio::main]
async fn main() -> Result<()> {
    println!("Starting MCP SayHelloServiceServer...");
    let service = SayHelloServiceServer::new().serve(stdio()).await.inspect_err(|e| {
        eprintln!("Error starting server: {}", e);
    })
    .inspect(|_| {
        println!("MCP SayHelloServiceServer is running. Press Ctrl+C to shut down.");
    })?;

    service.waiting().await?;
    
    Ok(())
}
