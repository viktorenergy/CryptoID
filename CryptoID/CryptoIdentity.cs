namespace CryptoID;

public class CryptoIdentity
{
    private const string SecretSet = "23456789qwertyuiopasdfghjkzxcvbnm-_";
    private static Random Rnd = new Random();

    public static string Encript(int input)
    {
        string inputAsX = ToXSystem(input);
        return EncriptInput(inputAsX);
    }

    public static int Decrypt(string input)
    {
        char secretKey1 = input[0];
        char secretKey2 = input[1];
        int offset = GetOffset(secretKey1, secretKey2);

        int result = 0;
        string reversed = new string(input.Substring(2).Reverse().ToArray()).ToLower();
        for (var i = 0; i < reversed.Length; i++)
        {
            int index = SecretSet.IndexOf(reversed[i]);

            if (index < 0)
            {
                return -1;
            }

            int value = (index - offset + SecretSet.Length) % SecretSet.Length; 
            int res = value * (int)Math.Pow(SecretSet.Length, i);
            result += res;
        }

        return result;
    }

    private static string ToXSystem(int input)
    {
        List<char> result = new();
        ToXSystemInternal(input, result);
        return new string(result.ToArray());
    }

    private static void ToXSystemInternal(int input, List<char> result)
    {
        if (input == 0) return;
        result.Insert(0, SecretSet[input % SecretSet.Length]);
        ToXSystemInternal(input / SecretSet.Length, result);
    }

    private static string EncriptInput(string inputAsX)
    {
        char secretKey1 = SecretSet[Rnd.Next(SecretSet.Length)];
        char secretKey2 = SecretSet[Rnd.Next(SecretSet.Length)];
        int offset = GetOffset(secretKey1, secretKey2);

        List<char> result = new List<char> { secretKey1, secretKey2 };
        foreach (char c in inputAsX)
        {
            int charIndex = SecretSet.IndexOf(c);
            char encriptedChar = SecretSet[(charIndex + offset) % SecretSet.Length];
            result.Add(encriptedChar);
        }

        return new string(result.ToArray());
    }

    private static int GetOffset(char secretKey1, char secretKey2)
    {
        var key1 = SecretSet.IndexOf(secretKey1);
        var key2 = SecretSet.IndexOf(secretKey2);

        return Math.Abs(key1 - key2);
    }
}
