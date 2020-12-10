using System;
using System.Collections.Generic;
using System.Threading;

namespace ITTask6
{
    public abstract class Printer : IPrintingDevice
    {
        public string Name { get; set; }
        
        public bool Connect { get; set; }
        
        public Position Position { get; set; }
        
        public Queue<Paper> PapersQueue { get; set; }
        
        public Printer(String name, Position position)
        {
            Name = name;
            Position = position;
            PapersQueue = new Queue<Paper>();
            Connect = false;
        }

        
        public abstract void Print();
        
        public void ConnectDevice()
        {
            if (!Connect){
                Console.WriteLine("Выполняется соединение устройста");
                Connect = true;
                Console.WriteLine("Соединение установлено");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Устройство уже соединено");
                Thread.Sleep(1000);
            }
        }

        public void FillInThePaper(Queue<Paper> papers)
        {
            Console.WriteLine("Идет заправка бумаги");
            PapersQueue = papers;
            Console.WriteLine("Добавленно "+ papers.Count + " бумаги");
            Thread.Sleep(5000);
        }
        
        public List<Paper> getPapers()
        {
            List<Paper> result = new List<Paper>();
            Console.WriteLine("Извлечение бумаги");
            foreach (var paper in PapersQueue)
            {
                result.Add(paper);
                Console.WriteLine(paper);
            }
            PapersQueue = new Queue<Paper>();
            Thread.Sleep(2000);
            return result;
        }
        
        public void findPrinter()
        {
            switch (this.Position)
            {
                case Position.AdditionalPrinter:
                    Console.WriteLine("Дополнительный принтер находится у кофемашины");
                    break;
                case Position.TheMainPrinter:
                    Console.WriteLine("Основной принтер у шефа");
                    break;
            }
            Thread.Sleep(2000);
        }
        
    }
}