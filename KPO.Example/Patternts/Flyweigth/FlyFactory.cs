namespace KPO.Example.Patternts.Flyweigth;

public class FlyFactory
{
    private Dictionary<string, Character> _chars = new ();

    public Character GetCharacter(string @char)
    {
        if (_chars.TryGetValue(@char, out var character))
        {
            return character;
        }
        
        switch (@char)
        {
            case "A":
                character = new CharacterA();
                break;
            case "B":
                character = new CharacterB();
                break;
            default:
                throw new ArgumentException("Invalid character");
        }
        _chars.Add(@char, character);
        return character;
    }
}