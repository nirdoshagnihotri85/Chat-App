Package contain two projects and one script:

1. LetsChat: is resposible to front end and signalR
2. LetsChatApi: is responsible for database interaction.
3. LetsChatDB script: Contain database schema.

1. LetsChat: In this project we are using Angularjs for front end and SignalR. In both we need ApiPath.

   For Angular api path stored in line 30 of Scripts/app/app.js. 
   For SignalR we are stroing api path in webconfig app setting "ApiPath".
   
   You can change api path as per your need.



2. In LetsChatApi for database we are using "LetsChatEntities" connection string.
   


3. LetsChatDB scripts contains database object of this application.


Steps to run project:

1. Restore database.
2. Update connection string "LetsChatEntities" in web config of "LetsChatApi" project.
3. Run LetsChatApi project locally or host on IIS. Copy base path of this application.
4. Update "LetsChatApi" application url in app setting "ApiPath" in webconfig of "LetsChat" project.
5. Update "LetsChatApi" application url in line 30 of Scripts/app/app.js file of  "LetsChat" project.

Now applications must be run. If you are facing any issue let me know.



Feature include:
1. User can login 
2. User will see existing message if available.
3. User can see another logged in users.
4. User can send message which will available to all users.
5. User can see message sent by any user.
6. If any user logged out it will be automatically reflected in user list.
7. If any new user logged in then it will reflect automatically in user list.
