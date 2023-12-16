using FlatRedBall;
using FlatRedBall.Input;

namespace BallTest.Entities
{
    public partial class PlayerBall
    {
        public I2DInput MovementInput { get; set; }
        public IPressableInput BoostInput { get; set; }

        private double _lastTimeDashed = -1000;

        /// <summary>
        /// Initialization logic which is executed only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize() { }

        private void CustomActivity()
        {
            MovementActivity();
            DashActivity();
        }

        private void CustomDestroy() { }

        private static void CustomLoadStaticContent(string contentManagerName) { }

        private void MovementActivity()
        {
            if (MovementInput != null)
            {
                XAcceleration = MovementSpeed * MovementInput.X;
                YAcceleration = MovementSpeed * MovementInput.Y;
            }
        }

        private void DashActivity()
        {
            float magnitude = MovementInput?.Magnitude ?? 0;

            bool shouldBoost =
                BoostInput?.WasJustPressed == true
                && TimeManager.SecondsSince(_lastTimeDashed) > DashFrequency
                && magnitude > 0;
            bool isHoldingDirection = magnitude > 0;

            if (shouldBoost)
            {
                _lastTimeDashed = TimeManager.CurrentScreenTime;
                // dividing by magnitude tells us what X and Y would
                // be if the user were holding the input all the way in
                // the current direction.
                float normalizedX = MovementInput.X / magnitude;
                float normalizedY = MovementInput.Y / magnitude;

                XVelocity = normalizedX * DashSpeed;
                YVelocity = normalizedY * DashSpeed;

                CurrentDashCategoryState = DashCategory.Tired;
                InterpolateToState(DashCategory.Rested, DashFrequency);
            }
        }
    }
}
