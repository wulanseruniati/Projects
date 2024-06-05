using System.Security.Cryptography;
using System.Text.Json;
using Newtonsoft.Json;

namespace OthelloLogic
{
    public class FileManager
    {
        //write log into file
        public static void WriteLog(string path, string logMessage)
        {
            using (StreamWriter stream = new(path))
            {
                stream.WriteLine(logMessage);
            }
        }
        //appends log in file
        public static void AppendLog(string path, string logMessage)
        {
            using (FileStream fs = new(path, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter outputFile = new StreamWriter(fs))
                {
                    outputFile.WriteLine(logMessage);
                }
            }
        }
        //read a log file
        public static string ReadLog(string path)
        {
            string? result;
            using (StreamReader stream = new(path))
            {
                result = stream.ReadLine();
            }
            return (result != null) ? result : String.Empty;
        }
        //write player data into JSON file
        public static void CreatePlayerData(Dictionary<Color, IPlayer> playerColor)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(playerColor);
            using (StreamWriter sw = new("PlayerFile.json"))
            {
                sw.WriteLine(json);
            }
        }
        //load player data from JSON file
        public static Dictionary<Color, Player> LoadPlayerData(string path)
        {
            string result;
            using (StreamReader sr = new(path))
            {
                result = sr.ReadToEnd();
            }
            return System.Text.Json.JsonSerializer.Deserialize<Dictionary<Color, Player>>(result);
        }
        //write board data into JSON file
        public static void CreateDiscData(IDisc[,] discs)
        {
            //creating a dictionary
            Dictionary<Position, Color> dictionary = new Dictionary<Position, Color>();
            for (int row = 0; row < GameController.boardsize; row++)
            {
                for (int column = 0; column < GameController.boardsize; column++)
                {
                    Color color = discs[row, column].Color;
                    dictionary.Add(new Position(row, column), color);
                }
            }
            // Serialize 2D array to JSON
            string serializedJson = JsonConvert.SerializeObject(discs);

            // Write JSON to a file
            string filePath = "BoardData.json";
            WriteJsonToFile(filePath, serializedJson);

            Console.WriteLine($"JSON written to file: {filePath}");
        }
        //load disc data
        public static Disc[,] LoadDiscData(string path)
        {
            // Read JSON from file
            string serializedJson1 = ReadJsonFromFile(path);

            // Deserialize JSON to 2D array
            Disc[,] deserializedArray2D = DeserializeJsonTo2DArray(serializedJson1);
            return deserializedArray2D;
        }
        //save player turn
        public static void CreateCurrentColorData(Color currentColor)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(currentColor);
            using (StreamWriter sw = new("TurnFile.json"))
            {
                sw.WriteLine(json);
            }
        }
        //
        public static Color LoadCurrentColorData(string path)
        {
            string result;
            using (StreamReader sr = new(path))
            {
                result = sr.ReadToEnd();
            }
            return System.Text.Json.JsonSerializer.Deserialize<Color>(result);
        }
        //helper method
        static void WriteJsonToFile(string filePath, string json)
        {
            File.WriteAllText(filePath, json);
        }
        //helper method
        static string ReadJsonFromFile(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        static Disc[,] DeserializeJsonTo2DArray(string serializedJson)
        {
            return JsonConvert.DeserializeObject<Disc[,]>(serializedJson);
        }
    }
}
