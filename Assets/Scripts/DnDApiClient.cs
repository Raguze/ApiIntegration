using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
public class DnDApiClient : ApiClient {
    public DnDApiClient(string baseUrl) : base(baseUrl) { }

    public IEnumerator GetEquipment(string index, System.Action<object> onData) {
        var request = UnityWebRequest.Get(BuildUrl($"/equipment/{index}"));
        return DispatchRequest<object>(request,(data) => {
            Debug.Log($"Data {data}");
            onData(data);
        });
    }

    public IEnumerator GetAbilityScores(string index, System.Action<DTO.AbilityScore> onData) {
        var request = UnityWebRequest.Get(BuildUrl($"/ability-scores/{index}"));
        return DispatchRequest<DTO.AbilityScore>(request,(data) => {
            Debug.Log($"Data {data}");
            onData(data);
        });
    }

    public IEnumerator GetSkill(string index, System.Action<DTO.Skill> onData) {
        var request = UnityWebRequest.Get(BuildUrl($"/skills/{index}"));
        return DispatchRequest<DTO.Skill>(request, (data) =>
        {
            onData(data);
        });
    }
}