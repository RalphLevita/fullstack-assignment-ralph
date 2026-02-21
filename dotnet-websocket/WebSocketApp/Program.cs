using System.Net;
using System.Net.WebSockets;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Enable WebSocket support
app.UseWebSockets();

// Use CORS
app.UseCors("AllowAll");

// Serve index.html as default file (must be before UseStaticFiles)
var defaultFilesOptions = new DefaultFilesOptions();
defaultFilesOptions.DefaultFileNames.Clear();
defaultFilesOptions.DefaultFileNames.Add("index.html");
app.UseDefaultFiles(defaultFilesOptions);

// Enable static files to serve HTML test page
app.UseStaticFiles();

// WebSocket endpoint
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/ws")
    {
        if (context.WebSockets.IsWebSocketRequest)
        {
            using (WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync())
            {
                await HandleWebSocketConnection(webSocket);
            }
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
        }
    }
    else
    {
        await next(context);
    }
});

// Health check endpoint
app.MapGet("/health", () =>
    Results.Ok(new { status = "ok", service = "WebSocket", time = DateTime.UtcNow })
);

// Info endpoint
app.MapGet("/info", () =>
    Results.Ok(new 
    { 
        service = "C# Echo WebSocket Server",
        version = "1.0",
        websocketUrl = "ws://localhost:8000/ws",
        testPageUrl = "http://localhost:8000",
        timestamp = DateTime.UtcNow
    })
);

Console.WriteLine("✅ WebSocket Server Starting...");
Console.WriteLine("📡 WebSocket endpoint: ws://localhost:8000/ws");
Console.WriteLine("🌐 Health check: http://localhost:8000/health");
Console.WriteLine("📄 Test page: http://localhost:8000");

app.Run("http://localhost:8000");

// WebSocket connection handler
async Task HandleWebSocketConnection(WebSocket webSocket)
{
    Console.WriteLine($"✅ Client connected. Total connections: 1");
    
    byte[] buffer = new byte[1024 * 4];
    
    try
    {
        while (webSocket.State == WebSocketState.Open)
        {
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(
                new ArraySegment<byte>(buffer), CancellationToken.None);

            if (result.MessageType == WebSocketMessageType.Text)
            {
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count);
                Console.WriteLine($"📨 Received: {receivedMessage}");

                // Echo the message back to the client
                string echoMessage = $"Echo: {receivedMessage}";
                byte[] responseBuffer = Encoding.UTF8.GetBytes(echoMessage);

                await webSocket.SendAsync(
                    new ArraySegment<byte>(responseBuffer, 0, responseBuffer.Length),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);

                Console.WriteLine($"📤 Sent: {echoMessage}");
            }
            else if (result.MessageType == WebSocketMessageType.Close)
            {
                await webSocket.CloseAsync(
                    WebSocketCloseStatus.NormalClosure,
                    "Closing",
                    CancellationToken.None);
                Console.WriteLine("❌ Client disconnected");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"❌ Error: {ex.Message}");
    }
    finally
    {
        webSocket.Dispose();
    }
}
