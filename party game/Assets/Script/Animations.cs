using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    
    private Animator animator;
 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        GameObject PlayerScoreGetter = GameObject.Find("Game Manager");
        ScoreManager CatScore = PlayerScoreGetter.GetComponent<ScoreManager>();
        ScoreManager PigeonScore = PlayerScoreGetter.GetComponent<ScoreManager>();
        ScoreManager PossumScore = PlayerScoreGetter.GetComponent<ScoreManager>();
        ScoreManager SkunkScore = PlayerScoreGetter.GetComponent<ScoreManager>();

        if (PigeonScore.P1Score >= 3 && PigeonScore.P1Score < 6)
        {
            animator.Play("Pigeon_Idle_Tipsy");
        }
        if (PigeonScore.P1Score >= 6)
        {
            animator.Play("Pigeon_Idle_Drunk");
        }

        if (CatScore.P2Score >= 3 && CatScore.P2Score < 6)
        {
            animator.Play("Cat_Idle_Tipsy");
        }
        if (CatScore.P2Score >= 6)
        {
            animator.Play("Cat_Idle_Drunk");
        }

        if (PossumScore.P3Score >= 3 && PossumScore.P3Score < 6)
        {
            animator.Play("Possum_Idle_Tipsy");
        }
        if (PossumScore.P3Score >= 6)
        {
            animator.Play("Possum_Idle_Drunk");
        }

        if (SkunkScore.P4Score >= 3 && SkunkScore.P4Score < 6)
        {
            animator.Play("Skunk_Idle_Tipsy");
        }
        if (SkunkScore.P4Score >= 6)
        {
            animator.Play("Skunk_Idle_Drunk");
        }
    }
}
