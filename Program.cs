using System;

namespace calendar_console
{
    class Program
    {
        static string[] header = { "Mo", "Tu", "We", "Th", "Fr", "Sa", "Su" };
        static int[,] calendar = new int[6, 7];

        static void Main(string[] args)
        {

            string input = "2020-09";
            DateTime date = DateTime.Parse(input);
            DateTime firstday = new DateTime(date.Year, date.Month, 1);

            GenerateCalendarByMonth(date, firstday);
            DrawHeader();
            DrawCalendar();
        }

        static void GenerateCalendarByMonth(DateTime date, DateTime firstday)
        {
            int daysIn = DateTime.DaysInMonth(date.Year, date.Month);
            int currentDay = 1;
            var dayofmonth = (int)firstday.DayOfWeek;

            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                for (int j = 0; j < calendar.GetLength(1) && currentDay - dayofmonth + 1 <= daysIn; j++)
                {
                    if (i == 0 && j < dayofmonth)
                    {
                        calendar[i, j] = 0;
                    }
                    else
                    {
                        calendar[i, j] = currentDay - dayofmonth + 1;
                        currentDay++;
                    }
                }
            }

        }

        static void DrawHeader()
        {
            for (int j = 0; j < header.Length; j++)
            {
                if (j == 5 || j == 6)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(header[j] + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(header[j] + " ");
                }
            }
            Console.WriteLine("");
        }

        static void DrawCalendar()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < calendar.GetLength(0); i++)
            {
                for (int j = 0; j < calendar.GetLength(1); j++)
                {
                    if (calendar[i, j] > 0)
                    {
                        if (j == 5 || j == 6)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            if (calendar[i, j] < 10)
                            {
                                Console.Write(" " + calendar[i, j] + " ");
                            }
                            else
                            {
                                Console.Write(calendar[i, j] + " ");
                            }
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            if (calendar[i, j] < 10)
                            {
                                Console.Write(" " + calendar[i, j] + " ");
                            }
                            else
                            {
                                Console.Write(calendar[i, j] + " ");
                            }
                        }
                    }
                    else
                    {
                        Console.Write("   ");
                    }
                }
                Console.WriteLine("");
            }
        }

    }
}
