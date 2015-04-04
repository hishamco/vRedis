Namespace Commands
    Public Class GetCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "GET"
            End Get
        End Property

        Public Property Key As String

        Private Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"GET {Key}"
        End Function
    End Class
End Namespace