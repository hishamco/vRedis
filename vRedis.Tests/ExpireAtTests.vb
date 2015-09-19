<TestClass()>
Public Class ExpireAtTests
    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub ExpireAt()
        client.ExpireAt("name", DateTime.Now)
        Assert.AreEqual(1, client.Return)
    End Sub
End Class