# Web_Services_API_Tests
Lab: Web Services and Integration Tests
This document defines the homework assignments from the  "QA Automation" Course @ Software University.
Please submit as homework a single zip / rar / 7z archive holding the source code or whatever approach is needed to finish your tasks. This exercise will be submitted together with next exercise after you receive it. 
1.	Setup
For the purpose of this exercises you will need some additional software. Follow this guide to make the right setup and run your demo project. Most of the steps need to be executed just once at the begging. All software MUST be installed with default settings (if you change anything in installation process it can result to not running demo)
•	Download and install Postman desktop client
•	Download and install NodeJS version v12.18.*
•	Download and install PostgreSQL (add any password you want during the setup)
•	Download and extract "Demo.zip" file from SoftUni website
•	In the root directory execute "npm install" command in the Command Line
•	Open file root/server/config/config.json and add PostgreSQL password for bot development and test 
•	In the root directory execute "npm run db:create" command in the Command Line
•	In the root directory execute "npm run start:dev" for development environment
•	In the root directory execute "npm run start:test" for test environment
2.	End-points
After finishing the setup, you should have locally running API, which is listening on port 3000. Your host URL should be http://localhost:3000. For every single request you need to add specific header with name "G-Token" and value "ROM831ESV", otherwise you will always receive response code 403 Forbidden.	
•	GET endpoints – always responds with json format
o	/books – gets all books in database
o	/books/{id} – gets a single book with this id
o	/books/search{{query}} – returns specific books, which fulfill the search criteria 
o	/users – gets users in database
o	/users/{id} – gets a single user with this id
o	/households/{{householdId}}/wishlistBooks
•	POST endpoints – All of them need to specify application/json for Content-Type
o	/books – you should provide title, author, isbn and publication date
o	/users – you should provide email, first and last name, household ID 
o	/households – you should provide name
o	/wishlists/{household}/book/{bookId} – you should NOT add any body
•	DELETE endpoints – need to have basic authorization to perform this action
o	/books/{id} – deletes a single book with provided id from the database



3.	Add the First Collection
Prepare a collection of requests which needs to: 
•	Add a new household
•	Add two different users
•	Add two books for each user
•	Get a wishlist for a created household 
4.	C#
Do the same task with C# code.
