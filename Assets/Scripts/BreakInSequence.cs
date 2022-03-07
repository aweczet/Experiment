using UnityEngine;

public class BreakInSequence : MonoBehaviour
{
    public GameObject breakInSounds;
    private AudioManager _audioManager;
    
    private float _timeToDoorKicks = 3f;
    private bool _doorKicksOn;
    
    private float _timeToAlarmGoesOff = 2f;
    private bool _alarmOn;
    
    private float _timeToBreakIn = 1f;
    private bool _breakInOn;
    

    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _audioManager.Play("StressCreak");
    }

    private void Update()
    {
        if ((_timeToDoorKicks -= Time.deltaTime) > 0)
            return;

        if (!_doorKicksOn)
        {
            _audioManager.Play("DoorKicks");
            _doorKicksOn = true;
        }

        if ((_timeToAlarmGoesOff -= Time.deltaTime) > 0)
            return;

        if (!_alarmOn)
        {
            _audioManager.Play("Alarm");
            _alarmOn = true;
        }

        if ((_timeToBreakIn -= Time.deltaTime) > 0)
            return;

        if (_breakInOn) return;
        Instantiate(breakInSounds);
        _audioManager.Stop("DoorKicks");
        _breakInOn = true;
    }
}