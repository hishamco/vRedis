Namespace Commands
    Public Class ExpireAtCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "EXPIREAT"
            End Get
        End Property

        Public Property Key As String

        Public Property TTL As Long

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"EXPIREAT {Key} {TTL}"
        End Function
    End Class
End Namespace