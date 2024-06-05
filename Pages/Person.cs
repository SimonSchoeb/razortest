public class Person
{
    const string filename = "data/person.json";
    static List<Person>? pl;
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }

    public static List<Person> list {
    get 
        {
        if (pl != null) return pl;
        String data = System.IO.File.ReadAllText(filename);
        pl = System.Text.Json.JsonSerializer.Deserialize<List<Person>>(data);
        if (pl == null) return new List<Person>();
        return pl;
        }
    }

    public static void Save() {
        if (pl != null) lock (pl) {
            String data = System.Text.Json.JsonSerializer.Serialize(pl, 
            new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filename, data);
            }
    }
}
