namespace RobotApp.Services.Dtos
{
    public static class DisplayName
    {
        public static readonly Dictionary<string, string> _displayNames = new Dictionary<string, string>()
        {
            { "ActionSpeed", "Action speed" },
            { "Armor", "Armor" },
            { "Dmg", "Damage" },
            { "Energy", "Energy" },
            { "EnergyCost", "Energy cost"},
            { "EnergyRestoration", "Energy restoration" },
            { "Hp", "Health" },
            { "ImpactDistance", "Impatc distance" },
            { "MovementSpeed", "Movement speed" },
            { "Shield", "Shield"},
            { "ShieldCost", "Shield cost"}
        };

        public static string GetDisplayName(string key)
        {
            if (_displayNames.TryGetValue(key, out var displayName))
            {
                return displayName;
            }
            return "";
        }
    }
}
