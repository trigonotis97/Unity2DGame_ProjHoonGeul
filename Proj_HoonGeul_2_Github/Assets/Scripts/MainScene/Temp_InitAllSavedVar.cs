using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_InitAllSavedVar : MonoBehaviour
{
    // Start is called before the first frame update
    public void InitAllSavedPlayerpref() { 
        PlayerPrefs.SetInt("BattleStageIndex", 0);
        PlayerPrefs.SetInt("DialogStageIndex", 0);
        PlayerPrefs.SetInt("SceneIndex", 0);
        PlayerPrefs.SetInt("RankModeScore", 0);
    }
}
