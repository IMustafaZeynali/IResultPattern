# 🚀 IResultPattern

A lightweight and expressive result-handling package for .NET applications.

**✨ Clean. Explicit. Production-ready.**

Stop returning raw exceptions for expected outcomes.  
Stop mixing business logic with HTTP responses.  
Start modeling results explicitly.

[![NuGet](https://img.shields.io/nuget/v/IResultPattern.svg)](https://www.nuget.org/packages/IResultPattern)
[![License](https://img.shields.io/badge/license-Apache%202.0-blue.svg)](LICENSE)

---

## 🎯 What is this package?

**IResultPattern** is a dependency-free result modeling library for .NET. It gives you a consistent, strongly-typed way to represent operation outcomes across application layers.

Instead of throwing exceptions for flow control or returning loosely structured responses, you return explicit, predictable results.

### ✅ Perfect for

- ASP.NET Core Web APIs
- Clean Architecture
- Domain-Driven Design (DDD)
- Microservices
- Event-driven systems
- Modular monoliths

---

## 📦 Install

```bash
dotnet add package IResultPattern
```

```csharp
using IMustafaZeynali.IResultPattern;
```

---

## ✨ Key features

### 🔹 Explicit status modeling

Statuses are aligned with HTTP semantics:

| Status | Code |
|--------|------|
| Success | 200 |
| Created | 201 |
| NoContent | 204 |
| BadRequest | 400 |
| Unauthorized | 401 |
| Forbidden | 403 |
| NotFound | 404 |
| Conflict | 409 |
| ValidationError | 422 |
| InternalServerError | 500 |
| ServiceUnavailable | 503 |

### 🔹 Strongly-typed results

```csharp
Result              // no payload
Result<TData>       // single item
ResultList<TData>   // collection + pagination
```

`TData` must be a reference type (`class`).

### 🔹 Built-in pagination

`ResultList<T>` implements `IPageInfo` with:

- `TotalItemCount`
- `PageCount`
- `PageNumber`
- `PageSize`

### 🔹 Clean Architecture friendly

- Separates business outcomes from transport concerns
- Improves readability and testability
- Reduces exception misuse
- Provides a consistent response contract

### 🔹 Lightweight & dependency-free

- No external dependencies
- Targets `netstandard2.1`
- Explicit factory methods — no hidden magic

### 🔹 Backward compatible

The legacy `Failure(string)` overloads remain available and are marked `[Obsolete]`. Prefer specific status methods instead.

---

## 🧠 Why use this instead of exceptions?

Exceptions should represent exceptional conditions — not validation failures or other predictable outcomes.

This package encourages:

- Explicit business outcomes
- Better error handling
- Consistent API behavior
- Easier testing
- Clearer code semantics

---

## 🔥 Examples

### 📄 Without data

```csharp
return Result.Success();

return Result.NotFound("User not found");

return Result.ValidationError("Email is required");
```

### 📌 Single item

```csharp
return Result<User>.Success(user);

return Result<User>.NotFound("User not found");

return Result<User>.ValidationError("Email is required");
```

### 📚 List with pagination

```csharp
return ResultList<User>.Success(users, totalItemCount: 120);

return ResultList<User>.Success(users, pageInfo);

return ResultList<User>.NotFound("No users found");

return ResultList<User>.ValidationError("Invalid page size");
```

### ⚡ Implicit conversions

```csharp
Result result = ResultStatus.NotFound;   // failure statuses
Result<User> ok = user;                  // wraps as Success
```

---

## 👥 Who is this for?

Developers who:

- Care about clean, explicit code
- Use DDD or Clean Architecture
- Want expressive application flow
- Build scalable APIs and services

---

## 📄 License

Licensed under the [Apache License 2.0](LICENSE).

---

## 🐞 Contributing

Found a bug or have an idea?  
Open an issue: https://github.com/IMustafaZeynali/IResultPattern/issues
