# Salon Management System – Use Cases

## 1. Introduction
This document describes the primary use cases of the Salon Management System. Use cases capture how different user roles interact with the system to achieve specific goals. They are written from a functional, user-centered perspective and align directly with the documented requirements.

---

## 2. Actors
- **Guest** – Unauthenticated visitor
- **Customer** – Registered and authenticated user
- **Admin** – Privileged system administrator

---

## 3. Use Cases

### UC-01: Browse Services
**Actor:** Guest, Customer  
**Description:** Allows users to view available salon services.

**Preconditions:**
- System is available

**Main Flow:**
1. User navigates to the Services page
2. System displays a list of available services
3. User selects a service to view details

**Postconditions:**
- No data is modified

---

### UC-02: Register Account
**Actor:** Guest  
**Description:** Allows a guest to create a customer account.

**Preconditions:**
- User is not authenticated

**Main Flow:**
1. Guest selects Register
2. Guest enters required information
3. System validates input
4. System creates a customer account

**Postconditions:**
- Customer account exists

---

### UC-03: Login
**Actor:** Customer, Admin  
**Description:** Authenticates a registered user.

**Preconditions:**
- User account exists

**Main Flow:**
1. User enters credentials
2. System validates credentials
3. System grants access

**Postconditions:**
- User is authenticated

---

### UC-04: Create Booking
**Actor:** Customer  
**Description:** Allows a customer to book a salon service.

**Preconditions:**
- Customer is authenticated

**Main Flow:**
1. Customer selects a service
2. Customer selects a barber
3. Customer selects date and time
4. System validates availability
5. Customer submits booking

**Postconditions:**
- Booking is created with pending status

---

### UC-05: Make Payment
**Actor:** Customer  
**Description:** Completes payment for a booking.

**Preconditions:**
- Booking exists

**Main Flow:**
1. Customer initiates payment
2. System processes payment
3. System confirms payment

**Postconditions:**
- Booking is marked as paid

---

### UC-06: View My Bookings
**Actor:** Customer  
**Description:** Allows customers to view their booking history.

**Preconditions:**
- Customer is authenticated

**Main Flow:**
1. Customer navigates to My Bookings
2. System displays past, current, and future bookings

**Postconditions:**
- No data modified

---

### UC-07: Manage Services
**Actor:** Admin  
**Description:** Allows administrators to manage salon services.

**Preconditions:**
- Admin is authenticated

**Main Flow:**
1. Admin opens Service Management
2. Admin creates, updates, or deactivates services

**Postconditions:**
- Service data updated

---

### UC-08: Manage Bookings
**Actor:** Admin  
**Description:** Allows administrators to approve or cancel bookings.

**Preconditions:**
- Admin is authenticated

**Main Flow:**
1. Admin views booking list
2. Admin approves or cancels a booking

**Postconditions:**
- Booking status updated

---

### UC-09: Manage Barbers
**Actor:** Admin  
**Description:** Allows administrators to manage barber profiles.

**Preconditions:**
- Admin is authenticated

**Main Flow:**
1. Admin opens Barber Management
2. Admin creates or updates barber profiles

**Postconditions:**
- Barber data updated

---

## 4. Traceability Note
Each use case maps directly to functional requirements defined in `Requirements.md` and is implemented through Razor Pages and associated Page Models.

