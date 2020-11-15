# ResponseTimeCheck
Response time checking begins with start of StartMonitoring method in its own thread (code located in global.asax.cs). 
If you want to change uri, you should change DefaultURI value in CommonConstants class or use custom constructor.
If tou want to change period, you should change PeriodInSeconds value in CommonConstants.
If you want to check results of response time measurments, you can use API:

GET api/Entities/All  
returns all entries in database;

GET api/Entities/Latest/{number}  
returns latest entries in database, where number of shown entries depends on user's will 

GET api/Entities/First/{number}  
returns first entries in database, where number of shown entries depends on user's will
