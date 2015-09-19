Namespace Commands
    Public Class PExpireAtCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "PEXPIREAT"
            End Get
        End Property

        Public Property Key As String

        Public Property TTL As Long

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"PEXPIREAT {Key} {TTL}"
        End Function
    End Class
End Namespace