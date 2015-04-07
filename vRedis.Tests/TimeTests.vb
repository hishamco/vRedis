<TestClass()>
Public Class TimeTests
    Private client As RedisClient
    Private reply As Date

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub GetTime()
        reply = client.Time()
        Assert.AreEqual(Date.Now.ToShortTimeString(), reply.ToShortTimeString())
    End Sub
End Class