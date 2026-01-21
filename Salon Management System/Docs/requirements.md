# Salon Management System – Requirements

## 1. Introduction
This document defines the functional and non-functional requirements for the Salon Management System. Requirements are grouped by user role to clearly describe responsibilities, permissions, and system behavior from a stakeholder perspective.

---

## 2. User Roles

### 2.1 Guest
An unauthenticated visitor to the system.

### 2.2 Customer
A registered and authenticated user who can book and manage appointments.

### 2.3 Admin
A privileged user responsible for managing system operations and data.

---

## 3. Functional Requirements (Grouped by Role)

### 3.1 Guest Requirements
- Guests can access the public landing page.
- Guests can browse available salon services.
- Guests can view basic service information (name, description, price).
- Guests cannot create bookings.
- Guests are prompted to register or log in when attempting restricted actions.

---

### 3.2 Customer Requirements

#### Account & Authentication
- Customers can create an account using email and password.
- Customers can log in and log out securely.
- Customers must be authenticated to create or manage bookings.

#### Service Interaction
- Customers can browse all available services.
- Customers can view detailed information for each service.

#### Booking Management
- Customers can create a booking by selecting:
  - A service
  - A barber
  - A date and time
- Customers can complete a booking using online payment.
- Customers can view a list of all their bookings.
- Customers can distinguish between past, current, and future bookings.
- Customers can view booking status (pending, approved, cancelled).

#### Payments
- Customers can make online payments to confirm bookings.
- Booking confirmation is dependent on successful payment.

---

### 3.3 Admin Requirements

#### Access Control
- Admin access is restricted to authenticated users with the Admin role.
- Admin-only features are not accessible to Customers or Guests.

#### Service Management
- Admins can create new salon services.
- Admins can update existing services.
- Admins can deactivate or remove services.

#### Booking Administration
- Admins can view all bookings in the system.
- Admins can approve bookings.
- Admins can cancel bookings.
- Admins can manage booking conflicts.

#### Barber Management
- Admins can create barber profiles.
- Admins can update barber availability.
- Admins can activate or deactivate barbers.

#### System Oversight
- Admins can manage the overall system through a central dashboard.
- Admins can monitor operational metrics (bookings, services, barbers).

---

## 4. Non-Functional Requirements

### 4.1 Security
- Authentication is required for all booking and administrative actions.
- Role-based access control is enforced throughout the system.
- Passwords are stored securely using industry-standard hashing.
- Sensitive operations are protected against unauthorized access.

### 4.2 Performance
- The system supports concurrent users without significant degradation.
- Common operations (service browsing, booking creation) respond within acceptable time limits.

### 4.3 Scalability
- The architecture supports future scaling to multiple salons or increased user load.
- The system design allows migration to cloud hosting without major refactoring.

### 4.4 Reliability
- The system ensures data consistency for bookings and payments.
- Errors are handled gracefully and logged appropriately.

---

## 5. Data Requirements
- All application data is persisted in a SQL Server database.
- The system stores data for:
  - Users and roles
  - Services
  - Barbers
  - Bookings
  - Payments

---

## 6. Constraints
- The system is implemented using ASP.NET Core Razor Pages.
- Entity Framework Core is used as the ORM.
- SQL Server LocalDB is used during development.
- Authentication is implemented using ASP.NET Core Identity (Individual Accounts).

---

## 7. Assumptions
- Users have internet access and modern web browsers.
- Online payment functionality may initially be partially implemented.
- Hosting is local during development, with production deployment planned.

---

## 8. Future Enhancements
- Mobile application support.
- Advanced reporting and analytics for Admins.
- Integration with third-party payment gateways.
- Notification system (email or SMS reminders).
- Multi-salon support.

