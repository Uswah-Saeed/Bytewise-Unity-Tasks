using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuController : MonoBehaviour
{
    
    public void PlayGame()
    {
        int selectedCahracter = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        GameManager.instance.CharIndex = selectedCahracter;
       

        SceneManager.LoadScene("GamePlay");
    }







}
