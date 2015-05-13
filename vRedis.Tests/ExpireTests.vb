<TestClass()>
Public Class ExpireTests
    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub Expire()
        client.Expire("name", 10)
        Assert.AreEqual(1, client.Return)
    End Sub
End Class