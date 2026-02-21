# Fullstack Assignment - Ralph Levita

## Overview

This project implements a full-stack web application with:

- Vue.js frontend application
- Express.js backend API
- JWT authentication (Access + Refresh tokens)
- OTP verification
- SQLite database for persistence

---

## Project Structure

```
fullstack-assignment-ralph/
├── express-backend/           # Express API server
├── vue-frontend/              # Vue.js frontend app
├── dotnet-rest-api/           # C# REST API (.NET 8)
│   └── RestApi/
├── dotnet-websocket/          # C# WebSocket Echo Server (.NET 8)
│   └── WebSocketApp/
└── README.md
```

---

## How to Run

> **Note:** Run all commands inside WSL/Ubuntu terminal.

### Backend

```bash
cd ~/fullstack-assignment-ralph/express-backend
npm install
NODE_ENV=development npm run app
```

- **Server:** http://127.0.0.1:3000
- **Healthcheck:** http://127.0.0.1:3000/api/healthcheck

### Frontend

```bash
cd ~/fullstack-assignment-ralph/vue-frontend/apps
npm install
npm run sample
```

- **App:** http://127.0.0.1:8080

---

## Login Credentials

| Field    | Value  |
| -------- | ------ |
| Email    | test   |
| Password | test   |
| OTP      | 111111 |

---

## Features

- [x] User authentication with email/password
- [x] OTP verification step
- [x] JWT access and refresh token management
- [x] Protected dashboard route
- [x] Session persistence with SQLite

---

## Notes

- Switched refresh token storage from `keyv` to `knex` due to runtime issue.
- Created missing `user_session` table for SQLite persistence.

## .NET REST API

Location:
dotnet-rest-api/RestApi

Run (inside WSL Ubuntu):

```bash
cd ~/fullstack-assignment-ralph/dotnet-rest-api/RestApi
dotnet run --urls http://localhost:5275
```

Available endpoints:

- `GET /health`
- `GET /api/echo/{msg}`
- `POST /api/sum`

Swagger:
http://localhost:5275/swagger

---

## C# WebSocket Echo Server

Location:
dotnet-websocket/WebSocketApp

Features:

- Echo WebSocket server on port 8000
- Beautiful HTML/JS web client
- Health check and info endpoints
- CORS support
- Works on Windows & Linux

Run (Windows or WSL):

```bash
cd ~/fullstack-assignment-ralph/dotnet-websocket/WebSocketApp
dotnet build
dotnet run
```

Access the web client:
http://localhost:8000

WebSocket endpoint:
ws://localhost:8000/ws

Available endpoints:

- `GET /` - Web test client
- `GET /health` - Health check
- `GET /info` - Server info
- `WS /ws` - WebSocket echo endpoint

For detailed setup and documentation, see: `dotnet-websocket/README.md`
