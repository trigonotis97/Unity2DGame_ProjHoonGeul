using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    GameManager m_gameManager;
    int currentGameMode;
    public int show_chapter_num;
    public int show_stage_num;

    DialogData m_data;
    SceneData sceneData;

    StageState stageStatus;
    public GameObject m_canvas;

    //다음 씬으로 넘기기을 위한 변수
    public SceneChange sceneChanger;


    enum StageState
    {
        READY,
        DIALOGPLAYING,
        DIALOGEND
    }

    GameObject m_enemy;
    public SpriteRenderer m_enemyImage;
    //public SpriteRenderer bg_image;
    public Image bg_image_;
    AudioClip bg_audioclip;

    Dialog2 m_script;

    public GameObject enemyImg;
    AudioSource m_audio;

    public ConvStateHandler convStateHandler;

    //연습모드 변수
    //PracticeManager m_practiceManager;
    private void Awake()
    {
        m_gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        m_script = GameObject.Find("DialogGenerator").GetComponent<Dialog2>();
        m_audio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        currentGameMode = m_gameManager.GetGameMode();
        //데이터 초기화
        if ((currentGameMode == 1) || (currentGameMode == 2))
        {
            m_gameManager.SetCurrentSceneKey(m_gameManager.GetCurrentSceneKey() + 1);

            stageStatus = StageState.READY;

            sceneData = m_gameManager.GetSceneIndData(currentGameMode);

            m_data = m_gameManager.GetDialogData(currentGameMode);
        }
        else if(currentGameMode==3)//연습모드일떄
        {
            m_data = m_gameManager.GetDialogData(currentGameMode);

        }
        m_script.SetScriptloader(m_data.script, m_data.conv_state);

        show_chapter_num = m_data.chapterNum;
        show_stage_num = m_data.stageNum;

        Debug.Log("Background/" + m_data.BGImage);
        bg_image_.sprite = Resources.Load("Background/" + m_data.BGImage, typeof(Sprite)) as Sprite;

        //GameObject tempEnemy = Resources.Load("EnemyPref/Mob_" + m_data.enemyWholeImage.ToString())as GameObject;
        //m_enemy = Instantiate(enemyImg, new Vector3(507.392f, 405.248f, -9000f), transform.rotation)as GameObject;
        //m_enemy.GetComponent<SpriteRenderer>().sprite = tempEnemy.GetComponent<SpriteRenderer>().sprite;

        GameObject tempEnemy = Resources.Load("DialogPref/Mob_" + m_data.enemyWholeImage.ToString() + " Variant") as GameObject;
        m_enemy = Instantiate(tempEnemy, new Vector3(0f, 0f, 0f), transform.rotation) as GameObject;
        m_enemy.transform.Translate(new Vector3(-m_enemy.GetComponent<SpriteRenderer>().bounds.size.x / 2, m_enemy.GetComponent<SpriteRenderer>().bounds.size.y / 2, 0));

        m_enemy.transform.SetParent(m_canvas.transform, false);


        bg_audioclip = Resources.Load("BGM/" + m_data.BGM) as AudioClip;
        m_audio.clip = bg_audioclip;

        m_audio.Play();
        m_audio.loop = true;

        convStateHandler.FaceImageUpload(m_data.enemyImage);
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
        if ((currentGameMode == 1)|| (currentGameMode == 2))//스토리모드일경우 ( 맑은물, 고인물)
        {
            sceneChanger.NextScene();
        }
        else if(currentGameMode==3)//연습모드일경우
        {
            bool isWinState = m_gameManager.GetIsWinState();
            if (isWinState)//이겼을때
            {
                SceneManager.LoadScene("LastStoryMode");
                m_gameManager.SetGameMode(0);
            }
            else//처음 시작부분일때
            {
                sceneChanger.NextScene();
            }
        }
    }
}
