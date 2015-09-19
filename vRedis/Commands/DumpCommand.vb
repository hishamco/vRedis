Imports vRedis

Public Class DumpCommand
    Implements IRedisCommand

    Public ReadOnly Property Name As String Implements IRedisCommand.Name
        Get
            Return "DUMP"
        End Get
    End Property

    Public Property Key As String

    Public Function GetCommand() As String Implements IRedisCommand.GetCommand
        Return $"DUMP {Key}"
    End Function
End Class
