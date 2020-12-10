﻿
//Для интерфейса необходимо определить 1 свойство и 2 метода.
//Абстрактный класс должен содержать 3-5 свойств и 3-5 методов(включая унаследованные свойства интерфейса). 
//Класс должен содержать дополнительно 2 свойства и 2 метода.
//В программе реализовать работу со списком объектов, который должен содержать объекты типа интерфейса.
// interface Устройство Печати -> abstract class Принтер -> class Лазерный принтер.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITTask6
{
    class Program
    {
        static List<Paper> paper = new List<Paper>();
        
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                paper.Add(new Paper(i));
            }
            List<IPrintingDevice> printingDevices = new List<IPrintingDevice>();
            int choice = -1;
            while (choice != 0)
            {
                Console.Clear();
                Console.WriteLine("[1] Создать новый принтер");
                Console.WriteLine("[2] Удалить принтер");
                Console.WriteLine("[3] Выбрать принтер");

                int.TryParse(Console.ReadLine(), out choice);
                switch (choice)
                {
                    case 1:
                        Console.Clear();
                        printingDevices.Add(Create());
                        break;
                    case 2:
                        Console.Clear();
                        ShowAllPrinters(printingDevices);
                        int index;
                        int.TryParse(Console.ReadLine(), out index);
                        if (index != 0)
                            printingDevices.RemoveAt(index-1);
                        break;
                    case 3:
                        Console.Clear();
                        ShowAllPrinters(printingDevices);
                        int id;
                        int.TryParse(Console.ReadLine(), out id);
                        if (id != 0)
                        {
                             Action(printingDevices[id-1]);
                        }
                        break;
                }
            }
        }
        public static IPrintingDevice Create()
        {
            Console.WriteLine("Имя принтера");
            string name = Console.ReadLine();
            Console.WriteLine("Степень устройства");
            Position pos=Position.AdditionalPrinter;
            int position;
            
            foreach (Position item in Enum.GetValues(typeof(Position)))
            {
                int i = (int)item;
                Console.WriteLine("[" + i + "] " + EnumExtension.GetDescription(item));
                
            }
            
            int.TryParse(Console.ReadLine(), out position);
            if (Enum.IsDefined(typeof(Position), position))
            {
                pos = (Position)Enum.ToObject(typeof(Position), position);
            }
            return new LaserPrinter(name, pos,false);
        }

        public static void ShowAllPrinters(List<IPrintingDevice> printingDevices)
        {
            for (int i = 0; i < printingDevices.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "] " + printingDevices[i].Name + " "+EnumExtension.GetDescription(((Printer)printingDevices[i]).Position));
            }
        }
        
        public static void ShowPossibleActions(IPrintingDevice iPrintingDevice)
        {
            Console.WriteLine("[1] Подсоединить устройство");
            Console.WriteLine("[2] Печать");
            if (iPrintingDevice as LaserPrinter != null)
            {
                Console.WriteLine("[3] Заправить бумагу");
                Console.WriteLine("[4] Заправить картридж");
                Console.WriteLine("[5] Посмотреть местонахождение принтера");
                Console.WriteLine("[6] Извлечь бумагу");
            }
        }
        
        public static void ShowAllPaper(List<Paper> papers)
        {
            for (int i = 0; i < papers.Count; i++)
            {
                Console.WriteLine("[" + (i + 1) + "]" + papers[i]
                );
            }
        }
        
        public static Queue<Paper> SelectPaper()
        {
            Queue<Paper> selectPaper = new Queue<Paper>();
                        
            int id = -1;
            while (id != 0)
            {
                ShowAllPaper(paper);
                int.TryParse(Console.ReadLine(), out id);
                if (id != 0)
                {
                    selectPaper.Enqueue(paper[id-1]);
                    paper.RemoveAt(id-1);
                }
            }
            return selectPaper;
        }

        public static void Action(IPrintingDevice printingDevice)
        {
            int choice1 = -1;
            while (choice1 != 0)
            {
                Console.Clear();
                ShowPossibleActions(printingDevice);
                int.TryParse(Console.ReadLine(), out choice1);
                Console.Clear();
                switch (choice1)
                {
                    case 1:
                        printingDevice.ConnectDevice();                       
                        break;
                    case 2:
                        ((LaserPrinter)printingDevice).Print();
                        break;
                    case 3:
                        ((LaserPrinter)printingDevice).FillInThePaper(SelectPaper());
                        break;
                    case 4:
                        ((LaserPrinter)printingDevice).RefillTheCartridge();
                        break;
                    case 5:
                        ((LaserPrinter)printingDevice).findPrinter();
                        break;
                    case 6:
                        ((LaserPrinter)printingDevice).getPapers();
                        break;
                }
            }
        }
    }
}
