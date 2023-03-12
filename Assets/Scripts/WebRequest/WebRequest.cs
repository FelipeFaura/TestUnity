using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Linq;

public class WebRequest : MonoBehaviour
{
    private string url = "https://testinterview.free.beeceptor.com/test/companies";
    private string urlLatch = "https://latch.elevenpaths.com/";
    private Dictionary<string, IUserData> data = new Dictionary<string, IUserData>();
    void Start()
    {
        StartCoroutine(GetRequest());
    }

    IEnumerator GetRequest()
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        yield return webRequest.SendWebRequest();
        string dataText = webRequest.downloadHandler.text;
        // uso de newtonSoft porque JsonUtility no es capaz de Deserializar una colección de objetos.
        List<IUserData> fromJson = JsonConvert.DeserializeObject<List<IUserData>>(dataText);
        foreach (var item in fromJson)
        {
            data.Add(item.user, item);
        }
        StartCoroutine(AccessWeb());
    }

    IEnumerator AccessWeb()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", data.First().Key);
        form.AddField("password", data.First().Value.name);

        UnityWebRequest webRequest = UnityWebRequest.Post(url + "www/login", form);

        yield return webRequest.SendWebRequest();
        switch (webRequest.result)
        {
            case UnityWebRequest.Result.ConnectionError:
                Debug.Log(webRequest.error);
                break;
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log(webRequest.error);
                break;
            case UnityWebRequest.Result.ProtocolError:
                Debug.Log(webRequest.error);
                break;
            case UnityWebRequest.Result.Success:
                Debug.Log(webRequest.downloadHandler.text);
                break;
        }
    }
}