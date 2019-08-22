using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConvStateHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer blackBack;
    public SpriteRenderer sunbiFace;
    public SpriteRenderer enemyFace;
    public SpriteRenderer sunbiChar, enemyChar;
    public GameObject EnemyRect;


    public void FaceImageUpload(string enemyWhole) //스테이지에 따른 적 캐릭터 얼굴 가져오는 함수. 다이얼로그 매니저 start단에서 실행. enemy rect 하위에 생성되는 적 캐릭 프리팹도 받아옴
    {
        enemyFace.sprite = Resources.Load("Face/" + enemyWhole) as Sprite;
        enemyChar = EnemyRect.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void Effect(string state) //다이얼로그매니저 넥스트센턴스에서 실행
    {
        Debug.Log(state);
        //선비
        switch (state[0])
        {
            case '0':
                // 선비 캐릭터 끄기, 얼굴도 끄기
                if (sunbiChar.enabled == true) sunbiChar.enabled = false;
                if (sunbiFace.enabled == true) sunbiFace.enabled = false;
                break;

            case '1':
                // 선비 캐릭터 키기, 얼굴 끄기
                if (sunbiChar.enabled == false) sunbiFace.enabled = true;
                if (sunbiFace.enabled == true) sunbiFace.enabled = false;
                break;

            case '2':
                // 선비 캐릭터 키기, 얼굴도 키기
                if (sunbiChar.enabled == false) sunbiChar.enabled = true;
                if (sunbiFace.enabled == false) sunbiFace.enabled = true;                
                break;
        }
        //적
        switch (state[1])
        {
            case '0':
                // 선비 캐릭터 끄기, 얼굴도 끄기
                if (enemyChar.enabled == true) enemyChar.enabled = false;
                if (enemyFace.enabled == true) enemyFace.enabled = false;
                break;

            case '1':
                // 선비 캐릭터 키기, 얼굴 끄기
                if (enemyChar.enabled == false) enemyFace.enabled = true;
                if (enemyFace.enabled == true) enemyFace.enabled = false;
                break;

            case '2':
                // 선비 캐릭터 키기, 얼굴도 키기
                if (enemyFace.enabled == false) enemyFace.enabled = true;
                if (enemyChar.enabled == false) enemyChar.enabled = true;
                break;
        }
        //배경
        switch (state[2])
        {
            case '0':
                if (blackBack.enabled == true) blackBack.enabled = false;
                break;
            case '1':
                if (blackBack.enabled == false) blackBack.enabled = true;
                break;
        }
    }
}
