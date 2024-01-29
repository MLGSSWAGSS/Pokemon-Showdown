using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamBuilder : MonoBehaviour
{
    public List<string> team = new List<string>();
    public void ButtonClick()
    {
        SceneManager.LoadScene("TeamBuilder");
    }

    public void PokemonButtonClick()
    {
        if (!team.Contains(EventSystem.current.currentSelectedGameObject.name) && team.Count < 6)
        {
            team.Add(EventSystem.current.currentSelectedGameObject.name);
            Debug.Log("Team has been updated with " + EventSystem.current.currentSelectedGameObject.name);
            Debug.Log("Team: " + team.ToString());
        }
        else
        {
            Debug.Log("Team already contains: " + EventSystem.current.currentSelectedGameObject.name);
        }
        
    }

    public void SaveButtonClick()
    {
        SaveTeam.SaveNewTeam(this);
    }

    public void LoadButtonClick()
    {
        TeamData loadTeam = SaveTeam.LoadTeam();
        team = loadTeam.team;
    }
}