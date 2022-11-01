using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private DnDApiClient dndApiClient;

    public DTO.AbilityScore abilityScore;

    public DTO.Skill skill;

    private void Awake() {
        dndApiClient = new DnDApiClient("https://www.dnd5eapi.co/api");


        // StartCoroutine(dndApiClient.GetEquipment("greatsword",(data) => {
        //     Debug.Log($"GameController {data}");
        //     abilityScore = JsonUtility.FromJson<DTO.AbilityScore>(data);
        // }));

        StartCoroutine(dndApiClient.GetAbilityScores("cha",(data) => {
            abilityScore = data;
        }));

        StartCoroutine(dndApiClient.GetSkill("acrobatics", (data) =>
        {
            skill = data;
        }));

    }
}
