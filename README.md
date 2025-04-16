# FoodTruck Reservation – MVP

A web application to book spots for food trucks.  
Built with C# / ASP.NET Core 8, MongoDB, Blazor, xUnit, Docker, and GitHub Actions.

---

## Project Goal

Enable food trucks to **book locations** on specific dates,  
and allow location managers to **manage spot availability**.

This MVP version focuses on delivering core features with a clean, testable, and scalable architecture.

---

## Target Users

| Role                | Description                                                                                        |
|---------------------|----------------------------------------------------------------------------------------------------|
| **Food Truck**      | Can sign up, log in, view available locations, and book a time slot.                               |
| **Manager** (admin) | Can create, edit, and delete locations, view reservations, and approve or reject booking requests. |

---

## MVP Features

### Authentication
- Sign up and login for food trucks
- Manager login (predefined admin account for MVP)
- JWT-based authentication

### Locations
- Create new locations (city, address, description, capacity, etc.)
- List available spots (for food trucks)
- Edit/delete locations (admin only)

### Reservations
- Food trucks:
  - View availability
  - Book a location for a specific date
- Admin:
  - Approve or reject reservations
  - Access reservation history

### History
- Food trucks can see past and upcoming reservations

---

## Tech Stack

| Component          | Technology                            |
|--------------------|---------------------------------------|
| **Backend**        | ASP.NET Core 8 Web API                |
| **Frontend**       | Blazor (Server or WASM to be defined) |
| **Database**       | MongoDB                               |
| **Authentication** | JWT (custom or with Identity)         |
| **Testing**        | xUnit                                 |
| **Containers**     | Docker (API + MongoDB)                |
| **CI/CD**          | GitHub Actions                        |

---

## Key Workflows

### 1. Booking a location as a food truck
1. Login
2. View available spots
3. Book a time slot
4. Admin receives notification
5. Admin approves or rejects request

### 2. Managing locations as an admin
1. Login as admin
2. Access admin dashboard
3. Create / Edit / Delete locations

---

## Testing

- Unit tests on business logic with xUnit
- Reservation logic tests (conflicts, availability)
- Authentication tests
- Swagger or Postman for manual API testing

---

## Suggested Timeline

| Week | Goals |
|------|-------|
| 1    | Project setup, authentication, Docker |
| 2    | MongoDB modeling + Location API |
| 3    | Reservation API + Start frontend |
| 4    | Blazor UI + GitHub Actions pipeline |
| 5    | Final testing + demo 🎉 |

---

## Notes

- Blazor is chosen as a forward-looking full-stack Microsoft technology.
- MongoDB allows schema flexibility, suitable for fast iteration.
- No payment system is included in this MVP.

---

## Next Steps

1. Create the GitHub repo
2. Initialize the solution and projects
3. Write the initial architecture (backend, frontend, docker)
4. Build iteratively based on the roadmap

---

Made with ☕ & passion for clean code.
