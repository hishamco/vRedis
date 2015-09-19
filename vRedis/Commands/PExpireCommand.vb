Namespace Commands
    Public Class PExpireCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "PEXPIRE"
            End Get
        End Property

        Public Property Key As String

        Public Property Timeout As Integer

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"PEXPIRE {Key} {Timeout}"
        End Function
    End Class
End Namespace