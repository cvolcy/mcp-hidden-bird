mod service_servers;

use anyhow::Result;
use rmcp::{ServiceExt, transport::stdio};
use crate::service_servers::say_hello::SayHelloServiceServer;

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
