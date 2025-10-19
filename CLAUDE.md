# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

AspNetReactReduxTodo is a full-stack todo list application demonstrating modern web development patterns with ASP.NET Core backend and React/Redux frontend.

## Development Commands

### Backend (from repository root)

```powershell
# Start SQL LocalDB (required before running backend)
sqllocaldb start

# Apply database migrations
dotnet ef database update --project ReactReduxTodo

# Run backend server
dotnet run

# Backend available at:
# - API: http://localhost:5000/api/[actionName]
# - Swagger UI: http://localhost:5000/swagger
```

### Frontend (from ClientApp directory)

```powershell
# Install dependencies
npm install

# Start development server (Vite)
npm start
# or
npm run dev

# Frontend available at: http://localhost:3000/

# Production build
npm build

# Linting
npm run lint        # Check for issues
npm run lint:fix    # Auto-fix issues
```

### Testing

**Backend Integration Tests:**
```powershell
# Run integration tests with code coverage (uses Testcontainers)
dotnet test ReactReduxTodo.sln -s .runsettings --configuration Release
```
Note: Backend tests require Docker to be running as they use Testcontainers to spin up real MS SQL Server instances.

**Frontend Tests:**
```powershell
# From ClientApp directory
npm test
```

## Architecture

### Backend Structure

The backend follows a layered architecture with clear separation of concerns:

- **Controllers/** - API endpoints (e.g., TasksController.cs)
- **Services/** - Business logic layer (TodoTasksService.cs abstracts data access)
- **Data/** - EF Core DbContext (ApplicationDbContext.cs)
- **Entities/** - Domain models (TodoTask.cs)
- **Dto/** - Data transfer objects for API contracts
- **Extensions/** - Includes global exception handler middleware

**Key Patterns:**
- Repository/Service pattern for data access
- Dependency Injection (configured in Program.cs/Startup.cs)
- Entity Framework Code-First approach
- RESTful API design

**Main API Endpoints:**
- `GET /api/tasks` - List all tasks
- `GET /api/tasks/{id}` - Get single task
- `POST /api/tasks` - Create new task
- `DELETE /api/tasks/{id}` - Delete task

### Frontend Structure

The frontend uses a feature-based architecture with Redux for state management:

- **src/components/** - Reusable UI components (TaskList, Task, NavMenu, DashboardLayout)
- **src/features/taskList/** - Redux feature module with complete Redux setup:
  - `actions.js` - Action creators
  - `actionTypes.js` - Action type constants
  - `reducer.js` - Redux reducer
  - `sagas.js` - Redux-Saga for async operations (API calls)
  - `selectors.js` - State selectors
  - `__tests__/` - Feature-specific tests
- **src/store/** - Redux store configuration
- **src/services/** - API service layer for backend communication

**Key Patterns:**
- Redux for centralized state management
- Redux-Saga for side effects and async operations (API calls, error handling)
- Feature-based folder structure (each feature is self-contained)
- Component composition pattern

**API Integration:**
- Vite dev server proxies `/api` requests to backend (`http://localhost:5000`)
- Configuration in `vite.config.js` and `package.json`

### Testing Architecture

**Backend:**
- Integration tests use Testcontainers to spin up real MS SQL Server containers
- Respawn library handles database cleanup between tests
- Code coverage configured via `.runsettings`
- Tests located in `ReactReduxTodo.Tests.Integration/`

**Frontend:**
- Vitest with jsdom environment for component testing
- @testing-library/react for component testing utilities
- redux-saga-test-plan for testing sagas
- Test setup in `ClientApp/tests/setup.js`

## Technology Stack

**Backend:**
- ASP.NET Core Web API (.NET 8.0)
- Entity Framework Core 8.0.11
- Microsoft SQL Server (LocalDB for development)
- ASP.NET Core Identity (authentication/authorization)
- Swashbuckle (Swagger/OpenAPI documentation)

**Frontend:**
- React 19.0.0
- React-Redux 9.2.0 + Redux-Saga 1.3.0
- Redux Toolkit (@reduxjs/toolkit 2.6.1)
- Bootstrap 5.3.3 + React-Bootstrap 2.10.9
- React Router v7.5.2
- Vite 6.3.6 with SWC plugin
- Vitest 3.0.8 + @testing-library/react

## Important Notes

- The frontend and backend must be run separately in development
- Backend requires SQL LocalDB to be started before running
- Frontend proxies API requests to `http://localhost:5000` during development
- Integration tests require Docker to be running (Testcontainers dependency)
- CI/CD pipeline runs both backend and frontend tests via GitHub Actions
