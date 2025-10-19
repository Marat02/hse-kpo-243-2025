using KPO.Example.Composite;
using KPO.Example.Models.Checks;

namespace KPO.Example.Models.Flyweigth;

/// <summary>
/// Фабрика для приспособленца
/// </summary>
public class CheckFactory
{
    private readonly Dictionary<string, ICheck> _checks = new();
    private readonly CommonFlyweigth _commonFlyweigth = new("Common");
    
    public ICheck GetCheck(string name)
    {
        if (!_checks.ContainsKey(name))
        {
            switch (name)
            {
                case "Folder":
                    _checks[name] = new FolderCheck(_commonFlyweigth.Name, new Folder(name));
                    break;
                case "Part":
                    _checks[name] = new PartCheck(_commonFlyweigth.Name, "Part 1");
                    break;
                case "Common":
                    _checks[name] = new CommonCheck(_commonFlyweigth.Name);
                    break;
                default:
                    throw new ArgumentException("Invalid check name");
            }
        }

        return _checks[name];
    }
}