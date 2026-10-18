using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class Menu
    {
        public string Title { get; set; }
        Option[] options = new Option[20];
        public void AddOption(string title, ConsoleKey key,Action action)
        {
            for(int i = 0; i< options.Length;i++)
            {
                if(options[i] == null)
                {
                    options[i] = new Option() { key = key, title = title, action = action };
                    break;
                }
            }
        }
        public Option FindOption(ConsoleKey key)
        {
            foreach (var option in options)
            {
                if(option!=null && option.key == key)
                    return option;
            }
            return null;
        }
        
        public Menu(string title) 
        {
            Title = title;
        }
        public void Show()
        {
            Console.WriteLine();
            Console.WriteLine(Title);
            foreach (var option in options)
            { 
                if(option != null)
                    Console.Write($"({(char)option.key}){option.title} ");
            }
        }
        
    }
}
