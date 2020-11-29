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
            Utils.InitGraph();
            
            for (int row = 1; row <= Utils.ScanSizeX; row++)
            {
                Utils.RigthPanel.SetActive(row);

                int coll = 1;
                bool ToRight = true;
                int prevLine = 1;

                while(true)
                {
                    Utils.LinePainter.VerticalLines.VerticalClearLine(prevLine);                    
                    Utils.LinePainter.VerticalLines.VerticalLineTo(coll);
                    
                    Thread.Sleep(3);

                    prevLine = coll;

                    if (ToRight)
                    {
                        coll++;
                    }
                    else
                    {
                        coll--;
                    }

                    if(coll == Utils.ScanSizeY - 1)
                    {
                        ToRight = false;
                    }
                    else if(coll == 1)
                    {                        
                        ToRight = true;
                    }
                }
            }


            /*
            for(int a = 0; a < 3000; a++)
            {
                Utils.RadarScanCycle();
                Thread.Sleep(7);
            }*/





            await Task.Delay(-1);
        }
    }
}
