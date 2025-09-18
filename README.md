# Automated Learning System

A comprehensive learning management platform built with **Clean Architecture** principles, featuring a .NET Minimal API backend and a modern React frontend. This system enables personalized learning path generation, progress tracking, and adaptive assessment for students and administrators.

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet)
![React](https://img.shields.io/badge/React-18.2-61DAFB?style=flat-square&logo=react)
![TypeScript](https://img.shields.io/badge/TypeScript-5.2-3178C6?style=flat-square&logo=typescript)
![CI/CD](https://img.shields.io/badge/CI%2FCD-GitHub%20Actions-2088FF?style=flat-square&logo=github-actions)

## 🏗️ Architecture

This project implements **Clean Architecture** with clear separation of concerns:

```
├── src/
│   ├── AutomatedLearningSystem.Domain/          # Enterprise Business Rules
│   ├── AutomatedLearningSystem.Application/     # Application Business Rules
│   ├── AutomatedLearningSystem.Infrastructure/  # External Interfaces
│   ├── AutomatedLearningSystem.Api/            # Web API (Minimal APIs)
│   ├── AutomatedLearningSystem.Contracts/      # DTOs and Request/Response Models
│   └── automatedlearningsystem.ui/             # React Frontend
└── tests/                                       # Comprehensive Test Suite
```

### Backend Architecture

- **Domain Layer**: Core business entities and rules (Users, Learning Paths, Learning Items)
- **Application Layer**: Use cases implemented with CQRS pattern using MediatR
- **Infrastructure Layer**: Data persistence with Entity Framework Core, external services
- **API Layer**: .NET Minimal APIs with clean endpoint organization
- **Contracts**: Data transfer objects for API communication

### Frontend Architecture

- **React 18** with TypeScript for type safety
- **React Router** for client-side routing with role-based access control
- **TanStack Query** for efficient server state management
- **Zustand** for lightweight client state management
- **Ant Design** for consistent UI components
- **Vite** for fast development and optimized builds

## ✨ Features

### For Students
- **Personalized Learning Paths**: AI-generated learning sequences based on skill assessments
- **Interactive Questionnaires**: Adaptive assessments to determine learning needs
- **Progress Tracking**: Real-time monitoring of learning item completion
- **Role-based Dashboard**: Student-specific interface with learning analytics

### For Administrators
- **User Management**: Full CRUD operations for student and admin accounts
- **Learning Content Management**: Create, edit, and organize learning materials
- **Analytics & Reporting**: Comprehensive learning path performance reports
- **System Configuration**: Platform settings and content moderation

### Core Capabilities
- **Authentication & Authorization**: Cookie-based auth with role-based access control
- **RESTful API**: Clean, documented endpoints following REST principles
- **Real-time Updates**: Efficient data synchronization between frontend and backend
- **Responsive Design**: Mobile-first approach with cross-device compatibility

## 🚀 Getting Started

### Prerequisites

- **.NET 8.0 SDK** or later
- **Node.js 18+** and npm
- **SQL Server** (LocalDB for development)
- **Visual Studio** or **VS Code** (recommended)

### Backend Setup

1. **Clone the repository**
   ```bash
   git clone https://github.com/yourusername/automated-learning-system.git
   cd automated-learning-system
   ```

2. **Configure the database**
   ```bash
   # Update connection string in appsettings.Development.json
   cd src/AutomatedLearningSystem.Api
   dotnet ef database update
   ```

3. **Run the API**
   ```bash
   dotnet run
   # API will be available at https://localhost:7000
   ```

### Frontend Setup

1. **Install dependencies**
   ```bash
   cd src/automatedlearningsystem.ui
   npm install
   ```

2. **Start development server**
   ```bash
   npm run dev
   # Frontend will be available at http://localhost:5173
   ```

### Running Tests

```bash
# Backend tests
dotnet test

# Frontend tests
cd src/automatedlearningsystem.ui
npm test
```

## 🛠️ Technology Stack

### Backend
- **.NET 8** - Modern, cross-platform framework
- **Minimal APIs** - Lightweight, fast HTTP APIs
- **Entity Framework Core** - Object-relational mapping
- **MediatR** - CQRS and mediator pattern implementation
- **FluentValidation** - Input validation
- **AutoMapper** - Object-to-object mapping
- **xUnit** - Unit and integration testing

### Frontend
- **React 18** - Component-based UI library
- **TypeScript** - Static type checking
- **TanStack Query** - Server state management
- **React Router** - Client-side routing
- **Ant Design** - UI component library
- **Axios** - HTTP client
- **Vite** - Build tool and dev server
- **Vitest** - Unit testing framework

### DevOps & Tools
- **GitHub Actions** - CI/CD pipelines
- **Docker** - Containerization support
- **ESLint** - Code linting
- **Prettier** - Code formatting

## 📡 API Endpoints

### Authentication
- `POST /auth/login` - User authentication
- `POST /auth/logout` - User logout
- `POST /auth/register` - User registration

### Users Management
- `GET /api/users` - List all users (Admin)
- `GET /api/users/{id}` - Get user by ID
- `POST /api/users` - Create new user (Admin)
- `PUT /api/users/{id}` - Update user (Admin)
- `DELETE /api/users/{id}` - Delete user (Admin)

### Learning Paths
- `GET /api/users/{userId}/learning-paths` - Get user's learning paths
- `POST /api/users/{userId}/learning-paths` - Generate new learning path
- `GET /api/learning-paths` - Get all learning paths (Admin)

### Learning Items
- `GET /api/learning-items` - List learning materials
- `POST /api/learning-items` - Create learning item (Admin)
- `DELETE /api/learning-items/{id}` - Delete learning item (Admin)

### Assessments
- `GET /api/questions` - Get assessment questions
- `PUT /api/user-learning-items/{id}` - Mark learning item as complete

## 🧪 Comprehensive Testing Strategy

This project implements a **robust, multi-layered testing approach** with **72+ test files** covering all aspects of the application:

### Test Architecture
- **Unit Tests** (`Domain.UnitTests`, `Application.UnitTests`): Core business logic testing
- **Integration Tests**: Database operations and repository patterns
- **Functional Tests**: End-to-end API workflows with real HTTP calls
- **Frontend Tests**: React component testing with React Testing Library

### Advanced Testing Features

#### 🏭 **Test Data Factories**
Professional test data generation with reusable factories:
- `UserCommandsFactory` - User creation and management scenarios
- `LearningPathFactory` - Learning path generation testing
- `LearningItemFactory` - Learning content creation
- `QuestionFactory` - Assessment and questionnaire data
- `UserProficiencyProfileFactory` - User skill profile testing

#### 🎭 **Authentication Mocking System**
Sophisticated authentication testing infrastructure:
- **MockAuthHandler** - Custom authentication handler for testing
- **MockedClaims** - Configurable user claims for role-based testing
- **ClaimConstants** - Predefined role and identity claims
- **Cookie-based Auth Testing** - Real authentication flow simulation

#### 🏗️ **Test Infrastructure**
- **FunctionalTestWebApplicationFactory** - Isolated test environments
- **IntegrationTestWebApplicationFactory** - Database integration testing
- **BaseFunctionalTest** - Shared test utilities and setup
- **SQLite In-Memory Database** - Fast, isolated test databases

### Testing Highlights

```csharp
// Example: Professional test data factory usage
var createUserCommand = UserCommandsFactory.CreateUserCommandFactory
    .Create(role: Role.Admin, email: "admin@test.com");

// Example: Authentication mocking for role-based testing
var adminClaims = new List<Claim>
{
    ClaimConstants.AdminRole,
    ClaimConstants.Id(userId)
};
var client = factory.WithMockedClaims(adminClaims);
```

### Test Coverage Areas
- **Domain Logic**: Business rules and entity behavior
- **CQRS Commands/Queries**: Application use cases
- **API Endpoints**: HTTP request/response validation
- **Authentication & Authorization**: Role-based access control
- **Database Operations**: Entity Framework integration
- **Error Handling**: Exception scenarios and edge cases

## 🚦 CI/CD Pipeline

Automated workflows with GitHub Actions:

- **Build**: Compile and validate both frontend and backend
- **Test**: Run comprehensive test suites
- **Code Quality**: ESLint, TypeScript checks, and .NET analyzers
- **Security**: Dependency vulnerability scanning

## 🎯 Project Highlights

### Clean Architecture Benefits
- **Testability**: Easy unit testing with clear dependencies
- **Maintainability**: Separation of concerns reduces coupling
- **Flexibility**: Easy to swap implementations (database, UI framework)
- **Scalability**: Clear boundaries for horizontal scaling

### Modern Development Practices
- **Type Safety**: Full TypeScript implementation
- **SOLID Principles**: Well-structured, maintainable code
- **DRY Principle**: Reusable components and services
- **Security First**: Authentication, authorization, and input validation

### Performance Optimizations
- **Efficient Queries**: Optimized Entity Framework queries
- **Client-side Caching**: TanStack Query for intelligent data caching
- **Bundle Optimization**: Tree-shaking and code splitting
- **Lazy Loading**: Route-based code splitting

## 📈 Future Enhancements

- Real-time notifications with SignalR
- Advanced analytics dashboard
- Machine learning-powered content recommendations
- Mobile application (React Native)
- Multi-tenant support
- Advanced accessibility features

## 🤝 Contributing

This project demonstrates modern software development practices including Clean Architecture, CQRS, and full-stack development with .NET and React. It showcases:

- Professional-grade code organization
- Comprehensive testing strategies
- Modern development tools and practices
- Scalable architecture patterns
- Security best practices

---

**Built with ❤️ using Clean Architecture principles**