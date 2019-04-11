# CalculatorService
HTTP/REST based 'Calculator Service’

## Configuration

### CalculatorService.Server App Config
Please make sure everything is configured before run the application
`JournalPath` Full Path to the Journal Database file. You could find it at CalculatorService.Data folder

## How to build
In order to build this application, just right click and select 'Build' in CalculatorService.Server on Visual Studio. NuGet will automatically download all dependences required.

## How to deploy
Right click over CalculatorService.Server and click publish. Choose 'Folder' option and continue. After the proccess success, take target folder and leave it on IIS Server directory, after all configure conveniently IIS.

## How to run
Simply make sure CalculatorService.Server is set as StartUp Project, you could see title is bold.

## Some other work to be done
Some other points that could be done in a future:
 1. Server Log: All the Exceptions produced on the server side could be logged to a file or the database.
 2. Admit optional TrackingID argument from Client application.


