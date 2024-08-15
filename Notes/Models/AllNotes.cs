using System.Collections.ObjectModel;

namespace Notes.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
    public AllNotes() => LoadNotes();
    public void LoadNotes()
    {
        Notes.Clear();

        //notların tutulduğu yerden alınması
        string appDataPath = FileSystem.AppDataDirectory;

        //*.notes.txt dosyalarını yüklemek için Linq extensionı kullanıcaz
        IEnumerable<Note> notes = Directory

        //Directoryden dosya adlarını seçmek için 
        .EnumerateFiles(appDataPath, "*.notes.txt")

        //Her dosya adını yeni bir note yaratmak için kullan
        .Select(filename => new Note()
        {
            FileName = filename,
            Text = File.ReadAllText(filename),
            Date = File.GetLastWriteTime(filename)
        })

        //En son da elinde olan dosyaların hepsini tarihe göre listele
        .OrderBy(note => note.Date);
        // Her notu ObservableCollection a ekle
        foreach (Note note in notes)
            Notes.Add(note);
    }
}
