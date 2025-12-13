using UnityEngine;

namespace Assets
{
    public class playerAnimationEvents : MonoBehaviour
    {
        private PlayerCharacter player;

        private void Awake()
        {
            player = GetComponentInParent<PlayerCharacter>();
        }

        private void DisableMovementAndJump()
        {
            player.SetMovementAndJump(false);
            player.SetCanAttack(false);
        }

        private void EnableMovementAndJump()
        {
            player.SetMovementAndJump(true);
            player.SetCanAttack(true);
        }

    }
}
