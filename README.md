# CalculatorService
HTTP/REST based 'Calculator Service’

## Configuration

### CalculatorService.Server Web Config
Please make sure everything is configured before run the application
`JournalPath` Full Path to the Journal Database file. You could find it at CalculatorService.Data folder

### CalculatorSErvice.Client App Config
Please make sure everything is configured before run the application
`ServiceURL` should point to the URL where the Server has been deployed.

## How to build
In order to build this application, just right click and select 'Build' in CalculatorService.Server on Visual Studio. NuGet will automatically download all dependences required.

## How to deploy
Right click over CalculatorService.Server and click publish. Choose 'Folder' option and continue. After the proccess success, take target folder and leave it on IIS Server directory, after all configure conveniently IIS.

## How to run
Simply make sure CalculatorService.Server is set as StartUp Project, you could see title is bold.

## Some other work to be done
Some other points that could be done in a future:
1. Server Log: All the Exceptions produced on the server side could be logged to a file or the database.
 

## Usage

### Client
Commmand Line interface, that provides a way to execute operations to the CalculatorService.Serve. All the operations are explained on a menu once executed the application.

Client also allows to save an operation to database via 'TrackingId'. Just execute operation as normal, and provide another argumment with the Tracking key. Example: 

    >add 2,2,2 key1

Will save add operation and result to database under key `key1`

In order to check saved operations, command should be something like

    >journal key1



