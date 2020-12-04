using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Console.WriteLine("Hello World!");
        }
        private class Official
        {
            public int Reference { get; set; }
            public Official[] Officials { get; set; }
            public Official(int reference)
            {
                Reference = reference;
            }
            public Official(int reference, Official[] officials)
            {
                Reference = reference;
                Officials = officials;
            }
        }
        private static void Task1()
        {
            Official official = new Official(1, new Official[]
            {
                new Official(2, new Official[]
                {
                    new Official(31, new Official[]
                    {
                        new Official(41, new Official[]
                        {
                            new Official(51),
                            new Official(51),
                            new Official(51),
                            new Official(51)
                        }),
                        new Official(42, new Official[]
                        {
                            new Official(52),
                            new Official(52),
                            new Official(52),
                            new Official(52)
                        }),
                        new Official(43, new Official[]
                        {
                            new Official(53),
                            new Official(53),
                            new Official(53),
                            new Official(53)
                        })
                    }),
                    new Official(332, new Official[]
                    {
                        new Official(441, new Official[]
                        {
                            new Official(551),
                            new Official(551),
                            new Official(551),
                            new Official(551)
                        }),
                        new Official(442, new Official[]
                        {
                            new Official(552),
                            new Official(552),
                            new Official(552),
                            new Official(552)
                        }),
                        new Official(443, new Official[]
                        {
                            new Official(553),
                            new Official(553),
                            new Official(553),
                            new Official(553)
                        })
                    })
                })
            });

            Official[] officials = official.Officials;
            Stack<Official[]> historyOfficials = new Stack<Official[]>();
            Official[] _prev = null;
            Official[] prev = null;
            historyOfficials.Push(officials);
            int index = 0;
            int nullIndex = 0;
            bool len = false;
            while (true)
            {
                if (officials != null)
                {
                    if (!len)
                    {
                        for (int i = 0; i < officials.Length; i++)
                        {
                            if (officials[i].Officials != null)
                                historyOfficials.Push(officials[i].Officials);
                        }
                        len = true;
                    }
                    else
                    {
                        if (officials[index].Officials == null)
                        {
                            officials = _prev;
                            index = nullIndex++;
                        }
                        _prev = prev;
                        prev = officials;
                        if (officials.Length == index)
                            break;
                        officials = officials[index].Officials;
                        len = false;
                    }
                }
                else
                    break;
            }
            foreach (var of in historyOfficials)
            {
                for (int i = of.Length - 1; i >= 0; i--)
                    Console.WriteLine(of[i].Reference);
            }
        }
        private static void Task2()
        {
        }
        private static void Task3()
        {
            // вывод строк будет бесконечен, т. к. число в цикле беззнаковое,
            // мы никогда не достигнем отрицательного числа и по условию всегда будет true
        }
    }
}
