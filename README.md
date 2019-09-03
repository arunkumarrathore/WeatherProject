# WeatherProject
WeatherAPI is the case study for Prudential and should be used as such.

# How to set up local project
1. Set the following key in appsetting for web.config(api project) and app.config(test project)
```
 <appSettings>
    <add key="AppId" value="subscriptionkey for openweathermap API"/>
    <add key="OutputFolderName" value="The name of output folder where you want data"/>
    <add key="WeatherApiUrl" value="https://api.openweathermap.org"/>
  </appSettings>
```
# Assumption for this API to work
1. The city file name will be provided as parameter (ex: http://localhost:62316/Weather/GetWeather?fileUrl=C:\SomeFolder\WeatherAPI\WeatherAPI\CityInfo.txt)
2. File path will be a local file path and not of a FTP/Cloud server
3. The output folder will be created on the same location as the input file.

# Features
1. GetWeather API will provide a 200 OK result with a folder path where all the output files are stored.
2. Swagger is implemented in very raw form just to give a simple documentation of the API, just use localhost:portnumber/swagger to access the swagger documentation

# The requirments that are not covered as per case study
No major requirment is unimplemented but this code represent a crude solution of the given problem.

# Possible improvement
1. More unit tests 
2. Use of MOQ for the better testability of the code.
3. Use of dependency injection for loose coupling.
4. Implemtation of better exception handling.
5. Better handling of http call to openweather API.
6. Secure API with something like OAuth2
