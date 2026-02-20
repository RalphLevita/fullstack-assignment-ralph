# Fullstack Assignment - Ralph Levita

## Overview

This project implements a full-stack web application with:

- Vue.js frontend application
- Express.js backend API
- JWT authentication (Access + Refresh tokens)
- OTP verification
- SQLite database for persistence

---

## Tech Stack

| Layer    | Technologies                          |
|----------|---------------------------------------|
| Frontend | Vue 3, Vite                           |
| Backend  | Node.js, Express, Knex, SQLite        |
| Auth     | JWT (Access + Refresh), OTP           |

---

## Project Structure

```
fullstack-assignment-ralph/
├── express-backend/       # Express API server
├── vue-frontend/          # Vue.js frontend app
├── dotnet-rest-api/RestApi
├── dotnet-socket
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

| Field    | Value    |
|----------|----------|
| Email    | test     |
| Password | test     |
| OTP      | 111111   |

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

cd ~/fullstack-assignment-ralph/dotnet-rest-api/RestApi
dotnet run --urls http://localhost:5275

Available endpoints:

GET    /health
GET    /api/echo/{msg}
POST   /api/sum

Swagger:
http://localhost:5275/swagger
