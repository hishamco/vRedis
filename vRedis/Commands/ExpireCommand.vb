Namespace Commands
    Public Class ExpireCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "EXPIRE"
            End Get
        End Property

        Public Property Key As String

        Public Property Timeout As Integer

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"EXPIRE {Key} {Timeout}"
        End Function
    End Class
End Namespace