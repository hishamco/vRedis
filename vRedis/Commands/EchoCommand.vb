Namespace Commands
    Public Class EchoCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "ECHO"
            End Get
        End Property

        Public Property Message As String

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"ECHO {Message}"
        End Function
    End Class
End Namespace