<TestClass()>
Public Class PingTests
    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub Ping()
        client.Ping()
        Assert.AreEqual("PONG", client.Return)
    End Sub
End Class