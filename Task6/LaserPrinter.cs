using System;
using System.Text;
using System.Threading;

namespace ITTask6
{
    public class LaserPrinter : Printer
    {
        public bool RefilledСartridge { get; set; }

        public LaserPrinter(string name, Position position, bool refilledСartridge) : base(name, position)
        {
            RefilledСartridge = refilledСartridge;
        }

        public override void Print()
        {
            if (this.Connect)
            {
                if (RefilledСartridge && this.PapersQueue.Count != 0)
                {
                    Console.WriteLine("Начало печати");
                    Random rnd = new Random();
                    foreach (var paper in this.PapersQueue)
                    {
                        Console.WriteLine("Печать на странице " + paper.Number);
                        string newMessage = GenRandomString("QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm",
                            rnd.Next(0, 100));
                        paper.Message.Append(newMessage);
                    }

                    Thread.Sleep(4000);
                    Console.WriteLine("Печать завершена");
                    Console.WriteLine("Просмотр печати:");
                    foreach (var paper in this.PapersQueue)
                    {
                        Console.WriteLine(paper.Number + " " + paper.Message);
                    }
                    Thread.Sleep(4000);
                    return;
                }

                if (!RefilledСartridge)
                {
                    Console.WriteLine("Ошибка! Заправьте картридж");
                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine("Вставьте бумагу");
                    Thread.Sleep(2000);
                }
            }
            else
            {
                Console.WriteLine("Принтер не подключен");
                Thread.Sleep(2000);
            }
        }
        
        public void RefillTheCartridge()
        {
            if (!RefilledСartridge)
            {
                RefilledСartridge = true;
                Console.WriteLine("Заправляется картридж");
                Thread.Sleep(2000);
                return;
            }
            else
            {
                Console.WriteLine("Картридж заправлен");
                Thread.Sleep(1000);
            }
        }

        private string GenRandomString(string Alphabet, int Length)
        {
            Random rnd = new Random();
            StringBuilder sb = new StringBuilder(Length-1);
            int Position = 0;
            for (int i = 0; i < Length; i++)
            {
                Position = rnd.Next(0, Alphabet.Length-1);
                sb.Append(Alphabet[Position]);                
            }
            return sb.ToString();
        }
        
    }
}