Namespace Commands
    Public Class SetCommand
        Implements IRedisCommand

        Public ReadOnly Property Name As String Implements IRedisCommand.Name
            Get
                Return "SET"
            End Get
        End Property

        Public Property Key As String

        Public Property Value As String

        Public Property ExpireTime As TimeSpan?

        Public Property Override As Boolean?

        Public Function GetCommand() As String Implements IRedisCommand.GetCommand
            If ExpireTime.HasValue Then
                If Override.HasValue Then
                    Return $"SET {Key} {Value} EX {ExpireTime.Value.TotalSeconds} {IIf(Override, "XX", "NX")}"
                Else
                    Return $"SET {Key} {Value} EX {ExpireTime.Value.TotalSeconds}"
                End If
            Else
                If Override.HasValue Then
                    Return $"SET {Key} {Value} {IIf(Override, "XX", "NX")}"
                Else
                    Return $"SET {Key} {Value}"
                End If
            End If
        End Function
    End Class
End Namespace