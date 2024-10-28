# Assignment-1

This repository contains solutions to programming assignments related to the **Canadian Computing Competition (CCC)** problems. Implemented using ASP.NET Core Web API, the assignments provide RESTful APIs for solving and testing various algorithmic problems.

## Table of Contents

- [Overview](#overview)
- [API Endpoints](#api-endpoints)
- [Getting Started](#getting-started)
- [Example Code](#example-code)
- [Note](#note)

## Overview

This project provides implementations for problems using ASP.NET Core and includes solutions for:
- `Deliv-e-droid`: Calculates delivery scores with penalties for collisions.
- `Chili Peppers`: Computes the spiciness of chili based on pepper types.
- `Fergusonball Ratings`: Calculates player star ratings based on points and fouls.
- FOR QUESTIONS

## API Endpoints

The project contains multiple endpoints, each handling a specific CCC problem.

| Endpoint | Description |
| -------- | ----------- |
| `/api/Delivedroid/CalculateScore` | Calculates delivery score for "Deliv-e-droid" |
| `/api/J2/ChiliPeppers` | Calculates chili spiciness based on ingredients |
| `/api/J2/FergusonballRatings` | Evaluates player ratings for "Fergusonball" |

For complete documentation, refer to [ASP.NET Core Web API Documentation](https://learn.microsoft.com/en-us/aspnet/core/web-api/).

## Getting Started

1. Clone the repository:
   ```console
   git clone https://github.com/username/CCCAssignment.git
   ```

2. Navigate to the project directory:
  ```console
     cd Assignment1
  ```

3. Run the project:
  ```console
   dotnet run
  ```

## Examnple Code
```js
// Example for calculating chili spiciness in J2Controller
    [HttpGet("ChiliPeppers")]
    public IActionResult CalculateSpiciness([FromQuery] string ingredients)
    {
        var peppers = ingredients.Split(',');
        int totalSpiciness = peppers.Sum(pepper => PepperSHU.GetValueOrDefault(pepper.Trim(), 0));
        return Ok(totalSpiciness);
    }
```
