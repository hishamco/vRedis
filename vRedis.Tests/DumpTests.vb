<TestClass()>
Public Class DumpTests
    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub Dump()
        client.Dump("name")
        Assert.IsNotNull(client.Return)
    End Sub
End Class