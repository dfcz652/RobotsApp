using DisplayNameService;

namespace DisplayNameServiceTests
{
    public class TestUtils
    {
        public static void AssertEqualsCharacteristicDisplayNames(CharacteristicDisplayNames expected, CharacteristicDisplayNames actual)
        {
            List<CharacteristicDisplayName> expectedList = expected.Characteristics;
            List<CharacteristicDisplayName> actualList = actual.Characteristics;

            Assert.Equal(expectedList.Count, actualList.Count);

            Assert.Equal(expectedList.Select(c => c.Name), actualList.Select(c => c.Name));
            Assert.Equal(expectedList.Select(c => c.DisplayName), actualList.Select(c => c.DisplayName));
        }
    }
}
