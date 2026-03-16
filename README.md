# 🇵🇦 Panama API

Panama API is an open-source project that aims to make data about Panama easily accessible through a simple and free REST API. The API provides access to information about geography, public holidays, airports, presidents, and general country data.

All data comes from reliable sources such as government websites, official statistical agencies, and public records. Unlike proxy APIs, Panama API stores and serves data directly, meaning fast response times and high availability without depending on third-party sources.

Our main goal is to keep the API free, reliable, and useful for developers building applications related to Panama. As the project evolves, we plan to add more datasets such as tourist sites, universities, typical food, and more.

**This project is currently under development, meaning things could change!**

## Demo
https://panama-api.up.railway.app

## Available Endpoints

### Geography

#### Provinces & Comarcas
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/provinces` | Get all provinces and comarcas |
| GET | `/api/v1/provinces/{id}` | Get a province by ID |
| GET | `/api/v1/provinces/{id}/districts` | Get all districts of a province |

#### Districts
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/districts` | Get all districts |
| GET | `/api/v1/districts/{id}` | Get a district by ID |
| GET | `/api/v1/districts/{id}/corregimientos` | Get all corregimientos of a district |

#### Corregimientos
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/corregimientos/{id}` | Get a corregimiento by ID |

### Holidays
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/holidays` | Get all holidays |
| GET | `/api/v1/holidays?year=2026` | Filter by year |
| GET | `/api/v1/holidays?type=National Holiday` | Filter by type |
| GET | `/api/v1/holidays/{id}` | Get a holiday by ID |

### Airports
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/airports` | Get all airports |
| GET | `/api/v1/airports?province=PANAMA` | Filter by province |
| GET | `/api/v1/airports?category=Aeropuerto Internacional` | Filter by category |
| GET | `/api/v1/airports/{id}` | Get an airport by ID |

### Presidents
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/presidents` | Get all presidents |
| GET | `/api/v1/presidents/{id}` | Get a president by ID |
| GET | `/api/v1/presidents?year=1999` | Get a president by year |

### Country Info
| Method | Endpoint | Description |
|--------|----------|-------------|
| GET | `/api/v1/countryinfo` | Get general information about Panama |

## Response Format

All endpoints return a consistent JSON format:

**Success:**
```json
{
  "success": true,
  "data": { ... }
}
```

**Error:**
```json
{
  "success": false,
  "message": "Province not found",
  "code": 404
}
```

## Rate Limiting

To ensure fair usage, the API enforces the following limits:

| Period | Limit |
|--------|-------|
| Per minute | 60 requests |
| Per hour | 1000 requests |

When the limit is exceeded, the API returns HTTP `429 Too Many Requests`.

## Tech Stack

- **Backend:** ASP.NET Core 10
- **Database:** PostgreSQL 18
- **Deploy:** Railway
- **Containerization:** Docker

## Contributors

[Joseph Rosas](https://github.com/josephr04)

Feel free to open an issue or submit a pull request if you find any bugs or want to contribute data.
