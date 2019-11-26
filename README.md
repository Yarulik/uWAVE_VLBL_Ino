# uWAVE_VLBL_Ino
uWAVE and Arduino UNO Virtual long baseline positioning demo application

This application demonstrates principles of underwater virtual long baseline navigation (positioning),
when a static responder's position can be estimated by a number of distance (time-of-flight, TOF) measurements
from different known locations.

Basically, the app parses an NMEA string from a serial port with following format:

### $PVLBL,ownLat,ownLon,ownDepth,ownBatV,targetDataID,targetDataValue,propagationTime,MSR

which comes from an Arduino UNO board, programmed with the following [sketch](https://github.com/ucnl/uWAVE_Arduino/blob/master/uWAVE_Example_3.ino)

There are a few extra items connected to the board:

- uWAVE underwater acoustic [modem](https://github.com/ucnl/Docs/tree/master/EN/Modems/uWAVE)
- any GNSS receiver with serial interface (9600 baud)
- any RF-module with serial interface (e.g. HC12, configured for 9600 baud)

The sketch parses GNSS receiver output (RMC sentence), measures propagation time to a remote uWAVE modem by
means of remote request, see [protocol specification](https://github.com/ucnl/Docs/blob/master/EN/Modems/uWAVE/uWAVE_Protocol_Specification_en.pdf)
and builds NMEA strings with the discussed format ($PVLBL), where:

- ownLat - GNSS latitude
- ownLon - GNSS longitude
- ownDepth - depth from the local uWAVE modem
- ownBatV - battery voltage from the local uWAVE modem
- targetDataID - ID of the value, requested from the remote uWAVE modem
- targetDataValue - value, requested from the remote uWAVE modem
- propagationTime - the time of underwater acoustic signal propagation between the local and the remote modems
- MSR - main peak to sidelobe ratio of the remote answer in dB (values more than 17 dB are good)  

All the positioning algorithms are implemented in [UCNLNav library](https://github.com/ucnl/UCNLNav)  
Also, to build this project you will need some extra libraries:
- https://github.com/ucnl/UCNLNMEA (building and parsing NMEA strings)
- https://github.com/ucnl/UCNLDrivers (serial port extra stuff)
- https://github.com/ucnl/UCNLUI (extra UI items)
- https://github.com/ucnl/UCNLKML (KML format support)
- https://github.com/ucnl/uWAVELib (uWAVE underwater acoustic modem support)
- https://github.com/ucnl/UCNLPhysics (some basic routines to estimate sound speed in the water, gravity constant, etc.)
