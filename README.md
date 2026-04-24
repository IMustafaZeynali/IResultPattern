# iResultPattern
A lightweight and expressive result‑handling package designed for .NET applications.
<br>
🚀 IResult Pattern – A Clean, Explicit and Production-Ready Result Model for .NET

Stop returning raw exceptions.
Stop mixing business logic with HTTP responses.
Start modeling results explicitly.

# 🎯 What Is This Package?

IResult Pattern is a lightweight, production-ready result modeling library for .NET applications that provides a clean and consistent way to represent operation outcomes.

Instead of throwing exceptions for flow control or returning loosely structured responses, this package helps you return strongly-typed, explicit, and predictable results across your application layers.

## Perfect for:

* ASP.NET Core Web APIs
* Clean Architecture
* Domain-Driven Design (DDD)
* Microservices
* Event-Driven systems
* Modular monoliths

# ✨ Key Features
🔹 Explicit Status Modeling

## Includes structured result statuses aligned with HTTP semantics:

* Success (200)
* Created (201)
* NoContent (204)
* BadRequest (400)
* Unauthorized (401)
* Forbidden (403)
* NotFound (404)
* Conflict (409)
* ValidationError (422)
* InternalServerError (500)
* ServiceUnavailable (503)

This enables clear and predictable API behavior.

🔹 Strongly-Typed Results
``` C#
Result<T>
Result
```


Return data safely with proper status and messages.

🔹 Backward Compatible

Legacy Failure status is still supported (marked as obsolete), ensuring no breaking changes for existing systems.

🔹 Clean Architecture Friendly

## Designed to:

* Separate business logic from transport layer concerns
* Improve readability
* Reduce exception misuse
* Provide consistent response contracts

🔹 Lightweight & Dependency-Free

* No external dependencies.
* No magic.
* Just clean, explicit result modeling.

# 🧠 Why Use This Instead of Exceptions?

Exceptions should represent exceptional conditions — not validation failures or predictable outcomes.

## This package encourages:

* Explicit business outcomes
* Better error handling
* Improved API consistency
* Easier testing
* Clearer code semantics

# 🔥 Example
``` C#
return Result.Success(data);

return Result.NotFound("User not found");

return Result.ValidationError(error);
```


## Clean. Predictable. Maintainable.

# 🎯 Who Is This For?

This package is ideal for developers who:

Care about clean code

* Use DDD or Clean Architecture
* Want explicit and expressive application flow
* Build scalable APIs and services

If you believe that clarity and correctness matter in software design —
this package is for you.

🐞 Found a bug?  
Please open an issue on GitHub:
https://github.com/IMustafaZeynali/IResultPattern/issues
