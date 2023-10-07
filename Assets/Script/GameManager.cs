using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Hantu [] hantu;
    public Pacstudent pacstudent;
    public Transform pelets;
    public int hantuMultiplier {get; private set;} =1;
    public int skor {get; private set;}
    public int nyawa {get; private set;}

    private void Start () 
    {
        GameBaru();    
    }

    private void Update () 
    {
        if (nyawa <= 0 && Input.anyKeyDown) {
            GameBaru();
        }   
    }
    private void GameBaru() 
    {
        SetSkor(0);
        SetNyawa(3);
        RondeBaru();
    }

    private void RondeBaru() 
    {

        foreach (Transform pelet in pelets) {
            pelet.gameObject.SetActive(true);
        }

        ResetState(); 
    }

    
    private void ResetState()
    {
        for (int i = 0; i < hantu.Length; i++) {
            hantu[i].ResetState();
        }
        
    }

    private void GameOver () 
    {


        for (int i = 0; i < hantu.Length; i++) {
            hantu[i].gameObject.SetActive(false);
        }

        pacstudent.gameObject.SetActive(false);
    }

    private void SetNyawa(int nyawa)
    {
        this.nyawa = nyawa;
    }

        private void SetSkor(int skor)
    {
        this.skor = skor;
    }

    public void PacStudentMakan()
    {

        SetNyawa(nyawa - 1);

        if (nyawa > 0) {
        } else {
            GameOver();
        }
    }

    public void MakanHantu(Hantu hantu)
    {
        int poins = hantu.poins * hantuMultiplier;
        SetSkor(skor + poins);

        hantuMultiplier++;
    }

    public void MakanPelet (Pelet pelets) 
    {
        pelets.gameObject.SetActive(false);
       SetSkor(this.skor + pelets.poins); 
       if(!HasRemainingPelet()) 
       {
        pacstudent.gameObject.SetActive(false);
        Invoke(nameof(RondeBaru), 3.0f); 
       }
    }

    public void MakanPowerPelet (PowerPelet pelets)
    {
        for (int i = 0; i < hantu.Length; i++) {
            hantu[i].frightened.Enable(pelets.duration);
        }

        MakanPelet(pelets);
        CancelInvoke();
        Invoke(nameof(ResetHantuMultiplier), pelets.duration);
        
    }
    private bool HasRemainingPelet()
    {
        foreach(Transform pelets in this.pelets) 
        {
            if(pelets.gameObject.activeSelf) {
                return true;
            }    
        }
        return false;
    }
    private void ResetHantuMultiplier () {
        hantuMultiplier = 1;
        
    }



}
