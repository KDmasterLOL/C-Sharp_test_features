using System.IO;
using System.Text;

namespace test_features;

public class SystemIO
{
    private const string fileName = "File.dat";
    public SystemIO()
    {
    }
    public void WriteDefaultValues()
    {
        using (FileStream stream = File.Open(fileName, FileMode.Create))
        {
            using (BinaryWriter writer = new(stream, Encoding.UTF8, false))
            {
                writer.Write(1.250F);
                writer.Write("HELLO");
            }
        }
    }
    public void DisplayDefaultValues()
    {
        float ratio;
        string str;

        if (File.Exists(fileName))
        {
            using (FileStream stream = File.Open(fileName, FileMode.Open))
            {
                using (BinaryReader reader = new(stream, Encoding.UTF8, false))
                {
                    ratio = reader.ReadSingle();
                    str = reader.ReadString();
                }
            }

            WriteLine("Ratio is " + ratio);
            WriteLine("String is " + str);
        }
    }
}

