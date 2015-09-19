<TestClass()>
Public Class PExpireTests
    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub PExpire()
        client.PExpire("name", 10)
        Assert.AreEqual(1, client.Return)
    End Sub
End Class