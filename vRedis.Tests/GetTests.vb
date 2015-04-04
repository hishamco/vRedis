<TestClass()>
Public Class GetTests
    Private client As RedisClient
    Private reply As String

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub GetValue()
        reply = client.Get("name")
        Assert.AreEqual("scott", reply)
    End Sub

    <TestMethod()>
    Public Sub GetValueForNonExistKey()
        reply = client.Get("level")
        Assert.IsNull(reply)
    End Sub
End Class