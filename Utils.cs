using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.IO;

namespace ConsoleApp1
{
    enum TargetSize
    {
        size1,
        size2,
        size3
    }

    class Target
    {
        public byte X;
        public byte Y;
        public TargetSize Size;
    }


    static class Utils
    {
        /// <summary>
        /// Область сканирования по Х
        /// </summary>
        public static int ScanSizeX;

        /// <summary>
        /// Размер сканирования по Y
        /// </summary>
        public static int ScanSizeY;
        public static int prevLineX = 1;

        /// <summary>
        /// Установка параметров консоли
        /// </summary>
        public static void ConsoleInit()
        {
            ScanSizeX = 40;
            ScanSizeY = 96;

            Console.SetWindowSize(100, 43);
            Console.CursorVisible = false;
        }
        
        public static void Init()
        {
            StreamReader Reader = new StreamReader("Carcas.txt");

            while (!Reader.EndOfStream)
            {
                Console.WriteLine(Reader.ReadLine());
            }

            Reader.Close();
        }

        /// <summary>
        /// Методы для отрисовки линий по вертикали и горизонтали
        /// </summary>
        public static class LinePainter
        {
            public static class VerticalLines
            {
                /// <summary>
                /// Поставить линию в колонку
                /// </summary>
                /// <param name="x">Номер колонки</param>
                /// <param name="startPos">С какой начать рисовать</param>
                /// <param name="endPos">До какой рисовать</param>
                public static void VerticalLineTo(int x, int startPos = 1, int endPos = 42)
                {
                    for (int y = startPos; y < endPos; y++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Write("|");
                    }

                    prevLineX = x;
                }

                /// <summary>
                /// Стереть линию с колонки
                /// </summary>
                /// <param name="x"></param>
                /// <param name="startPos">С какой начать стирать</param>
                /// <param name="endPos">До какой стирать</param>
                public static void VerticalClearLine(int x, int startPos = 1, int endPos = 42)
                {
                    for (int y = startPos; y < endPos; y++)
                    {
                        Console.SetCursorPosition(x, y);
                        Console.Out.Write(" ");
                    }
                }
            }

            public static class HorizontalLines
            {
                public static void HorizontalLineTo(int y, int startPos = 1, int endPos = 99)
                {
                    Console.SetCursorPosition(startPos, y);

                    for (int x = startPos; x < endPos; x++)
                    {
                        Console.Out.Write("-");
                    }
                }

                public static void HorizontalClearLine(int y, int startPos = 1, int endPos = 99)
                {
                    Console.SetCursorPosition(startPos, y);

                    for (int x = startPos; x < endPos; x++)
                    {
                        Console.Out.Write(" ");
                    }
                }
            }

        }

        /// <summary>
        /// Указатель положения антенны радара по вертикали
        /// </summary>
        public static class RigthPanel
        {
            public static string Symb = "<";
            private static int PanelY = 97;
            private static int prevRow = 0;

            public static void SetActive(int row, bool clear = true)
            {
                if(clear && prevRow != 0)
                {
                    Console.SetCursorPosition(PanelY, prevRow);
                    Console.Write(" ");
                }

                Console.SetCursorPosition(PanelY, row);
                Console.Write(Symb);

                prevRow = row;
            }
        }
        
    }
}
