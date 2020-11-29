using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Utils.ConsoleInit();
            Utils.Init();
            
            int Antenna_X_Pos = 1;
            int Antenna_Y_Pos = 1;
            int prev_Antenna_Y_Pos = 1;
            bool ToRight = true;

            Utils.RigthPanel.SetActive(Antenna_X_Pos);

            while (true)
            {
                Utils.LinePainter.VerticalLines.VerticalClearLine(prev_Antenna_Y_Pos);
                Utils.LinePainter.VerticalLines.VerticalLineTo(Antenna_Y_Pos);

                Thread.Sleep(3);

                prev_Antenna_Y_Pos = Antenna_Y_Pos;

                if (ToRight)
                {
                    Antenna_Y_Pos++;
                }
                else
                {
                    Antenna_Y_Pos--;
                }

                if (Antenna_Y_Pos == Utils.ScanSizeY - 1)
                {
                    ToRight = false;
                }
                else if (Antenna_Y_Pos == 1)
                {
                    Utils.RigthPanel.SetActive(Antenna_X_Pos++);
                    ToRight = true;
                }

            }

            await Task.Delay(-1);
        }
    }
}
