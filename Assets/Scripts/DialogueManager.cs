using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public bool actionInScene;
    public float timer;

    private Queue<AudioClip> _dialogues;
    private AudioSource _audioSource;
    private bool _started;
    private bool _answerable;
    private bool _answered;

    private void Awake()
    {
        _dialogues = new Queue<AudioClip>();
        _audioSource = FindObjectOfType<AudioManager>().GetComponent<AudioSource>();
    }

    private void Start()
    {
        if (!(timer > 0)) return;
        Dialogue empty = new Dialogue();
        StartDialogue(empty, false);
    }

    private void Update()
    {
        if (!_started || _audioSource.isPlaying) return;
        if (_answered)
        {
            RunNextDialogue();
            _answered = false;
        }

        if (_answerable)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                _dialogues.Dequeue();
                RunNextDialogue();
                _answered = true;
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                RunNextDialogue();
                if (_dialogues.Count > 0)
                    _dialogues.Dequeue();
                _answered = true;
            }
        }
        else
            RunNextDialogue();
    }

    public void StartDialogue(Dialogue dialogue, bool answerable)
    {
        _started = true;
        _answerable = answerable;

        _dialogues.Clear();

        if (dialogue.dialogues != null)
        {
            foreach (AudioClip audioClip in dialogue.dialogues)
            {
                _dialogues.Enqueue(audioClip);
            }
        }

        RunNextDialogue();
    }

    private void RunNextDialogue()
    {
        if (_dialogues.Count == 0)
        {
            _started = false;
            GameManager gameManager = FindObjectOfType<GameManager>();

            Debug.Log(timer);
            if (actionInScene)
                gameManager.Action();
            else
                gameManager.NoAction(timer);
            return;
        }

        AudioClip dialogue = _dialogues.Dequeue();
        _audioSource.clip = dialogue;
        _audioSource.Play();
    }
}