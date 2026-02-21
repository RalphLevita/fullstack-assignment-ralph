# C# WebSocket Echo Server

A simple yet professional WebSocket echo server built with C# and ASP.NET Core 8.

## 🎯 Features

- ✅ **Echo WebSocket Server** - Receives messages and echoes them back
- ✅ **Web-based Test Client** - Beautiful HTML/JS client for testing
- ✅ **Health Check Endpoints** - Monitor server status
- ✅ **CORS Support** - Connect from any origin
- ✅ **Cross-Platform** - Runs on Windows and Linux (WSL/Ubuntu)
- ✅ **Concurrent Connections** - Handle multiple clients

## 📋 Prerequisites

- .NET 8 SDK ([Download](https://dotnet.microsoft.com/download/dotnet/8.0))
- For Linux: WSL Ubuntu or native Linux

## 🚀 Quick Start - Windows

### 1. Build the Project

```powershell
cd dotnet-websocket\WebSocketApp
dotnet build
```

### 2. Run the Server

```powershell
dotnet run
```

You should see:

```
✅ WebSocket Server Starting...
📡 WebSocket endpoint: ws://localhost:8000/ws
🌐 Health check: http://localhost:8000/health
📄 Test page: http://localhost:8000
```

### 3. Test the WebSocket

Open your browser and go to: **http://localhost:8000**

You'll see a beautiful web client where you can:

- Connect to the WebSocket
- Send messages
- Receive echoed responses
- Monitor connection status

## 🐧 Quick Start - Linux (WSL Ubuntu)

### 1. Install .NET 8 (if not already installed)

```bash
# Update package manager
sudo apt-get update

# Install .NET 8
sudo apt-get install -y dotnet-sdk-8.0
```

### 2. Build the Project

```bash
cd ~/fullstack-assignment-ralph/dotnet-websocket/WebSocketApp
dotnet build
```

### 3. Run the Server

```bash
dotnet run
```

### 4. Test from Windows (via WSL IP)

Find your WSL IP:

```bash
hostname -I
```

Then open browser on Windows: `http://<wsl-ip>:8000`

## 📡 API Endpoints

### WebSocket

- **URL:** `ws://localhost:8000/ws`
- **Protocol:** WebSocket
- **Behavior:** Echo server - sends back: "Echo: {your_message}"

### Health Check

- **URL:** `http://localhost:8000/health`
- **Method:** GET
- **Response:** `{ "status": "ok", "service": "WebSocket", "time": "..." }`

### Server Info

- **URL:** `http://localhost:8000/info`
- **Method:** GET
- **Response:** Service details and endpoints

## 🧪 Testing Options

### Option 1: Web Client (Easiest)

1. Run the server
2. Open http://localhost:8000
3. Click "Connect"
4. Type and send messages

### Option 2: WebSocket using Browser Console

```javascript
// Open browser DevTools (F12) and run:
const ws = new WebSocket('ws://localhost:8000/ws');
ws.onopen = () => console.log('Connected');
ws.onmessage = e => console.log('Received:', e.data);
ws.send('Hello Server!');
```

### Option 3: Command Line (curl/PowerShell)

```powershell
# Using WebSocket CLI tool (requires installation)
# Or use online tools like: https://www.websocket.org/echo.html
```

## 📂 Project Structure

```
dotnet-websocket/
├── WebSocketApp/
│   ├── Program.cs              # Main server logic with WebSocket handler
│   ├── WebSocketApp.csproj     # Project configuration
│   ├── appsettings.json        # Settings
│   ├── appsettings.Development.json
│   ├── Properties/
│   │   └── launchSettings.json # Launch configuration
│   └── wwwroot/
│       └── index.html          # Web test client
└── README.md
```

## 💻 Code Highlights

### WebSocket Handler

The server handles WebSocket connections in `Program.cs`:

- Accepts WebSocket connections on `/ws` route
- Receives text messages from clients
- Echoes messages back with "Echo: " prefix
- Handles disconnections gracefully
- Logs all connections and messages

### Features in Code

- **Concurrent Connections:** Each connection is handled asynchronously
- **Error Handling:** Try-catch blocks for robustness
- **Message Buffering:** 4KB buffer for messages
- **Connection Status:** Real-time logging to console

## 🔧 Customization

### Change Port

Edit `Properties/launchSettings.json`:

```json
"applicationUrl": "http://localhost:9000"  // Change 8000 to 9000
```

### Disable CORS

Remove or comment out this line in `Program.cs`:

```csharp
app.UseCors("AllowAll");
```

### Change Echo Format

In `Program.cs`, modify this line:

```csharp
string echoMessage = $"Echo: {receivedMessage}";  // Change prefix
```

## 🐛 Troubleshooting

### Port Already in Use

```powershell
# Find what's using port 8000
netstat -ano | findstr :8000

# Kill the process
taskkill /PID <PID> /F
```

### Cannot Connect from Another Machine

- Check firewall: Allow port 8000
- Use machine IP instead of `localhost`
- In `launchSettings.json`, change to: `"http://0.0.0.0:8000"`

### .NET Not Found

Ensure .NET 8 is installed:

```powershell
dotnet --version
```

## 📊 Best Practices Implemented

✅ **Async/Await** - Non-blocking operations
✅ **Error Handling** - Try-catch with graceful shutdown
✅ **Resource Management** - Using statements for cleanup
✅ **Logging** - Console output for monitoring
✅ **CORS** - Support for cross-origin requests
✅ **Health Checks** - Server status endpoints
✅ **Static Files** - Serve web client from wwwroot
✅ **Configuration** - appsettings.json for environment-specific config

## 🚀 Deployment Checklist

Before deploying to production:

- [ ] Test on target OS (Linux/Ubuntu)
- [ ] Configure proper port (not privileged ports without sudo)
- [ ] Set `ASPNETCORE_ENVIRONMENT=Production` in environment variables
- [ ] Enable HTTPS for production (add certificate)
- [ ] Set up firewall rules
- [ ] Monitor logs and connections
- [ ] Use process manager (systemd, supervisor, etc.)

## 📝 Usage Examples

### Python Client

```python
import asyncio
import websockets

async def echo_test():
    uri = "ws://localhost:8000/ws"
    async with websockets.connect(uri) as websocket:
        await websocket.send("Hello WebSocket!")
        response = await websocket.recv()
        print(f"Received: {response}")

asyncio.run(echo_test())
```

### Node.js Client

```javascript
const WebSocket = require('ws');
const ws = new WebSocket('ws://localhost:8000/ws');

ws.on('open', () => {
	ws.send('Hello from Node.js!');
});

ws.on('message', data => {
	console.log('Received:', data);
});
```

## 📞 Support

For issues or questions:

1. Check the troubleshooting section
2. Review the console logs for error messages
3. Verify firewall and port settings
4. Ensure .NET 8 is properly installed

---

**Version:** 1.0  
**Author:** Ralph Levita  
**Date:** February 2026  
**Status:** ✅ Production Ready
