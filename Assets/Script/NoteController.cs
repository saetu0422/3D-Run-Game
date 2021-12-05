﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    //하나의 노트에 대한 정보를 담는 노트(Note) 클래스를 정의
    class Note
    {
        public int noteType { get; set; }
        public int order { get; set; }
        public Note(int noteType, int order)
        {
            this.noteType = noteType;
            this.order = order;
        }
    }

    public GameObject[] Notes;
    private List<Note> notes = new List<Note>();
    private float beatInterval = 1.0f;

    IEnumerator AwaitMakeNote(Note note)
    {
        int noteType = note.noteType;
        int order = note.order;
        yield return new WaitForSeconds(order * beatInterval);
        Instantiate(Notes[noteType - 1]);
    }
    void Start()
    {
        notes.Add(new Note(1, 1));
        notes.Add(new Note(2, 2));
        notes.Add(new Note(1, 3));
        notes.Add(new Note(1, 4));
        notes.Add(new Note(2, 5));
        notes.Add(new Note(1, 6));
        //모든 노트를 정해진 시간에 출발하도록 지정
        for(int i = 0; i < notes.Count; i++)
        {
            StartCoroutine(AwaitMakeNote(notes[i]));
        }
    }

    void Update()
    {
        
    }
}