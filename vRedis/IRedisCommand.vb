Public Interface IRedisCommand
    ReadOnly Property Name As String

    Function GetCommand() As String
End Interface