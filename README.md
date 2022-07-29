
# Quick Loan Service

This is a minimalist service of a loan application I developed for my previous employer.

Its a system that manages and disburses loans to application user and the admin can manage user/loans and loan configurations.


## [](https://github.com/moostee/quick-loan-service#task)Task

A solution containing a WebAPI, Docker and a frontend based on a Typescript based Single Page Application Framework

## [](https://github.com/moostee/quick-loan-service#table-of-contents)Table of Contents

-   [Features](https://github.com/moostee/quick-loan-service#features)
    -   [Authentication](https://github.com/moostee/quick-loan-service#authentication)
    -   [Users](https://github.com/moostee/quick-loan-service#receptionist-users)
    -   [Admin Users](https://github.com/moostee/quick-loan-service#admin-users)
-   [Scope of my solution](https://github.com/moostee/quick-loan-service#scope-of-my-solution)
    -   [Backend](https://github.com/moostee/quick-loan-service#backend)
    -   [User Interface](https://github.com/moostee/quick-loan-service#user-interface)
-   [Limitations](https://github.com/moostee/quick-loan-service#limitations)
-   [Likely Improvements](https://github.com/moostee/quick-loan-service#likely-improvements)
-   [Installation Information](https://github.com/moostee/quick-loan-service#installation-information)

## [](https://github.com/moostee/quick-loan-service#features)[](https://github.com/moostee/quick-loan-service#features)Features

Quick loan service consists of the following features:

### [](https://github.com/moostee/quick-loan-service#authentication)[](https://github.com/moostee/quick-loan-service#authentication)Authentication

-   It uses JSON Web Token (JWT) for authentication.
-   Token is generated on user login
-   Token is perpetually verified to check the state of the user if logged in or not.
-   Admin User is pre-seeded into the application with administrative priviledges
-   Admin User can create new users and set their role to either user or Admin

### [](https://github.com/moostee/quick-loan-service#receptionist-users)[](https://github.com/moostee/quick-loan-service#receptionist)Loan Users

-   Users can log in.
-   Users can apply for a loan.
-   Users can view loan repayment details.
-   USers can view wallet balance.
-   Users can repay active loan.

### [](https://github.com/moostee/quick-loan-service#admin-users)[](https://github.com/moostee/quick-loan-service#admin)Admin Users

-   Admin Users has all other priviledges apart from applying for a loan.
-   Admin Users can log in
-   Admin Users can manage (add, update and activate/deactivate) application Users
-   Admin Users can manage user loans

## [](https://github.com/moostee/quick-loan-service#scope-of-my-solution)[](https://github.com/moostee/quick-loan-service#scope)Scope of my solution

#### [](https://github.com/moostee/quick-loan-service#backend)[](https://github.com/moostee/quick-loan-service#scope-backend)Backend

-   Clean architecture for project structure
-   Domain Driven Design
-   Mediator Pattern
-   Entity framework for ORM
-   Unit of Work and Repository Pattern
-   Unit tests on the Domain Entities
-   Open API documentation using Swagger UI
-   MSSQL for the Database.

### [](https://github.com/moostee/quick-loan-service#user-interface)[](https://github.com/moostee/quick-loan-service#scope-ui)User Interface

-   A single page application built with Angular using  [Angular Material](https://material.angular.io/)  compnents
-   Webpack: Webpack is a module bundler. Its main purpose is to bundle JavaScript files for usage in a browser, yet it is also capable of transforming, bundling, or packaging modules.
-   Modularized project structure.

## [](https://github.com/moostee/quick-loan-service#limitations)[](https://github.com/moostee/quick-loan-service#limitations)Limitations

The limitations with this current version of Quickloan Service includes:

-   Users can neither withdraw nor fund their wallet
-   Users can only apply for a loan duration of a month.
-   Admin cannot manage loan percentage  configuration.

## [](https://github.com/moostee/quick-loan-service#likely-improvements)[](https://github.com/moostee/quick-loan-service#improvements)Likely Improvements

Along with handling of the aforementioned limitations, the following improvements can be made:

-   More test coverage
-   Implementing event source to improve API performance
-   Better UX
-   Connect user wallet to payment providers for withdrawal/funding of wallet
-    

## [](https://github.com/moostee/quick-loan-service#installation-information)[](https://github.com/moostee/quick-loan-service#installation)Installation information

Clone the project
```
git clone https://github.com/moostee/quick-loan-service
```

From the project root, run the following:
```
docker-compose build
docker-compose up
```
Launch the API on [https://localhost:7024/](http://localhost:7000/)

Launch the UI on [https://localhost:5007/](https://localhost:5006/)