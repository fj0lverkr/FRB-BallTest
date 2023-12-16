using BallTest.Entities;

namespace BallTest.Screens
{
    public partial class GameScreen
    {
        void OnPuckVsGoalCollided(Puck puck, Goal goal)
        {
            if (goal == GoalLeft)
            {
                PlayerTwoScore++;
            }
            else
            {
                PlayerOneScore++;
            }

            ResetPlayfield();
        }

        private void ResetPlayfield()
        {
            Puck1.X = 0;
            Puck1.Y = 0;
            Puck1.Velocity = Microsoft.Xna.Framework.Vector3.Zero;
            PlayerBall1.X = -180;
            PlayerBall1.Y = 0;
            PlayerBall1.Acceleration = Microsoft.Xna.Framework.Vector3.Zero;
            PlayerBall1.Velocity = Microsoft.Xna.Framework.Vector3.Zero;
            PlayerBall2.X = 180;
            PlayerBall2.Y = 0;
            PlayerBall2.Acceleration = Microsoft.Xna.Framework.Vector3.Zero;
            PlayerBall2.Velocity = Microsoft.Xna.Framework.Vector3.Zero;
            ScoreHUD1.ScoreOne = PlayerOneScore;
            ScoreHUD1.ScoreTwo = PlayerTwoScore;
        }
    }
}
