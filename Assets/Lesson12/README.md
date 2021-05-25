# Async await & WebRequest

* link: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/

* Declare
```C#
using System.Threading.Tasks;
public static class ExtensionMethods
{
    public static TaskAwaiter GetAwaiter(this AsyncOperation asyncOp)
    {
        var tcs = new TaskCompletionSource<object>();
        asyncOp.completed += obj => { tcs.SetResult(null); };
        return ((Task)tcs.Task).GetAwaiter();
    }
}
```

* Usage
```C#
using UnityEngine.Networking;
private async void GetGoogle()
{
    var getRequest = UnityWebRequest.Get("http://www.google.com");
    await getRequest.SendWebRequest();
    var result = getRequest.downloadHandler.text;
    Debug.Log(result);
}
```