using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chunjiin_test_0 : MonoBehaviour
{
    public Text outText;

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
        private bool flag_space = false;
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
        private Hangul hangul = new Hangul();
    }
    

}
