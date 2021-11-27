using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz19
{
    class Computer
    {
        public Dictionary<string, int> Model { get; set; }//модель с кодом и названием
        public string CPU { get; set; }//тип процессора
        public double Ghz { get; set; }//частота
        public int RAM { get; set; }//оперативная память
        public int Hard { get; set; }//объем жесткого диска
        public int VideoRam { get; set; }//объем памяти видеокарпты
        public int Coast { get; set; }//цена
        public int Count { get; set; }//количество в наличии
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()//создаем список параметризированный компьютером и помещаем в него  записи
            {
            new Computer() { Model=new Dictionary<string, int>(){["MSI"]=1},CPU="intel",Ghz=2.4,RAM=16,Hard=500,VideoRam=128,Coast=1000,Count=5},
            new Computer() { Model=new Dictionary<string, int>(){["Asus"]=2},CPU="amd",Ghz=3.4,RAM=8,Hard=600,VideoRam=264,Coast=5000,Count=32},
            new Computer() { Model=new Dictionary<string, int>(){["MAC"]=3},CPU="amd",Ghz=4.4,RAM=16,Hard=700,VideoRam=512,Coast=10000,Count=28},
            new Computer() { Model=new Dictionary<string, int>(){["Dell"]=4},CPU="intel",Ghz=3.4,RAM=8,Hard=300,VideoRam=128,Coast=500,Count=14},
            new Computer() { Model=new Dictionary<string, int>(){["Pek"]=5},CPU="intel",Ghz=1.4,RAM=5,Hard=400,VideoRam=1024,Coast=600,Count=8},
            new Computer() { Model=new Dictionary<string, int>(){["ScS"]=6},CPU="amd",Ghz=5.4,RAM=24,Hard=600,VideoRam=2048,Coast=900,Count=8},
            new Computer() { Model=new Dictionary<string, int>(){["DHV"]=7},CPU="amd",Ghz=8.4,RAM=36,Hard=700,VideoRam=4096,Coast=1200,Count=62},
            new Computer() { Model=new Dictionary<string, int>(){["MMP"]=8},CPU="amd",Ghz=9.4,RAM=42,Hard=2100,VideoRam=8096,Coast=2200,Count=56},
            };
            Console.WriteLine("_______________________________________________");
             Console.WriteLine("определение компьютеров с указанным процессором");
             Console.WriteLine("_______________________________________________");
             Console.WriteLine("введите тип процессора для поиска");
             string cpu = Console.ReadLine();
             List<Computer> computers = (from c in listComputer//перебираем все значения в списке компьютенров
                                         where c.CPU == cpu
                                         select c).ToList();
                         foreach (Computer c in computers)
             {

                 Console.WriteLine($",{c.CPU},{c.Ghz},{c.RAM},{c.Hard},{c.VideoRam},{c.Coast},{c.Count}");
             }
             Console.WriteLine("________________________________________________________");
             Console.WriteLine("определение компьютеров с объемом ОЗУ не ниже указанного");
             Console.WriteLine("________________________________________________________");
             Console.WriteLine("введите объем ОЗУ");
             int ram = Convert.ToInt32(Console.ReadLine());
             IEnumerable<Computer> computers2 = listComputer
                 .Where(c2 => c2.RAM > ram).ToList();
             foreach (Computer c2 in computers2)
                 Console.WriteLine($"{c2.CPU},{c2.Ghz},{c2.RAM},{c2.Hard},{c2.VideoRam},{c2.Coast},{c2.Count}");
             Console.WriteLine("______________________________");
             Console.WriteLine("сортировка списка по стоимости");
             Console.WriteLine("______________________________");
             var computers3 = (from c3 in listComputer
                               orderby c3.Coast ascending
                               select c3).ToList();
             foreach (var c3 in computers3)
                 Console.WriteLine($"{c3.CPU},{c3.Ghz},{c3.RAM},{c3.Hard},{c3.VideoRam},{c3.Coast},{c3.Count}");
             Console.WriteLine("____________________________________");
             Console.WriteLine("сортировка списка по типу процессора");
             Console.WriteLine("____________________________________");
             var computers4 = (from c4 in listComputer
                               orderby c4.CPU
                               select c4).ToList();
             foreach (var c4 in computers4)
                 Console.WriteLine($"{c4.CPU},{c4.Ghz},{c4.RAM},{c4.Hard},{c4.VideoRam},{c4.Coast},{c4.Count}");
             Console.WriteLine("____________________________________");
             Console.WriteLine("нахождение цены самого дорогого компьютера");
             Console.WriteLine("____________________________________");
             var computers5 = listComputer
                 .Select(c5 => c5.Coast)
                 .Max();
            Console.WriteLine(computers5);
            Console.WriteLine("__________________________________________");
            Console.WriteLine("нахождение цены самого дешевого компьютера");
            Console.WriteLine("__________________________________________");
            var computers6 = listComputer
                .Select(c6 => c6.Coast)
                .Min();
            Console.WriteLine("Цена самого дешевого компьютера равна {0}", computers6); 
            Console.WriteLine("____________________________________________________________");
            Console.WriteLine("есть ли хотя бы один компьютер в количестве не менее 30 штук");
            Console.WriteLine("____________________________________________________________");
            var computers7 = listComputer
                .Where(c7 => c7.Count>30)
                .Any();
            Console.WriteLine(computers7);
            /*IEnumerable<Computer> computers7 = listComputer
                .Where(c7 => c7.Count > 30).ToList();
                
            foreach (Computer c7 in computers7)
            Console.WriteLine($"{c7.CPU},{c7.Ghz},{c7.RAM},{c7.Hard},{c7.VideoRam},{c7.Coast},{c7.Count}");*/

            Console.ReadKey();

        }
    }

}
