using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TD
{
    static class PlayerInput
    {
        static MouseState mouseState, oldMouseState;
        static KeyboardState keyboardState, oldKeyboardState;

        static double timeSinceClick;

        const double doubleClickDelay = 0.4;

        static bool doubleClicked;

        public static Keys selectKey = Keys.E;

        public static Vector2 MousePosition
        {
            get { return new Vector2(mouseState.Position.X, mouseState.Position.Y); }
        }

        public static MouseState GetMouseState
        {
            get { return mouseState; }
        }
        public static MouseState GetOldMouseState
        {
            get { return oldMouseState; }
        }

        public static Vector2 MouseSpeed
        {
            get 
            { 
                Point speed = mouseState.Position - oldMouseState.Position; 
                return new Vector2(speed.X, speed.Y); 
            }
        }

        public static KeyboardState GetKeyboardState
        {
            get { return keyboardState; }
        }

        public static KeyboardState GetOldKeyboardState
        {
            get { return oldKeyboardState; }
        }

        public static int ScrollWheelSpeed
        {
            get { return mouseState.ScrollWheelValue - oldMouseState.ScrollWheelValue; }
            
        }

        public static bool LeftButtonDown()
        {
            return mouseState.LeftButton == ButtonState.Pressed;
        }

        public static bool LeftButtonClicked()
        {
            return (oldMouseState.LeftButton == ButtonState.Pressed
                && mouseState.LeftButton == ButtonState.Released);
        }

        public static bool RightButtonClicked()
        {
            return (oldMouseState.RightButton == ButtonState.Pressed
                && mouseState.RightButton == ButtonState.Released);
        }

        public static bool DoubleClicked()
        {
            return doubleClicked;
        }

        public static bool KeyHit(Keys button)
        {
            return (oldKeyboardState.IsKeyDown(button) && keyboardState.IsKeyUp(button));
        }

        public static bool KeyDown(Keys button)
        {
            return (keyboardState.IsKeyDown(button));
        }

        public static void Update(double deltaTime)
        {
            timeSinceClick += deltaTime;

            oldMouseState = mouseState;
            mouseState = Mouse.GetState();

            oldKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();

            doubleClicked = false;
            if (LeftButtonClicked())
            {
                if (timeSinceClick < doubleClickDelay) doubleClicked = true;
                timeSinceClick = 0.0;
            }
        }
    }
}