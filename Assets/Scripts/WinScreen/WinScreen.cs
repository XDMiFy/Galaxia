using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
   public void CloseGame(){
    Application.Quit();
   }
   public void Restart(){
    SceneManager.LoadSceneAsync(ScreenIDs.GameSceneID);
   }
}
