# QnA Platform Backend

## **Description**

You are requested to create a simple backend for a Q&A Forum called "QnA" where a user would be able to publish a new question, and in-turn other users on the platform would be able to answer the question as well as up/down vote questions. Each question is ranked based on the amount of interaction that takes place with the question based on the metrics(upvotes, downvotes, answers). No UI is required for this task

## Functional Requirements

**Authentication**

Simple authentication will be done by passing username and password to the login endpoint as listed below. Authentication returns a simple ID to be used for further calls. it can be as simple as a UUID, don't overcomplicate this process. This is not a best practice in terms of security, it is only acceptable for the purposes of this exercise, it is meant to simplify this task

**Up/Down Voting**

Only answers can be up/down voted by any logged in user. Each answer would have a final VoteScore which is {UpVotes} - {DownVotes}.

An Answer is considered to be UpVoted if the number of up votes is higher than down votes i.e VoteScore > 0 and vice versa.

## Development Requirements

**Technical Requirements**

-   The backend should be entirely developed in .Net Core 6. You are free to use any libraries/frameworks that would make development easier or faster.
-   Code is expected to be clean and readable with relevant variable and module names
-   File/Folder Structure is expected to be well organized and file names relevant to content
-   The final exposed API should follow the endpoints listed below
  
**Data Persistence Requirements**

-   You are free to use any means to persist data as long as you demonstrate the use of EF Core. It is acceptable if data is lost on server/image restart. We recommend using SqlLite, you won’t get extra points or lose points if you choose a DB Engine 

**Testing requirements**

-   The backend functions are expected to be covered by unit tests. At least one unit test per method is expected. You are free to add as many unit tests as you believe is satisfactory
-   Tests that use the exposed end points can replace method unit tests and in that case, each endpoint should have at least one test.
-   All tests should be passing upon delivery

##   

## Endpoints

```
POST ​/login -> The login endpoint
GET ​/questions -> Get all questions and their answers
POST ​/questions -> Add a new question
GET​ /questions​/{questionId} -> Get a question
POST ​/questions​/{questionId}​/answers -> Add an answer to question
DELETE ​/questions​/{questionId}​/answers​/{answerId} -> Delete an answer
PUT ​/questions​/{questionId}​/answers​/{answerId}​/votes -> Up/Down/Un-Vote an answer
```

## Expected Deliverables

-   Entire code should be delivered in a git repo.
-   The final git repo could be either pushed to any free git hosting service (providing us with a link).
-   There is no restriction on how many commits/branches are included on the repo. However, we will highly appreciate the proper use of source control with relevant commits and commit messages.
-   Please deliver the backend with at least 5 users set up and provide the list of users and passwords in a text file in the same delivery folder.
-   Dockerfile should be included in repo if you go for that optional requirement
-   Postman collection should be included in repo if you go for that optional requirement
-   Please record the time it took you to complete the task

Assessment Criteria  
A git repository is delivered  
Following best practices in code and modeling  
All unit tests pass  
Code Quality and organization  
Optional Requirements delivered. (only gives advantage)  
The docker image is created and run successfully, if delivered  

## Optional Requirements

The below are optional requirements which will positively impact your assessment if you implement but won't have any negative impact if skipped

**Delete Endpoints**

Implementing DELETE endpoints as outlined below is optional.

```
DELETE ​/questions​/{questionId} -> Delete a question 
```

**Question Rank**

Listing questions (GET /questions) returns results ordered descendingly by QuestionRank as defined below::

```
QuestionRank = {MaxUpVotes} * {AnswersCount} - {CountOfDownVotedAnswers}
```

Where:

-   MaxUpVotes is the total number of upvotes on the most upvoted answer
-   AnswersCount is the total count of answers for that specific question (up or down voted)
-   CountOfDownVotedAnswers is the count of answers with VoteScore < 0

**Dockerizing**

Dockerize the project by writing its Dockerfile on the repo root.

**Postman Collection**

A postman collection to easily interact with the backend