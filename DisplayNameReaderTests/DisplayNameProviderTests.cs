using DisplayNameService;

namespace DisplayNameServiceTests
{
    public class DisplayNameProviderTests
    {
        public static IEnumerable<object[]> AllDisplayNamesData =>//string characteristic, string expectedDisplayName
        new List<object[]> {
                    new object[] { "ActionSpeed", "Action speed" },
                    new object[] { "Armor", "Armor" },
                    new object[] { "Dmg", "Damage" },
                    new object[] { "Energy", "Energy" },
                    new object[] { "EnergyCost", "Energy cost" },
                    new object[] { "EnergyRestoration", "Energy restoration" },
                    new object[] { "Hp", "Health" },
                    new object[] { "ImpactDistance", "Impact distance" },
                    new object[] { "MovementSpeed", "Movement speed" },
                    new object[] { "Shield", "Shield" },
                    new object[] { "ShieldCost", "Shield cost" }
        };

        [Fact]
        public void PutNonExistNameForJson_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => DisplayNameProvider.GetDisplayNameFromJson("testName"));
        }

        [Theory]
        [MemberData(nameof(AllDisplayNamesData))]
        public void PutName_ShouldReturnDisplayNameFromJson(string characteristic, string expectedDisplayName)
        {
            string actualDisplayName = DisplayNameProvider.GetDisplayNameFromJson(characteristic);

            Assert.Equal(expectedDisplayName, actualDisplayName);
        }
    }
}
