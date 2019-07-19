using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    GameManager m_gameManager;
    public int show_chapter_num;
    public int show_stage_num;

    DialogData m_data;
    BattleSceneData m_battledata;

    StageState stageStatus;
    public GameObject m_canvas;

    enum StageState
    {
        READY,
        DIALOGPLAYING,
        DIALOGEND
    }

    GameObject m_enemy;
    public SpriteRenderer m_enemyImage;
    public SpriteRenderer bg_image;
    AudioClip bg_audioclip;

    Dialog2 m_script;

    public GameObject enemyImg;
    AudioSource m_audio;

    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_script = GameObject.Find("ScriptGenerator").GetComponent<Dialog2>();
        m_audio=GetComponent<AudioSource>();
    }

    private void Start()
    {
        stageStatus = StageState.READY;

        m_data = m_gameManager.GetDialogData();
        m_battledata = m_gameManager.GetBattleSceneData();
        m_script.SetScriptloader(m_data.script, m_data.conv_state);

        show_chapter_num = m_data.chapterNum;
        show_stage_num = m_data.stageNum;

        //m_enemyImage.sprite = Resources.Load("Background/" + m_data.BGImage, typeof(Sprite)) as Sprite;

        Debug.Log("Background/" + m_data.BGImage);
        bg_image.sprite = Resources.Load("Background/" + m_data.BGImage, typeof(Sprite)) as Sprite;
       // Debug.Log(m_gameManager.GetCurrentDialogKey());
        m_gameManager.SetCurrentDialogKey(m_gameManager.GetCurrentDialogKey() + 1);
        
        if (!m_battledata.isBoss)
        {
            GameObject tempEnemy = Resources.Load("EnemyPref/Mob_" + m_battledata.enemyPrefab.ToString())as GameObject;
            
            m_enemy = Instantiate(enemyImg, new Vector3(507.392f, 405.248f, -9000f), transform.rotation)as GameObject;
            m_enemy.GetComponent<SpriteRenderer>().sprite = tempEnemy.GetComponent<SpriteRenderer>().sprite;
        }
        else
        {
            GameObject tempEnemy = Resources.Load("EnemyPref/Mob_" + m_battledata.enemyPrefab.ToString()) as GameObject;
            enemyImg.GetComponent<SpriteRenderer>().sprite = tempEnemy.GetComponent<SpriteRenderer>().sprite;
            m_enemy = Instantiate(enemyImg, new Vector3(507.392f, 405.248f, -9000f), transform.rotation) as GameObject;
            //m_enemy = Instantiate(Resources.Load("EnemyPref/Boss_" + m_data.enemyPrefab.ToString()) as GameObject, new Vector3(507.392f, 405.248f, -9000f), transform.rotation) as GameObject;
        }
        //m_enemy.GetComponent<EnemyScriptDefault>().enabled = false;
        m_enemy.transform.SetParent(m_canvas.transform, false);
        
        bg_audioclip = Resources.Load("BGM/" + m_data.BGM) as AudioClip;
        m_audio.clip = bg_audioclip;
        
        m_audio.Play();
        m_audio.loop = true;
    }

    public void SetStateDialogEnd()
    {
        stageStatus = StageState.DIALOGEND;

    }
    public int GetChapterNum()
    {
        return m_data.chapterNum;
    }

    public void NextScene()
    {
        //m_gameManager.SetCurrentDialogKey(m_data.nextSceneKey);
        //m_gameManager.SetCurrentDialogKey(m_gameManager.GetCurrentDialogKey() + 1);
        if (m_data.isNextBattle == true)
        {
            SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("DialogScene", LoadSceneMode.Single);
        }
    }
}
