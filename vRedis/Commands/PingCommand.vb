Namespace Commands
    Public Class PingCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "PING"
            End Get
        End Property

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return "PING"
        End Function
    End Class
End Namespace