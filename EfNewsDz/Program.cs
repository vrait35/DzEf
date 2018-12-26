using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EfNewsDz
{
    class Program
    {
       public static string menu1 = "Создать комментарий";
       public static string menu2 = "Создать новость";
       public static string menu3 = "Показать все";
       public static string menu4 = "редактировать новость";
       public  static void Main(string[] args)
        {
            string upKey = "нажмите ченить";
            string upId = "введите id  новости";
            string upNewHeader = "введите новый заголовок новости";
            string upNeContent = "введите новый контент для новости";
            string upComment = "введите комментарий";
            string upHeader = "введите заголовок для новости";
            string upContent = "введите контент для новости";           
            var user = new User
            {
                Login = "anuar.temirbolat",
                Password = "asd123",
                Id=1
            };           
            ConsoleKeyInfo key;
            int y = 1;

            while (true)
            {
                Show(ref y);
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.DownArrow) { if (y < 4) y++; }
                else if (key.Key == ConsoleKey.UpArrow) { if (y > 1) y--; }
                else if (key.Key == ConsoleKey.Enter)
                {
                    switch (y)
                    {
                        case 1:
                            {
                                Console.Clear();
                                using (var context = new NewsContext())
                                {
                                    var news = context.News.ToList();
                                    int index = 0;
                                    foreach (var n in news)
                                    {
                                        Console.WriteLine(n.Id + " . " + n.Header);
                                        //index++;
                                    }
                                    Console.WriteLine(upId);
                                    bool isTrue = false;
                                    var userss = context.Users.ToList();
                                    while (isTrue == false)
                                    {
                                        try
                                        {
                                            index = int.Parse(Console.ReadLine());
                                            isTrue = true;
                                        }
                                        catch (FormatException e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        catch (OverflowException e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        catch (ArgumentNullException e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                    }
                                    isTrue = false;
                                    Console.WriteLine(upComment);
                                    string text = Console.ReadLine();
                                    try
                                    {
                                        context.Comments.Add(new Comment
                                        {
                                            Text = text,
                                            News = news[index - 1],
                                            User = userss[0]
                                        });
                                    }
                                    catch (System.ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                   
                                    try
                                    {
                                        context.SaveChanges();
                                    }
                                    catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch(System.Data.Entity.Validation.DbEntityValidationException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.Clear();
                            }
                            break;
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine(upHeader);
                                var head = Console.ReadLine();
                                Console.WriteLine(upContent);
                                var content = Console.ReadLine();
                                using (var context = new NewsContext())
                                {
                                    context.News.Add(new News
                                    {
                                        Header = head,
                                        Content = content
                                    });
                                    context.SaveChanges();
                                }
                                Console.Clear();
                            }
                            break;
                        case 3:
                            {
                                Console.Clear();
                                using (var context = new NewsContext())
                                {
                                    List<News> news1 = context.News.Include(c => c.Comments).ToList();
                                    foreach(var n in news1)
                                    {
                                        Console.WriteLine(n.Header);
                                        Console.WriteLine("----------------");
                                        foreach(var c in n.Comments)
                                        {
                                            var userComment = context.Users.Where(q => q.Id == c.User.Id).FirstOrDefault();                                            
                                            Console.WriteLine(userComment.Login+" : "+c.Text);                                            
                                        }
                                    }
                                }
                                Console.WriteLine(upKey);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        case 4:
                            {
                                using (var context = new NewsContext())
                                {
                                    Console.Clear();

                                    var newss = context.News.ToList();                                  
                                    foreach (var n in newss)
                                    {
                                        Console.WriteLine(n.Id + " . " + n.Header);
                                        //index++;
                                    }

                                    Console.WriteLine(upId);
                                bool isTrue = false;
                                int index = 0;                                                               
                                while (isTrue == false)
                                {
                                    try
                                    {
                                        index = int.Parse(Console.ReadLine());
                                        isTrue = true;
                                    }
                                    catch (FormatException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (OverflowException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (ArgumentNullException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.WriteLine(upNewHeader);
                                string newHeader = Console.ReadLine();
                                Console.WriteLine(upNeContent);
                                string newContent = Console.ReadLine();                               
                                    var news = context.News.ToList();
                                    var res = context.News.Find(index);
                                    try
                                    {
                                        res.Content = newContent;
                                        res.Header = newHeader;
                                        context.SaveChanges();
                                    }
                                    catch(NullReferenceException e)
                                    {
                                        Console.WriteLine( e.Message);
                                    }
                                    catch(Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                }
                                Console.Clear();                                
                                break;
                            }
                    }
                }
            }
        }
        public static void Show(ref int y)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            if (y == 1) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 1);
            Console.Write(menu1);
            if (y == 2) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 2);
            Console.Write(menu2);
            if (y == 3) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 3);
            Console.Write(menu3);
            if (y == 4) Console.ForegroundColor = ConsoleColor.DarkRed;
            else Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(0, 4);
            Console.Write(menu4);
        }
    }
}

















