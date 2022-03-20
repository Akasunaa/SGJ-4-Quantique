using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private void Awake()
    {
       
        PlayerIntrication.CardProba += Proba;
        PlayerIntrication.CardDecorrele += Decorrele;
        Zone.CardGainEnergie += GainEnergie;
        Zone.CardGainEnergie += Mesure;
        Zone.CardWin += Win;
    }

    private void OnDestroy()
    {
        PlayerIntrication.CardProba -= Proba;
        PlayerIntrication.CardDecorrele -= Decorrele;
        Zone.CardGainEnergie -= GainEnergie;
        Zone.CardGainEnergie -= Mesure;
        Zone.CardWin -= Win;
    }

    void Proba()
    {
        print("proba");
        HighlightEchap();
    }

    void Decorrele()
    {
        print("decorrele");
        HighlightEchap();
    }

    void GainEnergie()
    {
        print("gain");
        HighlightEchap();
    }

    void Mesure()
    {
        print("mesure");
        HighlightEchap();
        //Activer le canva mesure ca va pas être simple
    }

    public void Win()
    {
        print("win");
        //deux cartes à faire
        //escape?
    }

    void HighlightEchap()
    {
        //do smth
    }

}
