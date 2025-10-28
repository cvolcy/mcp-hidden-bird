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

## C# Server Project

This repository also includes a C# project that implements another Model Context Protocol (MCP) server. This C# server demonstrates how to create an MCP server in C# and exposes a simple "say_hello" tool, similar to its Rust counterpart.

### Project Structure (C# Server)

```
.
├── ...existing Rust project files...
├── csharp/
│   ├── mcp-hidden-bird.csproj
│   └── Program.cs
└── ...
```

### Setup (C# Server)

1.  **Navigate to the C# server directory:**

    ```bash
    cd csharp
    ```

2.  **Restore dependencies:**

    ```bash
    dotnet restore
    ```

3.  **Build the project:**

    ```bash
    dotnet build
    ```

### Running the C# Server

To run the C# MCP **web** server, you need to configure your VS Code `mcp.json` file. Ensure your C# server application is configured to listen on the specified port (e.g., 5000).

Here's an updated example `mcp.json` configuration including both servers:

```json
{
    "servers": {
        "my-rust-mcp-server": {
            "type": "stdio",
            "command": "<Path to mcp-hidden-bird>",
            "args": []
        },
        "my-csharp-mcp-server": {
			"url": "https://localhost:7054/mcp",
			"type": "http"
        }
    },
    "inputs": []
}
```

Once configured, you can start the C# server through the MCP extension in VS Code.

### Testing the `say_hello` Tool (C# Server)

After the C# MCP server is running, you can test its `say_hello` tool using the MCP extension in VS Code. You can invoke the tool directly through the extension's interface or by using the `mcp_my-csharp-mcp-server_say_hello` command if available in your environment.

The tool should return: `Hello from hidden bird MCP server!`
