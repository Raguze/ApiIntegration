using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient
{
    //https://www.dnd5eapi.co/api/equipment/greatsword
    protected string baseUrl;

    public ApiClient(string baseUrl) {
        this.baseUrl = baseUrl;
    }

    protected string BuildUrl(string arg) {
        return $"{this.baseUrl}/{arg}";
    }

    protected T Serialize<T>(string data) {
        var obj = JsonUtility.FromJson<T>(data);
        return obj;
    }

    public IEnumerator DispatchRequest<T>(UnityWebRequest request, System.Action<T> onData) {

        Debug.Log("Before Send");
        yield return request.SendWebRequest();

        // Trata a resposta
        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log($"Response InProgress {request.responseCode} {request.uri}");
                break;

            case UnityWebRequest.Result.Success:
                var text = request.downloadHandler.text;
                Debug.Log($"Response Success {text}");
                onData(Serialize<T>(text));
                break;

            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.ProtocolError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log($"Response Error {request.responseCode} {request.uri} {request.result} {request.error}");
                break;

            default:
                Debug.Log($"Response Result undefined");
                break;
        }
    }

    public IEnumerator _DispatchRequest() {
        // Configura e cria a request
        var request = UnityWebRequest.Get($"{this.baseUrl}/equipment/greatsword");

        // Envia e espera a resposta
        yield return request.SendWebRequest();

        // Trata a resposta
        switch (request.result)
        {
            case UnityWebRequest.Result.InProgress:
                Debug.Log($"Response InProgress {request.responseCode} {request.uri}");
                break;

            case UnityWebRequest.Result.Success:
                Debug.Log($"Response Success {request.downloadHandler.text}");
                break;

            case UnityWebRequest.Result.ConnectionError:
            case UnityWebRequest.Result.ProtocolError:
            case UnityWebRequest.Result.DataProcessingError:
                Debug.Log($"Response Error {request.responseCode} {request.uri} {request.result} {request.error}");
                break;

            default:
                Debug.Log($"Response Result undefined");
                break;
        }
    }
}
