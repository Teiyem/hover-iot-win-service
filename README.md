# Hover Windows Service
Hover Windows Service is a C# ASP.NET Web API application which is hosted as a Windows Service that interfaces with Hover, which is the central hub for managing and monitoring smart home devices. Hover Windows Service also serves as a smart home device to Hover as a computer, with peripherals from Razer, and provides an interface to the Chroma REST SDK API.

## Features (In Progress)
* Interfaces with Hover backend to manage and monitor smart home devices. ⚠
* Serves as a smart home device to Hover as a computer. ⚠
* Provides an interface to the Chroma REST SDK API. ⚠
* Manages and provides data from the central hub to a C# WPF App. ⚠
* Allows Hover Windows to communicate with the central hub to control devices using Named Pipes. ⚠

## Technologies Used
* Windows OS.
* .NET 6.
* MSSQL.
* Chroma REST SDK API.
* Hover Spring Boot central hub.

## Installation
* Clone the repository.
* Open Command Prompt as an Administrator.
* Navigate to the hover-iot-win-service\scripts.
* Modify the install.conf file with the appropriate values based on your preference.
* Run the install.bat file to create the necessary directories, publish the application, set permissions, register the service, and start the service. 
* If the service already exists, the batch file will stop and prompt you to delete or update the existing service. Choose the appropriate action based on your needs.
* Ensure that the Hover backend is running and accessible.

## Usage
* Use the Hover Windows Service to manage and monitor smart home devices.
* Use the interface to the Chroma REST SDK API to control Razer peripherals.
* Use the Hover Windows Service to communicate with Hover.
* Use the C# WPF App to view data and control smart home devices through the Hover Windows Service.

## Authors
Hover Windows Service was developed by Thabang Mmakgatla.

## Acknowledgments
Special thanks to Razer for providing the Chroma REST SDK API.

## License
Hover Windows Service is licensed under the MIT license. See the LICENSE file for details.
