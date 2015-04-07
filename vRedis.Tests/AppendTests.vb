<TestClass()>
Public Class AppendTests
    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub Append()
        client.Append("name", "athan")
        Assert.AreEqual(8, client.Return)
    End Sub
End Class