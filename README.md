# MCP Hidden Bird

This is a proof-of-concept (POC) Model Context Protocol (MCP) server implemented in Rust. It exposes a simple "say_hello" tool that returns a greeting string.

## Project Structure

```
. 
├── Cargo.lock
├── Cargo.toml
├── src/
│   ├── main.rs
│   └── service_servers/
│       ├── mod.rs
│       └── say_hello.rs
└── target/
    └── ...
```

## Setup

1.  **Clone the repository:**

    ```bash
    git clone <repository-url>
    cd mcp-hidden-bird
    ```

2.  **Build the project:**

    ```bash
    cargo build
    ```

## Running the MCP Server

To run the MCP server, you need to configure your VS Code `mcp.json` file.

Here's an example `mcp.json` configuration:

```json
{
    "servers": {
        "my-mcp-server": {
            "type": "stdio",
            "command": "<Path to mcp-hidden-bird>",
            "args": []
        }
    },
    "inputs": []
}
```

Replace `<Path to mcp-hidden-bird>` with the actual absolute path to your compiled executable within your WSL environment.

Once configured, you can start the server through the MCP extension in VS Code.

## Testing the `say_hello` Tool

After the MCP server is running, you can test the `say_hello` tool using the MCP extension in VS Code. You can invoke the tool directly through the extension's interface or by using the `mcp_my-mcp-server_say_hello` command if available in your environment.

The tool should return: `Hello from MCP server!`
