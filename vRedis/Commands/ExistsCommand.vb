Namespace Commands
    Public Class ExistsCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "EXISTS"
            End Get
        End Property

        Public Property Key As String

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"EXISTS {Key}"
        End Function
    End Class
End Namespace