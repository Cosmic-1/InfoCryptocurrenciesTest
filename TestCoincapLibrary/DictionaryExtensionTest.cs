using CoincapLibrary.Extensions;

namespace TestCoincapLibrary
{
    [TestClass]
    public class DictionaryExtensionTest
    {
        const string GENERATE_STRINGS = "key=value&key1=value&key2=value",
            GENERATE_INTEGERS = "1=2&2=3",
            GENERATE_EMPTY = "";

        readonly Dictionary<int, long> dictionaryIntegers;
        readonly Dictionary<string, string> dictionaryStrings;
        readonly Dictionary<string, string> dictionaryEmpty;
        public DictionaryExtensionTest()
        {
            dictionaryStrings = new Dictionary<string, string>()
            {
                {"key", "value"},
                { "key1","value" },
                { "key2","value" },
            };

            dictionaryIntegers = new Dictionary<int, long>()
            {
                {1,2},
                {2,3},
            };

            dictionaryEmpty = new();
        }

        [TestMethod]
        public void ConvertDictionaryToUriQueriesString()
        {
            var generateDataIntegers = dictionaryIntegers.GenerateUriQueries();
            var generateDataEmpty = dictionaryEmpty.GenerateUriQueries();
            var generateDataStrings = dictionaryStrings.GenerateUriQueries();

            AssertsConvert(generateDataIntegers, GENERATE_INTEGERS);
            AssertsConvert(generateDataEmpty, GENERATE_EMPTY);
            AssertsConvert(generateDataStrings, GENERATE_STRINGS);
        }

        private void AssertsConvert(string generateData, string compaire)
        {
            Assert.IsNotNull(generateData);
            Assert.AreEqual(generateData, compaire);
        }
    }
}