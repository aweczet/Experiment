using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int _direction;
    private bool _dying;

    private AudioSource _source;
    private AudioSource[] _sources = new AudioSource[3];

    private readonly string[] _monsterSounds = {"Monster1", "Monster2", "MonsterDeath"};
    private int _monsterSound = -1;
    
    private void Start()
    {
        _direction = (int)Mathf.Sign(transform.position.x);
        
        _source = gameObject.AddComponent<AudioSource>();
        _source.spatialBlend = 1;
        _source.maxDistance = 20;
        _source.rolloffMode = AudioRolloffMode.Custom;

        for (int i = 0; i < 3; i++)
        {
            _sources[i] = GameObject.Find(_monsterSounds[i]).GetComponent<AudioSource>();
        }
    }

    private void Update()
    {
        if (_dying) return;

        if (transform.position.x < .5 && transform.position.x > .5)
        {
            Debug.Log("Player should die");
            return;
        }
        
        if (!_source.isPlaying)
        {
            _monsterSound = _monsterSound + 1 > 1 ? 0 : 1;
            _source.clip = _sources[_monsterSound].clip;
            _source.volume = _sources[_monsterSound].volume;
            _source.Play();
        }
        
        Move();
    }

    private void Move()
    {
        transform.position = new Vector2(transform.position.x - _direction * Time.deltaTime, transform.position.y);
    }

    public void Die()
    {
        _dying = true;
        _source.Stop();
        _source.clip = _sources[2].clip;
        _source.volume = _sources[2].volume;
        _source.Play();
        StartCoroutine(WaitForDeath());
    }

    private IEnumerator WaitForDeath()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.3f);
            Destroy(gameObject);
        }
    }
}