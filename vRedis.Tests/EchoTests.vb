<TestClass()>
Public Class EchoTests
    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub Echo()
        client.Echo("Redis")
        Assert.AreEqual("Redis", client.Return)
    End Sub
End Class