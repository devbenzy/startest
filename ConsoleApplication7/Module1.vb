Imports ConsoleApplication7.com.zapways.ogtest
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.IO


Module Module1

    Sub Main()
        Try
            Dim ObjectResponse = New AirLowFareSearchResult()
            Dim ObjectRequest As airLowFareSearchRQ = New airLowFareSearchRQ()


            Dim StartTime As DateTime
            Dim Runlength As System.TimeSpan

            Dim paxcount As String = Nothing
            Dim i As Integer = 0

            StartTime = DateTime.Now
            ObjectRequest.TimeStamp = System.DateTime.Now

            'Values required in object Request is filled from here 
            ReDim Preserve ObjectRequest.POS(0)

            ObjectRequest.POS(0) = New SourceType

            ObjectRequest.POS(0).ERSP_UserID = "1007/918CC5792B0BC13D4E0BC95173F6505109"
            ObjectRequest.POS(0).RequestorID = New SourceTypeRequestorID
            ObjectRequest.POS(0).RequestorID.ID = "AkbarTravels"
            ObjectRequest.POS(0).RequestorID.MessagePassword = "Un5QBwqdakNr"
            ObjectRequest.POS(0).RequestorID.Type = "29"

            ReDim Preserve ObjectRequest.OriginDestinationInformation(0)
            ObjectRequest.OriginDestinationInformation(0) = New airLowFareSearchRQOriginDestinationInformation
            ObjectRequest.OriginDestinationInformation(0).OriginLocation = New OriginDestinationInformationTypeOriginLocation
            ObjectRequest.OriginDestinationInformation(0).OriginLocation.LocationCode = "BLR"
            ObjectRequest.OriginDestinationInformation(0).DestinationLocation = New OriginDestinationInformationTypeDestinationLocation
            ObjectRequest.OriginDestinationInformation(0).DestinationLocation.LocationCode = "IXG"
            ObjectRequest.OriginDestinationInformation(0).DepartureDateTime = New TimeInstantType
            ObjectRequest.OriginDestinationInformation(0).DepartureDateTime.Value = "2019-07-10"

            ObjectRequest.TravelerInfoSummary = New airLowFareSearchRQTravelerInfoSummary()
            ReDim Preserve ObjectRequest.TravelerInfoSummary.AirTravelerAvail(i)
            ObjectRequest.TravelerInfoSummary.AirTravelerAvail(i) = New PassengerTypeQuantityType
            ObjectRequest.TravelerInfoSummary.AirTravelerAvail(0).Code = "ADT"
            ObjectRequest.TravelerInfoSummary.AirTravelerAvail(0).Quantity = 1

            ' Object Request Successfully filled 

            Dim AvailablityRequest = New IOTA_Air
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 Or SecurityProtocolType.Tls11 Or SecurityProtocolType.Tls Or SecurityProtocolType.Ssl3
            Dim cert As X509Certificate2
            Dim cdata() = File.ReadAllBytes("cert.pfx")  ' Certificate is read 

            cert = New X509Certificate2(cdata, "123456") ' certificate value and password is passed 
            AvailablityRequest.Credentials = CredentialCache.DefaultCredentials
            AvailablityRequest.ClientCertificates.Add(cert)
            'AvailablityRequest.PreAuthenticate = True
            ObjectResponse = AvailablityRequest.AirLowFareSearch(ObjectRequest)   ' Provider service  is called 


        Catch ex As Exception

            GoTo ErrorHandler
        End Try
        Exit Sub
ErrorHandler:
        Reset()

    End Sub

End Module
