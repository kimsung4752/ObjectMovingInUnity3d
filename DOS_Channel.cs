using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//information current Playing Input Data
public class DOS_Channel : MonoBehaviour
{
    /// <summary>
    ///  2017 07 26
    /// </summary>

    public enum VisualinzgMode
    {
        Default,
        Mode_A,
        Mode_B,
        Mode_C
    }
    public VisualinzgMode visualinzgMode = VisualinzgMode.Default;
    //Is Player Play Instrument?
    bool Is_Playing=false;
    //spectrum Data.1024,range(0,1)
    float[] spectrumdata = new float[1024];
    //range(0,88)
    int note = -1;//default note is -1
    //range(0,1)
    float volume { get; set; }
    public class TriggerDetection:DOS_Channel
    {
        public float threshold;//range 0~1
        public bool IsTriggerOn;
        //after Event PopUp, Time return to defaut
        public float intervalTime;
        public TriggerDetection()
        {
            threshold = 0.0f;
            IsTriggerOn = false;
            intervalTime = 0.5f;
        }
    }
    //스펙트럼 데이터 구간 평균 구하기 
    public class SpectrumTriggerDetection:DOS_Channel
    {
        public int spectrum_Center_index=511;
        public int detecting_index_Width=400;
        public float detecting_index_Height=0.5f;    //each range(0~1)
        float spectrumdata_sectionAverage;
        public void Set_sectionAverage()
        {
            int sum_Start_Index = spectrum_Center_index - (detecting_index_Width / 2);
            int sum_End_Index = spectrum_Center_index + (detecting_index_Width / 2);

            for (int i= sum_Start_Index; i < sum_End_Index;i++)
            {
                if (spectrumdata != null)
                {
                    spectrumdata_sectionAverage += spectrumdata[i];
                }
           
            }
        }

    }

    public TriggerDetection drum_Trigger;
    public TriggerDetection volume_Trigger;
    public TriggerDetection note_Trigger;
}

