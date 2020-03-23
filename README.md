
I relocated the connection string to web.config file instead of hard coded in database.cs file( easy to change during deployment). 
I created  an exception handler in the base class of the controller, when ever exception will happen , it will redirect the user to error page.
I added authentication filter, it's ready to use for authentication token.
I refactored the codes in the web project.
I created a new unit test case for GetOrder.
I do not want make it more complicate by add Dependence Injection and Auto Mapper.
I would suggest to set debug = false in web.config and compile with Release mode for production deployment.
I've updated the UI with very little efforts