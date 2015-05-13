<TestClass()>
Public Class DelTests
    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub DeleteKey()
        client.Del("name")
        Assert.AreEqual(1, client.Return)
    End Sub

    <TestMethod()>
    Public Sub DeleteMultipleKeys()
        client.Del("name", "age")
        Assert.AreEqual(2, client.Return)
    End Sub
End Class