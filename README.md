# Guidant
This doc aims to give a brief overview of the application I built, along with some architecture notes, and testing instructions. I hope this is helpful and not just completely overwhelming.

# Architecture
Let's start off by saying that for the problem that was given, my solution is way over-architected. For something that'll stay this simple, we could write a very basic application to do the job. That being said, I built this with the expectation that we might want this very simple solution to grow into something more complex. Here are some basic notes on why I architected the project this way.

The solution is separated into several different projects, all with different responsibilities

Projects
-------------
**GuidantHomework**
- Core Web Project
- Contains our UsersController (renamed Values controller to have the routes named nicely by convention)
- I use our other projects to handle most of the business/data logic, allowing us to keep our controllers very light
- Also contains our Unity IoC bootstrapping code for app start

**Guidant.Core**
- Project shared between all of the other projects.
- Holds our domain models. In this case, only User.
- Holds our interface definitions for our Services/Repositories

Guidant.Data
- Holds our repositories as well as a static list that we're using for a poor-man's database.
- I decided to use a static list so that the project was more easily distributable to the team. I added basic SQL calls in comments within the repository methods, to explain what they'd actually be doing
- Repositories are responsible only for data interactions. They shouldn't have business logic. The closest it comes to that is reinforcing a unique username policy, which would probably be handled by the db definition otherwise.

GuidantHomework.IoC
- I used Unity for my IoC container. We want to have IoC linking our projects together because it keeps things loosely coupled.

Guidant.Services
- The Service layer is responsible for handling business logic.
- By separating this from the controllers, it allows us to reuse logic between two projects. So if we had an MVC front-end as well as this WebAPI, we could re-use our service/repository libraries.
- The service in this project is very similar to the repository, but again, I'm trying to think about what happens when this gets more complicated.

Guidant.Tests
- Basic unit tests for the classes.
- Hardly exhaustive, but cover some basic cases so we know we're not breaking code when we make small changes

#Testing

Error messages
--------------
Error messages are handled through exceptions, in this case. While getting a nice friendly input back from an API is nice to read, returning an exception lets us know that the call failed, and also returns valueable debugging information. In a production environment, it might make more sense for the consumer of the API to be responsible for displaying error messages.

I did, however, provide friendly error messages in each of the exceptions that are easily accessible from the ExceptionMessage property on the response.  That would allow a consumer to easily display a helpful message.

Testing
--------------
I wasn't sure if you had a particular testing setup you'd like to use, so I set up a Postman collection that I included with some base cases for the API calls.

If you're not familiar with Postman, here are instructions to get it set up. If you're already a pro, don't mind me :)
- download/install postman
- Run the application after install
- Click "import" in the top left corner (gray button).
- Navigate to the root of the repo and select "Guidant.postman_collection"
- This will import the collection into your "Collections" tab. Click that tab (top left column)
- You should see a series of HTTP requests under the collection "Guidant"
- Each of those requests is set up to call my API once it's running, and supply some inputs
- Feel free to modify the inputs as you like, and look at the responses.
- (JSON payloads are included in the "body" section under "raw")

Assumptions
--------------
I've had to make a couple of assumptions along the way about how this should behave. Here are a few:
- POST /api/users can take either a full User JSON object including an ID, or can take a JSON object without an explicit ID. If the ID is explicit, the repo checks if it's a duplicate id. If it is, it throws an exception, otherwise, it inserts. If the ID isn't explicit, it inserts a new User with an ID incremented from the last value inserted in the static list
  - This still has a potential ID collision in the case where we've already inserted an explicit ID, and the new generated ID is the same as the previous explicit one. I'm going to allow it in this example because it would be handled automatically in a db with an auto-incrementing Primary Key
- POST /api/users checks on insert if the name passed in is a duplicate. If it is, we throw an exception
- The fake db is set up with a reset function that I'm using to set up a fresh state to test with
- There are also comments set up to explain decision making throughtout the app.

