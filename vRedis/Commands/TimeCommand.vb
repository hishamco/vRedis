Namespace Commands
    Public Class TimeCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "TIME"
            End Get
        End Property

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            Return "TIME"
        End Function
    End Class
End Namespace