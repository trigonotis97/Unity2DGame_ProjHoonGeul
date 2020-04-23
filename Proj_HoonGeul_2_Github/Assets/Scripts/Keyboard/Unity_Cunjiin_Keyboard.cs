using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unity_Cunjiin_Keyboard : MonoBehaviour
{
    public AudioClip m_audioEffect;
    AudioSource m_audio;

    public Button[] buttonTable = new Button[13];

    //public InputField inputField;

    /*
    public class Chunjiin
    {
    */
    private static int HANGUL = 0;
    //private static int UPPER_ENGLISH = 1;
    //private static int ENGLISH = 2;
    //private static int NUMBER = 3;

    private Button[] btn;
    public InputField inputfield;
    private int now_mode = HANGUL;
    public Text inputText;
    public GameObject sideCursor, underCursor;
    RectTransform underCursor_rect, sideCursor_rect;

    //디버깅용 키보드 입력받기
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            onClick(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            onClick(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            onClick(3);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            onClick(4);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            onClick(5);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            onClick(6);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            onClick(7);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            onClick(8);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            onClick(9);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            onClick(11);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            onClick(10);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            onClick(0);
        }
    }

    private void Start()
    {
        m_audio = GetComponent<AudioSource>();
        m_audio.clip = m_audioEffect;
        //inputfield.ActivateInputField

        Init_cursor();
    }
    public void Init_cursor()
    {
        underCursor_rect = underCursor.GetComponent<RectTransform>();
        sideCursor_rect = sideCursor.GetComponent<RectTransform>();

        RenderCursor(false);
    }

    public void Enter()
    {
        m_audio.PlayOneShot(m_audioEffect);
        hangul = new Hangul();
        //hangul.chosung = hangul.jungsung = hangul.jongsung = hangul.jongsung2 = "";
        Init_cursor();
    }
    public void RenderCursor(bool is_writing)
    {
        if (is_writing)
        {
            sideCursor.SetActive(false);
            underCursor.SetActive(true);
            underCursor_rect.anchoredPosition = new Vector3(inputText.preferredWidth - 128, 0, 0);           
        }
        else
        {
            sideCursor.SetActive(true);
            underCursor.SetActive(false);
            sideCursor_rect.anchoredPosition = new Vector3(inputText.preferredWidth - 128, 0, 0);
        }
    }
    public void DisableCursors()
    {
        sideCursor.SetActive(false);
        underCursor.SetActive(false);
    }

    private class Hangul
    {

        public string chosung = "";
        public string jungsung = "";
        public string jongsung = "";
        public string jongsung2 = "";
        public int step = 0;
        public bool flag_writing = false;
        public bool flag_dotused = false;
        public bool flag_doubled = false;
        public bool flag_addcursor = false;
        //private bool flag_space = false;
        public bool flag_space = false;
        public void init()
        {
            this.chosung = "";
            this.jungsung = "";
            this.jongsung = "";
            this.jongsung2 = "";
            this.step = 0;
            this.flag_writing = false;
            this.flag_dotused = false;
            this.flag_doubled = false;
            this.flag_addcursor = false;
            this.flag_space = false;
        }
    }
    Hangul hangul = new Hangul();

    private string engnum = "";
    private bool flag_initengnum = false;
    private bool flag_engdelete = false;
    private bool flag_upper = true;



    //void onClick 전용 함수

    public void onClick(int i)
    {
        int input = i;
        
        if (input == -1)
            return;
        if (now_mode == HANGUL)
            hangulMake(input);

        m_audio.PlayOneShot(m_audioEffect);
        write(now_mode);

        RenderCursor(hangul.flag_writing);

    }


    /*
    public Chunjiin(InputField editText, Button [] bt)
    {
        et = editText;
        //et.setOnTouchListener(otl); //*************
        //setButton(bt); //*************
    }
    */

    /*
    private void setButton(Button[] inputbtn)
    {

        btn = inputbtn;
        for (int i = 0; i < 12; i++)
            btn[i].setOnClickListener(btnlistner);
        btn[12].setOnClickListener(btnchglistner);
        setBtnText(now_mode);

}*/
    //리스너 - 버튼할당
    /*
    private OnTouchListener otl = new OnTouchListener()
    {


    public bool onTouch(View v, MotionEvent event) {
        v.onTouchEvent(event);
    InputMethodManager imm = (InputMethodManager) v.getContext().getSystemService(Context.INPUT_METHOD_SERVICE);
        if (imm != null)
            imm.hideSoftInputFromWindow(v.getWindowToken(), 0);

        hangul.init();
        init_engnum();
        return true;
    }
}
*/

    ///버튼 할당 (초기화 )
    /*
   private  OnClickListener btnlistner = new OnClickListener()
   {


           public void onClick(View v)
       {
           int input = -1;
           switch (v.getId())
           {
               case R.id.chunjiin_button0: input = 0; break;
               case R.id.chunjiin_button1: input = 1; break;
               case R.id.chunjiin_button2: input = 2; break;
               case R.id.chunjiin_button3: input = 3; break;
               case R.id.chunjiin_button4: input = 4; break;
               case R.id.chunjiin_button5: input = 5; break;
               case R.id.chunjiin_button6: input = 6; break;
               case R.id.chunjiin_button7: input = 7; break;
               case R.id.chunjiin_button8: input = 8; break;
               case R.id.chunjiin_button9: input = 9; break;
               case R.id.chunjiin_buttonex1: input = 10; break;
               case R.id.chunjiin_buttonex2: input = 11; break;
           }
           if (input == -1)
               return;
           if (now_mode == HANGUL)
               hangulMake(input);
           else if ((now_mode == ENGLISH || now_mode == UPPER_ENGLISH))
               engMake(input);
           else // if(now_mode == NUMBER)
               numMake(input);

           write(now_mode);
       }
   }

   private  OnClickListener btnchglistner = new OnClickListener()
   {
       @Override

           public void onClick(View v)
       {
           now_mode = (now_mode == NUMBER) ? HANGUL : now_mode + 1;
           setBtnText(now_mode);

           hangul.init();
           init_engnum();
       }
   };
   */
    private void init_engnum()
    {
        engnum = "";
        flag_initengnum = false;
        flag_engdelete = false;
    }
    private void write(int mode)
    {
        //int position = et.getSelectionStart();
        int position = inputfield.caretPosition;
        string origin = "";
        string str = "";
        //origin = et.getText().tostring();
        origin = inputfield.text;

        if (mode == HANGUL)
        {
            bool dotflag = false;
            bool doubleflag = false;
            bool spaceflag = false;
            bool impossiblejongsungflag = false;
            char unicode;
            string real_jongsung = checkDouble(hangul.jongsung, hangul.jongsung2);
            if (real_jongsung.Length == 0)
            {
                real_jongsung = hangul.jongsung;
                if (hangul.jongsung2.Length != 0)
                    doubleflag = true;
            }

            //bug fixed, 16.4.22 ~
            //added impossible jongsungflag.
            if (hangul.jongsung == "ㅃ" || hangul.jongsung == "ㅉ" || hangul.jongsung == "ㄸ")
            {
                doubleflag = true;
                impossiblejongsungflag = true;
                unicode = (char)getUnicode("");
            }
            else
                unicode = (char)getUnicode(real_jongsung);
            // ~ bug fixed, 16.4.22

            if (!hangul.flag_writing)
                str += origin.Substring(0, position);
            else if (hangul.flag_dotused)
            {
                if (hangul.chosung.Length == 0)
                    str += origin.Substring(0, position - 1);
                else
                    str += origin.Substring(0, position - 2);
            }
            else if (hangul.flag_doubled)
                str += origin.Substring(0, position - 2);
            else
                str += origin.Substring(0, position - 1);


            if (unicode != 0)
                //str += string.valueOf(unicode);
                str += unicode.ToString();
            if (hangul.flag_space)
            {
                str += " ";
                hangul.flag_space = false;
                spaceflag = true;
            }

            if (doubleflag)
            {
                if (impossiblejongsungflag)
                    str += hangul.jongsung;
                else
                    str += hangul.jongsung2;
            }
            if (hangul.jungsung == "·")
            {
                str += "·";
                dotflag = true;
            }
            else if (hangul.jungsung == "‥")
            {
                str += "‥";
                dotflag = true;
            }

            str += origin.Substring(position, origin.Length-position);
            //et.setText(str);
            inputfield.text = str;

            if (dotflag)
                position++;
            if (doubleflag)
            {
                if (!hangul.flag_doubled)
                    position++;
                hangul.flag_doubled = true;
            }
            else
            {
                if (hangul.flag_doubled)
                    position--;
                hangul.flag_doubled = false;
            }
            if (spaceflag)
                position++;
            if (unicode == 0 && dotflag == false)
                position--;
            if (hangul.flag_addcursor)
            {
                hangul.flag_addcursor = false;
                position++;
            }

            if (hangul.flag_dotused)
            {
                if (hangul.chosung.Length == 0 && dotflag == false)
                {//et.setSelection(position);
                    inputfield.caretPosition = position;
                }
                else
                {
                    //et.setSelection(position - 1);
                    inputfield.caretPosition = position - 1;
                }
            }
            else if (!hangul.flag_writing && dotflag == false)
            {
                //et.setSelection(position + 1);
                inputfield.caretPosition = position + 1;
            }
            else
            {
                //et.setSelection(position);
                inputfield.caretPosition = position;
            }

            hangul.flag_dotused = false;
            hangul.flag_writing = (unicode == 0 && dotflag == false) ? false : true;
        }
        /*
        else //if(mode == ENGLISH || mode == UPPER_ENGLISH || mode == NUMBER)
        {
            if (flag_engdelete)
                str += origin.Substring(0, position - 1);
            else
                str += origin.Substring(0, position);

            if (flag_upper || mode == NUMBER)
                str += engnum;
            else
                str += engnum.toLowerCase();

            if (flag_engdelete)
            {
                str += origin.Substring(position, origin.Length);
                //et.setText(str);
                et.text=str;
                et.setSelection(position);
                flag_engdelete = false;
            }
            else
            {
                str += origin.Substring(position, origin.Length);
                //et.setText(str);
                et.text=str;
                if (engnum.Length == 0)
                    et.setSelection(position);
                else
                    et.setSelection(position + 1);
            }

            if (flag_initengnum)
                init_engnum();
        }
        */
    }

    private void delete()
    {
        //int position = et.getSelectionStart();
        int position = inputfield.caretPosition;
        if (position == 0)
            return;

        string origin = "";
        string str = "";

        origin = inputfield.text;
        str += origin.Substring(0, position - 1);
        str += origin.Substring(position, origin.Length-position);
        //et.setText(str);
        inputfield.text = str;
        //et.setSelection(position - 1);
        inputfield.caretPosition = position - 1;
    }
    /*
    private void engMake(int input)
    {
        if (input == 10) // 띄어쓰기
        {
            if (engnum.Length == 0)
                engnum = " ";
            else
                engnum = "";
            flag_initengnum = true;
        }
        else if (input == 11) // 지우기
        {
            delete();
            init_engnum();
        }
        else
        {
            string str = "";
            switch (input)
            {
                case 0: str = "@?!"; break;
                case 1: str = ".QZ"; break;
                case 2: str = "ABC"; break;
                case 3: str = "DEF"; break;
                case 4: str = "GHI"; break;
                case 5: str = "JKL"; break;
                case 6: str = "MNO"; break;
                case 7: str = "PRS"; break;
                case 8: str = "TUV"; break;
                case 9: str = "WXY"; break;
                default: return;
            }

            char ch[] = str.toCharArray();

            if (engnum.Length == 0)
                engnum = string.valueOf(ch[0]);
            else if (engnum == string.valueOf(ch[0])))
    {
                engnum = string.valueOf(ch[1]);
                flag_engdelete = true;
            }
    else if (engnum == string.valueOf(ch[1])))
    {
                engnum = string.valueOf(ch[2]);
                flag_engdelete = true;
            }
    else if (engnum == string.valueOf(ch[2])))
    {
                engnum = string.valueOf(ch[0]);
                flag_engdelete = true;
            }
    else
        engnum = string.valueOf(ch[0]);
        }
    }
  */
    /*
    private void numMake(int input)
    {
        if (input == 10) // 띄어쓰기
            engnum = " ";
        else if (input == 11) // 지우기
            delete();
        else
            engnum = Integer.tostring(input);

        flag_initengnum = true;
    }
    */


    private void hangulMake(int input)
    {
        string beforedata = "";
        string nowdata = "";
        string overdata = "";
        if (input == 10) //띄어쓰기
        {
            if (hangul.flag_writing)
                hangul.init();
            else
                hangul.flag_space = true;
        }
        else if (input == 11) //지우기
        {
            if (hangul.step == 0)
            {
                if (hangul.chosung.Length == 0)
                {
                    delete();
                    hangul.flag_writing = false;
                }
                else
                    hangul.chosung = "";
            }
            else if (hangul.step == 1)
            {
                if (hangul.jungsung == "·" || hangul.jungsung == "‥")
                {
                    delete();
                    if (hangul.chosung.Length == 0)
                        hangul.flag_writing = false;
                }
                hangul.jungsung = "";
                hangul.step = 0;
            }
            else if (hangul.step == 2)
            {
                hangul.jongsung = "";
                hangul.step = 1;
            }
            else if (hangul.step == 3)
            {
                hangul.jongsung2 = "";
                hangul.step = 2;
            }
        }
        else if (input == 1 || input == 2 || input == 3) //모음
        {
            //받침에서 떼어오는거 추가해야함
            bool batchim = false;
            if (hangul.step == 2)
            {
                delete();
                string s = hangul.jongsung;
                //bug fixed, 16.4.22 ~
                if (!hangul.flag_doubled)
                {
                    hangul.jongsung = "";
                    hangul.flag_writing = false;
                    write(now_mode);
                }
                // ~ bug fixed, 16.4.22
                hangul.init();
                hangul.chosung = s;
                hangul.step = 0;
                batchim = true;
            }
            else if (hangul.step == 3)
            {
                string s = hangul.jongsung2;
                if (hangul.flag_doubled)
                    delete();
                else
                {
                    delete();
                    hangul.jongsung2 = "";
                    hangul.flag_writing = false;
                    write(now_mode);
                }
                hangul.init();
                hangul.chosung = s;
                hangul.step = 0;
                batchim = true;
            }
            beforedata = hangul.jungsung;
            hangul.step = 1;
            if (input == 1) // ㅣ ㅓ ㅕ ㅐ ㅔ ㅖㅒ ㅚ ㅟ ㅙ ㅝ ㅞ ㅢ
            {
                if (beforedata.Length == 0) nowdata = "ㅣ";
                else if (beforedata == "·")
                {
                    nowdata = "ㅓ";
                    hangul.flag_dotused = true;
                }
                else if (beforedata == "‥")
                {
                    nowdata = "ㅕ";
                    hangul.flag_dotused = true;
                }
                else if (beforedata == "ㅏ") nowdata = "ㅐ";
                else if (beforedata == "ㅑ") nowdata = "ㅒ";
                else if (beforedata == "ㅓ") nowdata = "ㅔ";
                else if (beforedata == "ㅕ") nowdata = "ㅖ";
                else if (beforedata == "ㅗ") nowdata = "ㅚ";
                else if (beforedata == "ㅜ") nowdata = "ㅟ";
                else if (beforedata == "ㅠ") nowdata = "ㅝ";
                else if (beforedata == "ㅘ") nowdata = "ㅙ";
                else if (beforedata == "ㅝ") nowdata = "ㅞ";
                else if (beforedata == "ㅡ") nowdata = "ㅢ";
                else
                {
                    hangul.init();
                    hangul.step = 1;
                    nowdata = "ㅣ";
                }
            }
            else if (input == 2) // ·,‥,ㅏ,ㅑ,ㅜ,ㅠ,ㅘ
            {
                if (beforedata.Length == 0)
                {
                    nowdata = "·";
                    if (batchim)
                        hangul.flag_addcursor = true;
                }
                else if (beforedata == "·")
                {
                    nowdata = "‥";
                    hangul.flag_dotused = true;
                }
                else if (beforedata == "‥")
                {
                    nowdata = "·";
                    hangul.flag_dotused = true;
                }
                else if (beforedata == "ㅣ") nowdata = "ㅏ";
                else if (beforedata == "ㅏ") nowdata = "ㅑ";
                else if (beforedata == "ㅡ") nowdata = "ㅜ";
                else if (beforedata == "ㅜ") nowdata = "ㅠ";
                else if (beforedata == "ㅚ") nowdata = "ㅘ";
                else
                {
                    hangul.init();
                    hangul.step = 1;
                    nowdata = "·";
                }
            }
            else if (input == 3) // ㅡ, ㅗ, ㅛ
            {
                if (beforedata.Length == 0) nowdata = "ㅡ";
                else if (beforedata == "·")
                {
                    nowdata = "ㅗ";
                    hangul.flag_dotused = true;
                }
                else if (beforedata == "‥")
                {
                    nowdata = "ㅛ";
                    hangul.flag_dotused = true;
                }
                else
                {
                    hangul.init();
                    hangul.step = 1;
                    nowdata = "ㅡ";
                }
            }
            hangul.jungsung = nowdata;
        }
        else //자음
        {
            if (hangul.step == 1)
            {
                if (hangul.jungsung == "·" || hangul.jungsung == "‥")
                    hangul.init();
                else
                    hangul.step = 2;
            }
            if (hangul.step == 0) beforedata = hangul.chosung;
            else if (hangul.step == 2) beforedata = hangul.jongsung;
            else if (hangul.step == 3) beforedata = hangul.jongsung2;

            if (input == 4) // ㄱ, ㅋ, ㄲ, ㄺ
            {
                if (beforedata.Length == 0)
                {
                    if (hangul.step == 2)
                    {
                        if (hangul.chosung.Length == 0)
                            overdata = "ㄱ";
                        else
                            nowdata = "ㄱ";
                    }
                    else
                        nowdata = "ㄱ";
                }
                else if (beforedata == "ㄱ")
                    nowdata = "ㅋ";
                else if (beforedata == "ㅋ")
                    nowdata = "ㄲ";
                else if (beforedata == "ㄲ")
                    nowdata = "ㄱ";
                else if (beforedata == "ㄹ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㄱ";
                }
                else
                    overdata = "ㄱ";
            }
            else if (input == 5) // ㄴ ㄹ
            {
                if (beforedata.Length == 0)
                {
                    if (hangul.step == 2)
                    {
                        if (hangul.chosung.Length == 0)
                            overdata = "ㄴ";
                        else
                            nowdata = "ㄴ";
                    }
                    else
                        nowdata = "ㄴ";
                }
                else if (beforedata == "ㄴ")
                    nowdata = "ㄹ";
                else if (beforedata == "ㄹ")
                    nowdata = "ㄴ";
                else
                    overdata = "ㄴ";
            }
            else if (input == 6) // ㄷ, ㅌ, ㄸ, ㄾ
            {
                if (beforedata.Length == 0)
                {
                    if (hangul.step == 2)
                    {
                        if (hangul.chosung.Length == 0)
                            overdata = "ㄷ";
                        else
                            nowdata = "ㄷ";
                    }
                    else
                        nowdata = "ㄷ";
                }
                else if (beforedata == "ㄷ")
                    nowdata = "ㅌ";
                else if (beforedata == "ㅌ")
                    nowdata = "ㄸ";
                else if (beforedata == "ㄸ")
                    nowdata = "ㄷ";
                else if (beforedata == "ㄹ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㄷ";
                }
                else
                    overdata = "ㄷ";
            }
            else if (input == 7) // ㅂ, ㅍ, ㅃ, ㄼ, ㄿ
            {
                if (beforedata.Length == 0)
                {
                    if (hangul.step == 2)
                    {
                        if (hangul.chosung.Length == 0)
                            overdata = "ㅂ";
                        else
                            nowdata = "ㅂ";
                    }
                    else
                        nowdata = "ㅂ";
                }
                else if (beforedata == "ㅂ")
                    nowdata = "ㅍ";
                else if (beforedata == "ㅍ")
                    nowdata = "ㅃ";
                else if (beforedata == "ㅃ")
                    nowdata = "ㅂ";
                else if (beforedata == "ㄹ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㅂ";
                }
                else
                    overdata = "ㅂ";
            }
            else if (input == 8) // ㅅ, ㅎ, ㅆ, ㄳ, ㄶ, ㄽ, ㅀ, ㅄ
            {
                if (beforedata.Length == 0)
                {
                    if (hangul.step == 2)
                    {
                        if (hangul.chosung.Length == 0)
                            overdata = "ㅅ";
                        else
                            nowdata = "ㅅ";
                    }
                    else
                        nowdata = "ㅅ";
                }
                else if (beforedata == "ㅅ")
                    nowdata = "ㅎ";
                else if (beforedata == "ㅎ")
                    nowdata = "ㅆ";
                else if (beforedata == "ㅆ")
                    nowdata = "ㅅ";
                else if (beforedata == "ㄱ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㅅ";
                }
                else if (beforedata == "ㄴ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㅅ";
                }
                else if (beforedata == "ㄹ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㅅ";
                }
                else if (beforedata == "ㅂ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㅅ";
                }
                else
                    overdata = "ㅅ";
            }
            else if (input == 9) // ㅈ, ㅊ, ㅉ, ㄵ
            {
                if (beforedata.Length == 0)
                {
                    if (hangul.step == 2)
                    {
                        if (hangul.chosung.Length == 0)
                            overdata = "ㅈ";
                        else
                            nowdata = "ㅈ";
                    }
                    else
                        nowdata = "ㅈ";
                }
                else if (beforedata == "ㅈ")
                    nowdata = "ㅊ";
                else if (beforedata == "ㅊ")
                    nowdata = "ㅉ";
                else if (beforedata == "ㅉ")
                    nowdata = "ㅈ";
                else if (beforedata == "ㄴ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㅈ";
                }
                else
                    overdata = "ㅈ";
            }
            else if (input == 0) // ㅇ, ㅁ, ㄻ
            {
                if (beforedata.Length == 0)
                {
                    if (hangul.step == 2)
                    {
                        if (hangul.chosung.Length == 0)
                            overdata = "ㅇ";
                        else
                            nowdata = "ㅇ";
                    }
                    else
                        nowdata = "ㅇ";
                }
                else if (beforedata == "ㅇ")
                    nowdata = "ㅁ";
                else if (beforedata == "ㅁ")
                    nowdata = "ㅇ";
                else if (beforedata == "ㄹ" && hangul.step == 2)
                {
                    hangul.step = 3;
                    nowdata = "ㅇ";
                }
                else
                    overdata = "ㅇ";
            }

            if (nowdata.Length > 0)
            {
                if (hangul.step == 0)
                    hangul.chosung = nowdata;
                else if (hangul.step == 2)
                    hangul.jongsung = nowdata;
                else //if(hangul.step == 3)
                    hangul.jongsung2 = nowdata;
            }
            if (overdata.Length > 0)
            {
                hangul.flag_writing = false;
                hangul.init();
                hangul.chosung = overdata;
            }
        }
    }

    /// 미리
    private void setBtnText(int mode)
    {/*
        switch (mode)
        {
            
            case HANGUL:
                btn[0].setText("ㅇㅁ");
                btn[1].setText("ㅣ");
                btn[2].setText("·");
                btn[3].setText("ㅡ");
                btn[4].setText("ㄱㅋ");
                btn[5].setText("ㄴㄹ");
                btn[6].setText("ㄷㅌ");
                btn[7].setText("ㅂㅍ");
                btn[8].setText("ㅅㅎ");
                btn[9].setText("ㅈㅊ");
                break;

            case UPPER_ENGLISH:
                btn[0].setText("@?!");
                btn[1].setText(".QZ");
                btn[2].setText("ABC");
                btn[3].setText("DEF");
                btn[4].setText("GHI");
                btn[5].setText("JKL");
                btn[6].setText("MNO");
                btn[7].setText("PRS");
                btn[8].setText("TUV");
                btn[9].setText("WXY");
                flag_upper = true;
                break;
            case ENGLISH:
                btn[0].setText("@?!");
                btn[1].setText(".qz");
                btn[2].setText("abc");
                btn[3].setText("def");
                btn[4].setText("ghi");
                btn[5].setText("jkl");
                btn[6].setText("mno");
                btn[7].setText("prs");
                btn[8].setText("tuv");
                btn[9].setText("wxy");
                flag_upper = false;
                break;
            case NUMBER:
                for (int i = 0; i < 10; i++)
                    btn[i].setText(Integer.tostring(i));
                break;
               
        } */
    }

    private int getUnicode(string real_jong)
    {
        int cho, jung, jong;
        //초성
        if (hangul.chosung.Length == 0)
        {
            if ((hangul.jungsung.Length == 0 || hangul.jungsung == "·") || hangul.jungsung == "‥")
                return 0;
        }

        if (hangul.chosung == "ㄱ") cho = 0;
        else if (hangul.chosung == "ㄲ") cho = 1;
        else if (hangul.chosung == "ㄴ") cho = 2;
        else if (hangul.chosung == "ㄷ") cho = 3;
        else if (hangul.chosung == "ㄸ") cho = 4;
        else if (hangul.chosung == "ㄹ") cho = 5;
        else if (hangul.chosung == "ㅁ") cho = 6;
        else if (hangul.chosung == "ㅂ") cho = 7;
        else if (hangul.chosung == "ㅃ") cho = 8;
        else if (hangul.chosung == "ㅅ") cho = 9;
        else if (hangul.chosung == "ㅆ") cho = 10;
        else if (hangul.chosung == "ㅇ") cho = 11;
        else if (hangul.chosung == "ㅈ") cho = 12;
        else if (hangul.chosung == "ㅉ") cho = 13;
        else if (hangul.chosung == "ㅊ") cho = 14;
        else if (hangul.chosung == "ㅋ") cho = 15;
        else if (hangul.chosung == "ㅌ") cho = 16;
        else if (hangul.chosung == "ㅍ") cho = 17;
        else /*if ( hangul.chosung=="ㅎ"))*/	cho = 18;

        if (hangul.jungsung.Length == 0 && hangul.jongsung.Length == 0)
            return 0x1100 + cho;
        if ((hangul.jungsung == "·") || (hangul.jungsung == "‥"))
            return 0x1100 + cho;
        
        // 중성
        if (hangul.jungsung == "ㅏ") jung = 0;
        else if (hangul.jungsung == "ㅐ") jung = 1;
        else if (hangul.jungsung == "ㅑ") jung = 2;
        else if (hangul.jungsung == "ㅒ") jung = 3;
        else if (hangul.jungsung == "ㅓ") jung = 4;
        else if (hangul.jungsung == "ㅔ") jung = 5;
        else if (hangul.jungsung == "ㅕ") jung = 6;
        else if (hangul.jungsung == "ㅖ") jung = 7;
        else if (hangul.jungsung == "ㅗ") jung = 8;
        else if (hangul.jungsung == "ㅘ") jung = 9;
        else if (hangul.jungsung == "ㅙ") jung = 10;
        else if (hangul.jungsung == "ㅚ") jung = 11;
        else if (hangul.jungsung == "ㅛ") jung = 12;
        else if (hangul.jungsung == "ㅜ") jung = 13;
        else if (hangul.jungsung == "ㅝ") jung = 14;
        else if (hangul.jungsung == "ㅞ") jung = 15;
        else if (hangul.jungsung == "ㅟ") jung = 16;
        else if (hangul.jungsung == "ㅠ") jung = 17;
        else if (hangul.jungsung == "ㅡ") jung = 18;
        else if (hangul.jungsung == "ㅢ") jung = 19;
        else /*if ( hangul.jungsung=="ㅣ"))*/	jung = 20;

        if (hangul.chosung.Length == 0 && hangul.jongsung.Length == 0)
            return 0x1161 + jung;

        // 종성
        if (real_jong.Length == 0) jong = 0;
        else if (real_jong == "ㄱ") jong = 1;
        else if (real_jong == "ㄲ") jong = 2;
        else if (real_jong == "ㄳ") jong = 3;
        else if (real_jong == "ㄴ") jong = 4;
        else if (real_jong == "ㄵ") jong = 5;
        else if (real_jong == "ㄶ") jong = 6;
        else if (real_jong == "ㄷ") jong = 7;
        else if (real_jong == "ㄹ") jong = 8;
        else if (real_jong == "ㄺ") jong = 9;
        else if (real_jong == "ㄻ") jong = 10;
        else if (real_jong == "ㄼ") jong = 11;
        else if (real_jong == "ㄽ") jong = 12;
        else if (real_jong == "ㄾ") jong = 13;
        else if (real_jong == "ㄿ") jong = 14;
        else if (real_jong == "ㅀ") jong = 15;
        else if (real_jong == "ㅁ") jong = 16;
        else if (real_jong == "ㅂ") jong = 17;
        else if (real_jong == "ㅄ") jong = 18;
        else if (real_jong == "ㅅ") jong = 19;
        else if (real_jong == "ㅆ") jong = 20;
        else if (real_jong == "ㅇ") jong = 21;
        else if (real_jong == "ㅈ") jong = 22;
        else if (real_jong == "ㅊ") jong = 23;
        else if (real_jong == "ㅋ") jong = 24;
        else if (real_jong == "ㅌ") jong = 25;
        else if (real_jong == "ㅍ") jong = 26;
        else /*if ( real_jong=="ㅎ"))*/	jong = 27;

        if (hangul.chosung.Length == 0 && hangul.jungsung.Length == 0)
            return 0x11a8 + jong;

        return 44032 + cho * 588 + jung * 28 + jong;
    }

    private string checkDouble(string jong, string jong2)
    {
        string s = "";
        if (jong == "ㄱ")
        {
            if (jong2 == "ㅅ") s = "ㄳ";
        }
        else if (jong == "ㄴ")
        {
            if (jong2 == "ㅈ") s = "ㄵ";
            else if (jong2 == "ㅎ") s = "ㄶ";
        }
        else if (jong == "ㄹ")
        {
            if (jong2 == "ㄱ") s = "ㄺ";
            else if (jong2 == "ㅁ") s = "ㄻ";
            else if (jong2 == "ㅂ") s = "ㄼ";
            else if (jong2 == "ㅅ") s = "ㄽ";
            else if (jong2 == "ㅌ") s = "ㄾ";
            else if (jong2 == "ㅍ") s = "ㄿ";
            else if (jong2 == "ㅎ") s = "ㅀ";
        }
        else if (jong == "ㅂ")
        {
            if (jong2 == "ㅅ") s = "ㅄ";
        }
        return s;
    }
}



