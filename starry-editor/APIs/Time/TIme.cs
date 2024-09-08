using StarryEditor.Windowing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarryEditor
{
    public static class Time
    {
        public static float DeltaTime
        {
            get
            {
                return Program.MainWindow.DeltaTime; 
            }

            private set { }
        }
    }
}
