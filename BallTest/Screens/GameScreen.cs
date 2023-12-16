using FlatRedBall.Input;

namespace BallTest.Screens
{
    public partial class GameScreen
    {
        public int PlayerOneScore { get; set; } = 0;
        public int PlayerTwoScore { get; set; } = 0;

        void CustomInitialize()
        {
            AssingInput();
        }

        void CustomActivity(bool firstTimeCalled) { }

        void CustomDestroy() { }

        static void CustomLoadStaticContent(string contentManagerName) { }

        private void AssingInput()
        {
            if (InputManager.Xbox360GamePads[0].IsConnected)
            {
                PlayerBall1.MovementInput = InputManager.Xbox360GamePads[0].LeftStick;
                PlayerBall1.BoostInput = InputManager
                    .Xbox360GamePads[0]
                    .GetButton(Xbox360GamePad.Button.A);
            }
            else
            {
                PlayerBall1.MovementInput = InputManager.Keyboard.GetWasdInput();
                PlayerBall1.BoostInput = InputManager
                    .Keyboard
                    .GetKey(Microsoft.Xna.Framework.Input.Keys.B);
            }

            if (InputManager.Xbox360GamePads[1].IsConnected)
            {
                PlayerBall2.MovementInput = InputManager.Xbox360GamePads[1].LeftStick;
                PlayerBall2.BoostInput = InputManager
                    .Xbox360GamePads[1]
                    .GetButton(Xbox360GamePad.Button.A);
            }
            else
            {
                PlayerBall2.MovementInput = InputManager
                    .Keyboard
                    .Get2DInput(
                        Microsoft.Xna.Framework.Input.Keys.J,
                        Microsoft.Xna.Framework.Input.Keys.L,
                        Microsoft.Xna.Framework.Input.Keys.I,
                        Microsoft.Xna.Framework.Input.Keys.K
                    );
                PlayerBall2.BoostInput = InputManager
                    .Keyboard
                    .GetKey(Microsoft.Xna.Framework.Input.Keys.Space);
            }
        }
    }
}
