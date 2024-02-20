using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamBuilder : MonoBehaviour
{
    public List<string> team = new List<string>();
    //public List<Sprite> pokemonImages = new List<Sprite>();
    public TMP_Dropdown dropdown;
    public GameObject newObject;
    private GameObject[] allPokemon;
    GameObject PokemonDisplay;
    GameObject chosenPokemonImage;

    private int imageIndex = 0;

    private void Start()
    {
        allPokemon = new GameObject[newObject.transform.childCount];
        PokemonDisplay = GameObject.Find("PokemonDisplay");
        for (int i = 0; i < allPokemon.Length; i++)
        {
            allPokemon[i] = newObject.transform.GetChild(i).gameObject;
        }
    }

    public void ButtonClick()
    {
        SceneManager.LoadScene("TeamBuilder");
    }

    public void PokemonButtonClick()
    {
        if (!team.Contains(EventSystem.current.currentSelectedGameObject.name) && team.Count < 6)
        {
            team.Add(EventSystem.current.currentSelectedGameObject.name);
            for (int i = 0; i < allPokemon.Length; i++)
            {
                if (PokemonDisplay.transform.GetChild(imageIndex).childCount > 0)
                {
                    imageIndex++;
                }
                if (allPokemon[i].name == EventSystem.current.currentSelectedGameObject.name && PokemonDisplay.transform.GetChild(imageIndex).childCount == 0)
                {
                    ShowSelectedPokemon(i);
                }
            }
            Debug.Log(imageIndex);
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

    private void AddToDropwdown(string name)
    {
        dropdown.options.Add(new TMP_Dropdown.OptionData("Remove " + name));
        dropdown.RefreshShownValue();
    }

    public void RemovePokemon(int index)
    {
        team.RemoveAt(index);
        Destroy(PokemonDisplay.transform.GetChild(index).GetChild(0).gameObject);
        imageIndex = index;
        dropdown.options.RemoveAt(index);
        dropdown.RefreshShownValue();
    }

    private void ShowSelectedPokemon(int i)
    {
        chosenPokemonImage = new GameObject();
        chosenPokemonImage.AddComponent<Image>();
        chosenPokemonImage.GetComponent<Image>().sprite = allPokemon[i].transform.GetChild(0).GetComponent<Image>().sprite;
        //pokemonImages.Add(chosenPokemonImage.GetComponent<Image>().sprite);
        chosenPokemonImage.transform.SetParent(PokemonDisplay.transform.GetChild(imageIndex), worldPositionStays: false);
        AddToDropwdown(EventSystem.current.currentSelectedGameObject.name);
    }
}