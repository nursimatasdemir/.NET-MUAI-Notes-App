using System.IO.Enumeration;

namespace Notes.Models;
internal class Note
{
    public string Filename { get; set; } //A unique identifier(stored on device)
    public string Text { get; set; } //Text of the note
    public DateTime Date { get; set; } //to indicate when the note was created
    public Note()
    {
        Filename = $"{Path.GetRandomFileName()}.notes.txt";
        Date = DateTime.Now;
        Text = "";
    }

    public void Save() =>
    File.WriteAllText(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename), Text);
    public void Delete() =>
    File.Delete(System.IO.Path.Combine(FileSystem.AppDataDirectory, Filename));

    public static Note Load(string filename)
    {
        filename = System.IO.Path.Combine(FileSystem.AppDataDirectory, filename);

        if (File.Exists(filename))
        {
            throw new FileNotFoundException("Unable to find file on local storage.", filename);
        }
        return
        new()
        {
            Filename = Path.GetFileName(filename),
            Text = File.ReadAllText(filename),
            Date = File.GetLastWriteTime(filename)
        };
    }
    public static IEnumerable<Note> LoadAll()
    {
        //get the folder 
        string appDataPath = FileSystem.AppDataDirectory;

        //use Linq extensions to get *.notes.txt files
        return Directory
            //to select file names 
            .EnumerateFiles(appDataPath, "*notes.txt")

            //use each file's name to load the note
            .Select(filename => Note.Load(Path.GetFileName(filename)))

            //now order all notes by date
            .OrderByDescending(note => note.Date);
    }


}
