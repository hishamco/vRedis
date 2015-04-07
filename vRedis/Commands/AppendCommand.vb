Namespace Commands
    Public Class AppendCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "APPEND"
            End Get
        End Property

        Public Property Key As String

        Public Property Value As String

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return $"APPEND {Key} {Value}"
        End Function
    End Class
End Namespace