<TestClass()>
Public Class SetTests

    Private client As RedisClient

    <TestInitialize()>
    Public Sub Setup()
        client = New RedisClient()
    End Sub

    <TestMethod()>
    Public Sub SetKeyValue()
        client.Set("name", "John")
        Assert.AreEqual("OK", client.Return)
    End Sub

    <TestMethod()>
    Public Sub SetKeyWithExpirationTime()
        client.Set("age", "21", TimeSpan.FromSeconds(5))
        Assert.AreEqual("OK", client.Return)
    End Sub

    <TestMethod()>
    Public Sub SetExistentKey()
        client.Set("name", "John", override:=True)
        Assert.AreEqual("OK", client.Return)
    End Sub

    <TestMethod()>
    Public Sub SetNonExistentKey()
        client.Set("gender", "male", override:=False)
        Assert.IsNull(client.Return)
    End Sub

    <TestMethod()>
    Public Sub SetExistentKeyWithExpirationTime()
        client.Set("name", "Scott", TimeSpan.FromMilliseconds(3000), True)
        Assert.AreEqual("OK", client.Return)
    End Sub

End Class