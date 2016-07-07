# QlikSenseEpic2015DLL
A dll that works with [QSTicketEpicModule](https://github.com/eapowertools/QSTicketEpicModule) to integrate Qlik Sense authentication with Epic Hyperspace.

##Requirements
- Qlik Sense Enterprise Server 2.2.4 and above
- Epic Hyperspace 2015 (version 8.2)

##Prerequisites
- [QSTicketEpicModule](https://github.com/eapowertools/QSTicketEpicModule): This solution implements the authentication scheme Epic will use to complete the handshake between Epic and Qlik Sense.  QSTicketEpicModule is installed on the Qlik Sense server.

##Installation (compiling source)
1. Download the source by clicking the link above.
2. Fire up Visual Studio and open the project.
3. Right click on the QlikSenseEpic2015 project and choose properties.
4. In the properties panel, click on the Build tab.
5. In the general section for the Build, make sure x86 is set for the Platform target.
![Platform Target](./img/1.png)
6. In the output section for the Build, make sure the Register for COM interop box is checked.
![RegisterForCOMInterop](./img/2.png)


##Installation (using release package)
