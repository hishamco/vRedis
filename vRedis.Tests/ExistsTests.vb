<TestClass()>
Public Class ExistsTests
    Private client As RedisClient
    Private reply As Boolean

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub CheckExistentKey()
        reply = client.Exists("name")
        Assert.IsTrue(reply)
    End Sub

    <TestMethod()>
    Public Sub CheckNonExistentKey()
        reply = client.Exists("position")
        Assert.IsFalse(reply)
    End Sub
End Class