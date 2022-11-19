using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public sealed class KeyPressHandler
    {
        public event EventHandler<KeyPressEventArgs>? KeyPressed;

        public void OnKeyPressed(char keyCode)
        {
            KeyPressed?.Invoke(this, new KeyPressEventArgs(keyCode));
        }
    }

    public sealed class KeyPressEventArgs : EventArgs
    {
        public char KeyCode { get; }
        public KeyPressEventArgs(char keyCode)
        {
            KeyCode = keyCode;
        }
    }
}
