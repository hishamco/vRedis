Namespace Commands
    Public Class DelCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "DEL"
            End Get
        End Property

        Public Property Keys As String()

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"DEL {String.Join(" ", Keys)}"
        End Function
    End Class
End Namespace