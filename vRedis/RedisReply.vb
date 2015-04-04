Friend Structure RedisReply
    Friend Property Type As RESPType

    Friend Property Value As Object

    Friend Sub New(type As RESPType, value As Object)
        Me.Type = type
        Me.Value = value
    End Sub
End Structure