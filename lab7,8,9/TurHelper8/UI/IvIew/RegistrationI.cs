using System;
using System.Collections.Generic;
using System.Text;

namespace TurHelper8.UI.IvIew
{
    public interface RegistrationI
    {
        event Action FormLoaded;
        event Action RefreshForm;

        public void SetError(string s);
    }
}
