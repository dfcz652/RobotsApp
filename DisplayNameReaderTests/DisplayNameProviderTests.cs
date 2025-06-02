using DisplayNameService;

namespace DisplayNameServiceTests
{
    public class DisplayNameProviderTests
    {
        DisplayNameProvider displayNameProvider = new();

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
            Assert.Throws<InvalidDataException>(() => displayNameProvider.GetDisplayNameFromJson("testName"));
        }

        [Theory]
        [MemberData(nameof(AllDisplayNamesData))]
        public void PutName_ShouldReturnDisplayNameFromJson(string characteristic, string expectedDisplayName)
        {
            string actualDisplayName = displayNameProvider.GetDisplayNameFromJson(characteristic);

            Assert.Equal(expectedDisplayName, actualDisplayName);
        }

        [Fact]
        public void PutNonExistNameForXml_ShouldThrowInvalidDataException()
        {
            Assert.Throws<InvalidDataException>(() => displayNameProvider.GetDisplayNameFromXml("testName"));
        }

        [Theory]
        [MemberData(nameof(AllDisplayNamesData))]
        public void PutName_ShouldReturnDisplayNameFromXml(string characteristic, string expectedDisplayName)
        {
            string actualDisplayName = displayNameProvider.GetDisplayNameFromXml(characteristic);

            Assert.Equal(expectedDisplayName, actualDisplayName);
        }
    }
}
