using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum Hand
    {
        Rock,
        Paper,
        Scissors
    }

    public Image playerImage;
    public Image computerImage;

    public Sprite rockSprite;
    public Sprite paperSprite;
    public Sprite scissorsSprite;

    public TextMeshProUGUI textWin;
    public TextMeshProUGUI textScorePlayer;
    public TextMeshProUGUI textScoreComputer;

    public AudioClip soundWin;
    public AudioClip soundLoser;
    public AudioClip soundTie;

    public AudioSource SoundApp;

    public int ScorePlayer = 0;
    public int ScoreComputer = 0;

    private void Awake() { }

    public void MakeChoice(int choice)
    {
        Hand playerChoice = (Hand)choice;
        Hand computerChoice = (Hand)Random.Range(0, 3);

        SetImage(playerImage, playerChoice);
        SetImage(computerImage, computerChoice);

        DetermineWinner(playerChoice, computerChoice);
    }

    private void SetImage(Image image, Hand choice)
    {
        switch (choice)
        {
            case Hand.Rock:
                image.sprite = rockSprite;
                break;
            case Hand.Paper:
                image.sprite = paperSprite;
                break;
            case Hand.Scissors:
                image.sprite = scissorsSprite;
                break;
        }
    }

    private void DetermineWinner(Hand playerChoice, Hand computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            SoundApp.PlayOneShot(soundTie);
            textWin.text = "IT IS TIE";
            ScorePlayer++;
            textScorePlayer.text = ScorePlayer.ToString();
            ScoreComputer++;
            textScoreComputer.text = ScoreComputer.ToString();
        }
        else if (
            (playerChoice == Hand.Rock && computerChoice == Hand.Scissors)
            || (playerChoice == Hand.Paper && computerChoice == Hand.Rock)
            || (playerChoice == Hand.Scissors && computerChoice == Hand.Paper)
        )
        {
            SoundApp.PlayOneShot(soundWin);
            textWin.text = "PLAYER WIN";
            ScorePlayer++;
            textScorePlayer.text = ScorePlayer.ToString();
        }
        else
        {
            SoundApp.PlayOneShot(soundLoser);
            textWin.text = "CPU WIN";
            ScoreComputer++;
            textScoreComputer.text = ScoreComputer.ToString();
        }
    }
}
