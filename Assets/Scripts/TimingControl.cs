using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TimingControl : MonoBehaviour
{
    public UnityEvent moveAll;
    public UnityEvent TimeOver;

    public TextAsset _timingData;
    private float[] _timings;

    public AudioSource _source;
    public float _sensitivity = 0.1f;
    private float _allowTime = 0.3f;

    int _timingIndex = 0;

    private void Start()
    {
        _timings = ReadTimingData(_timingData);

        //_allowTime = _timings[1] - _timings[0];
        //_allowTime /= 3f;

        StartCoroutine(MoveTime());
    }
    
    IEnumerator MoveTime()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        while(true)
        {
            yield return wait;
            
            if(_source.time >= _timings[_timingIndex] + _sensitivity)
            {
                _timingIndex++;

                if (_timingIndex > _timings.Length)
                    break;

                moveAll.Invoke();
            }
        }
        TimeOver.Invoke();
    }

    public bool IsTiming()
    {
        if (_timings[_timingIndex] + _sensitivity - _source.time <= _allowTime)
            return true;
        return false;
    }

    float[] ReadTimingData(TextAsset data)
    {
        string line = data.text;
        string[] timings_str = line.Split(',');
        float[] timings = new float[timings_str.Length];
        for(int i=0;i<timings_str.Length;i++)
        {
            timings[i] = float.Parse(timings_str[i]) / 1000;
        }
        return timings;
    }
}
