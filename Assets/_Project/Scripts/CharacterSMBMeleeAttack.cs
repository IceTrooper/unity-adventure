using UnityEngine;

public class CharacterSMBMeleeAttack : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMovement playerMovement = animator.GetComponent<PlayerMovement>();
        if(playerMovement != null)
        {
            playerMovement.inAttack = true;
            playerMovement.meleeWeapon.gameObject.SetActive(true);
        }
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerMovement playerMovement = animator.GetComponent<PlayerMovement>();
        if(playerMovement != null)
        {
            playerMovement.inAttack = false;
            playerMovement.meleeWeapon.gameObject.SetActive(false);
        }
    }
}
