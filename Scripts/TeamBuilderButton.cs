using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeamBuilderButton : MonoBehaviour
{
    public void ButtonClick()
    {
        SceneManager.LoadScene("TeamBuilder");
    }
}
