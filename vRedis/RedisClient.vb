Imports System.Net.Sockets
Imports System.Text
Imports vRedis.Commands

Public Class RedisClient
    Private client As TcpClient
    Private stream As NetworkStream
    Private reply As RedisReply
    Private command As IRedisCommand

    Public ReadOnly Property Host As String

    Public ReadOnly Property Port As Integer

    Public ReadOnly Property [Return] As Object
        Get
            Return reply.Value
        End Get
    End Property

    Public Sub New(Optional host As String = "127.0.0.1", Optional port As Integer = 6379)
        If IsNothing(host) Then
            Throw New ArgumentNullException(NameOf(host))
        End If
        Me.Host = host
        Me.Port = port
        client = New TcpClient()
        Try
            client.Connect(host, port)
            stream = client.GetStream()
        Catch ex As Exception
            Throw New RedisException("An existing connection was forcibly closed by remote host.")
        End Try
    End Sub

    Public Sub Append(key As String, value As String)
        command = New AppendCommand() With {.Key = key, .Value = value}
        Execute(command)
    End Sub

    Public Sub Del(ParamArray keys() As String)
        command = New DelCommand() With {.Keys = keys}
        Execute(command)
    End Sub

    Public Function Dump(key As String) As Byte()
        command = New DumpCommand() With {.Key = key}
        Execute(command)
        If IsNothing(reply.Value) Then
            Return Nothing
        Else
            Return Encoding.UTF8.GetBytes(reply.Value)
        End If
    End Function

    Public Sub Echo(message As String)
        command = New EchoCommand() With {.Message = message}
        Execute(command)
    End Sub

    Public Function Exists(key As String) As Boolean
        command = New ExistsCommand() With {.Key = key}
        Execute(command)
        Return reply.Value
    End Function

    Public Sub Expire(key As String, timeout As Integer)
        command = New ExpireCommand() With {.Key = key, .Timeout = timeout}
        Execute(command)
    End Sub

    Public Sub ExpireAt(key As String, ttl As DateTime)
        command = New ExpireAtCommand() With {.Key = key, .TTL = (ttl - #1/1/1970#).TotalSeconds}
        Execute(command)
    End Sub

    Public Function [Get](key As String) As String
        command = New GetCommand() With {.Key = key}
        Execute(command)
        Return reply.Value
    End Function

    Public Sub PExpire(key As String, timeout As Integer)
        command = New PExpireCommand() With {.Key = key, .Timeout = timeout}
        Execute(command)
    End Sub

    Public Sub PExpireAt(key As String, ttl As DateTime)
        command = New PExpireAtCommand() With {.Key = key, .TTL = (ttl - #1/1/1970#).TotalMilliseconds}
        Execute(command)
    End Sub

    Public Sub Ping()
        command = New PingCommand()
        Execute(command)
    End Sub

    Public Sub [Set](key As String, value As Object, Optional expireTime As TimeSpan? = Nothing, Optional override As Boolean? = Nothing)
        command = New SetCommand() With {.Key = key, .Value = value, .ExpireTime = expireTime, .Override = override}
        Execute(command)
    End Sub

    Public Function Time() As Date
        command = New TimeCommand()
        Execute(command)
        Return #1/1/1970#.AddSeconds(reply.Value(0)).ToLocalTime()
    End Function

    Private Sub Execute(command As IRedisCommand)
        Dim bytes() As Byte = Encoding.UTF8.GetBytes(command.GetCommand() & vbCrLf)
        Try
            stream.Write(bytes, 0, bytes.Length)
            stream.Flush()
            ReDim bytes(client.ReceiveBufferSize)
            stream.Read(bytes, 0, bytes.Length)
            Dim result = Encoding.UTF8.GetString(bytes)
            Select Case result(0)
                Case "$"
                    Dim length = Convert.ToInt32(result.Substring(1, result.IndexOf(vbCrLf) - 1))
                    If length = -1 Then
                        reply = New RedisReply(RESPType.BulkString, Nothing)
                    Else
                        reply = New RedisReply(RESPType.BulkString, result.Substring(result.IndexOf(vbCrLf) + 2, length))
                    End If
                Case "+"
                    reply = New RedisReply(RESPType.SimpleString, result.Substring(1, result.IndexOf(vbCrLf) - 1))
                Case ":"
                    reply = New RedisReply(RESPType.Integer, Convert.ToInt32(result.Substring(1, result.IndexOf(vbCrLf) - 1)))
                Case "-"
                    reply = New RedisReply(RESPType.Error, result.Substring(1, result.IndexOf(vbCrLf) - 1))
                    Throw New RedisException(reply.Value)
                Case "*"
                    Dim count = Convert.ToInt32(result.Substring(1, result.IndexOf(vbCrLf) - 1))
                    Dim items = result.Split(New Char() {vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries).ToList()
                    items.RemoveAt(0)
                    items.RemoveAll(Function(i) i.StartsWith("$"))
                    items.RemoveAt(items.Count - 1)
                    reply = New RedisReply(RESPType.Array, items)
            End Select
        Catch ex As Exception
            Throw New RedisException($"There is an internal error during executing '{command.GetCommand()}'.")
        End Try
    End Sub
End Class