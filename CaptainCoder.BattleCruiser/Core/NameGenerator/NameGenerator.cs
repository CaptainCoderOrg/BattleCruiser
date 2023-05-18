using System.Text;
using CaptainCoder.Core;
namespace CaptainCoder.BattleCruiser;


// Big, Small, Tiny, Gigantic
// Red, Green , Blue, Yellow, etc.
// Dog, Cat, Frog, Gorilla, 
public class NameGenerator
{
    private readonly string[][] _wordGroups;
    private readonly StringBuilder _builder = new();
    public NameGenerator(IEnumerable<string> firstWords, params IEnumerable<string>[] additionalWords)
    {
        _wordGroups = new string[additionalWords.Length + 1][];
        _wordGroups[0] = firstWords.ToArray();
        for (int ix = 1; ix < _wordGroups.Length; ix++)
        {
            _wordGroups[ix] = additionalWords[ix - 1].ToArray();
        }
    }

    public string GenerateName(IRandom randomSource)
    {
        _builder.Clear();
        foreach (string[] wordGroup in _wordGroups)
        {
            int randomIx = randomSource.Next(0, wordGroup.Length);
            _builder.Append(wordGroup[randomIx]);
        }
        return _builder.ToString();
    }

    public string GenerateName() => GenerateName(IRandom.Shared);
}