using System;
using System.Collections.Generic;
using System.Text;

namespace Assets
{
    internal static class PlayerIntros
    {
        public static void JumpIntro(PlayerCharacter player) {
            float ogJumpForce = player.jumpForce;
            player.jumpForce = 18;
            player.TryJump(llinearVelocityYOverride: 1);
            player.jumpForce = ogJumpForce;
        }
    }
}
