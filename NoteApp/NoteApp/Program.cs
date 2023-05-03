using System.Data;
using System.Xml.Linq;

namespace NoteApp
{
    class Note
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
    class Application
    {
        List<Note> notes;
        public Application()
        {
            notes = new List<Note>()
            {
                new Note { Id = 1, Title="Meeting", Description="Meeting with Client @ 9 AM",Date=new DateTime(2023,3,9)},
                new Note { Id = 2, Title="Pay Bills", Description="Pay Electricity Bills",Date=new DateTime(2012,6,12) },
            };
        }

        public void CreateNote(Note note)
        {
            notes.Add(note);
        }
        public int GenerateNoteId(string title, string description)
        {
            Random rand = new Random();
            int randomNumber = rand.Next(1, 99);
            return randomNumber;
        }


        public Note ViewNote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                    return n;
            }
            return null;

        }
        public bool UpdateNote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                {
                    Console.WriteLine("Update the Note Details");
                    Console.WriteLine("Enter Id");
                    n.Id = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Enter Title");
                    n.Title = Console.ReadLine();
                    Console.WriteLine("Enter Description ");
                    n.Description = Console.ReadLine();
                    return true;
                }

            }
            return false;
        }

        public List<Note> ViewAllNotes()
        {
            Console.WriteLine($"Total Notes :{notes.Count}");
            return notes;

        }

        public bool DeleteNote(int id)
        {
            foreach (Note n in notes)
            {
                if (n.Id == id)
                {
                    notes.Remove(n);
                    return true;
                }
            }
            return false;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            Application obj = new Application();
            string ans = "";
            do
            {
                Console.WriteLine("Take Note App");
                Console.WriteLine("1. Create Note:");
                Console.WriteLine("2. View Note By Id:");
                Console.WriteLine("3. View All Notes:");
                Console.WriteLine("4. Update Note By Id:");
                Console.WriteLine("5. Delete Note By Id");
                
                int choice = 0;
                try
                {
                    Console.WriteLine("enter ur choice");
                    choice=Convert.ToInt16(Console.ReadLine());
                }
                catch(FormatException)
                {
        
                        Console.WriteLine("Enter only Numbers");
                }
                switch (choice)
                {
                    case 1:
                        {

                            Console.WriteLine("Enter Title");
                            string title = Console.ReadLine();
                            Console.WriteLine("Enter Description ");
                            string description = Console.ReadLine();

                            int id = obj.GenerateNoteId(title, description);
                            Console.WriteLine($"Your Note ID is {id}");

                            DateTime date = DateTime.Now;

                            obj.CreateNote(new Note() { Id = id, Title = title, Description = description, Date = date });
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter Note id ");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Note? n = obj.ViewNote(id);
                            if (n == null)
                            {
                                Console.WriteLine("Note with specified id does not exists");
                            }
                            else
                            {
                                Console.WriteLine($" {n.Id} {n.Title} {n.Description} ");
                            }


                            break;

                        }
                    case 3:
                        {

                            Console.WriteLine("id \t\t title \t\t description \t\t date");
                            foreach (var n in obj.ViewAllNotes())
                            {
                                Console.WriteLine($" {n.Id}\t {n.Title} \t {n.Description} {n.Date}");
                            }

                            break;
                        }
                    case 4:
                        {

                            Console.WriteLine("Enter Note ID");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.UpdateNote(id))
                            {
                                Console.WriteLine("Note Detail Updated Successfully!!");
                            }
                            else
                            {
                                Console.WriteLine("Note with specified id does not exist");
                            }
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Note id:");
                            int id = Convert.ToInt16(Console.ReadLine());
                            if (obj.DeleteNote(id))
                            {
                                Console.WriteLine("Note deleted successfully");
                            }
                            else
                            {
                                Console.WriteLine("Note with specified id does not exist");
                            }
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice!!!!");
                            break;
                        }
                }
                Console.WriteLine("Do you wish to continue?[y/n");
                ans = Console.ReadLine();
            }
            while (ans.ToLower() == "y");
        }
    }
}

