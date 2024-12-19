namespace WordFinder.UnitTest
{
    public class WordFinderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTop10MostRepeatedWords_Find_IEnumerableString()
        {
            // Arrange
            var matrix = new List<string>() { 
                "abcdc","fgwio","chill","pqnsd","uvdxy"            
            };
            var wordstream = new List<string>()
            {
                "cold","wind","snow","chill"
            };
            var expected = new List<string>() { "cold", "wind", "chill" };
            // Act
            var wordFinder = new WordFinder(matrix);
            var actual = wordFinder.Find(wordstream);

            // Assert

            Assert.That(actual, Is.EquivalentTo(expected));
        }
        [Test]
        public void GetTop10MostRepeatedWords_Find_IEnumerableWithRepeatedString()
        {

            // Arrange
            var matrix = new List<string>() {
                "abcdc","fgwio","chill","pqnsd","uvdxy"
            };
            // wind twice
            var wordstream = new List<string>()
            {
                "cold","wind","snow","chill", "wind"
            };
            var expected = new List<string>() { "cold", "wind", "chill" };
            // Act
            var wordFinder = new WordFinder(matrix);
            var actual = wordFinder.Find(wordstream);

            // Assert

            Assert.That(actual, Is.EquivalentTo(expected));
        }
        [Test]
        public void GetEmptySetOfStrings_Find_IEnumerableString()
        {
            // Arrange
            // change matrix to avoid find wordstream inside
            var matrix = new List<string>() {
                "abcdd","fgvio","chtll","pqnsd","uvdxy"
            };
            var wordstream = new List<string>()
            {
                "cold","wind","snow","chill"
            };
            var expected = new List<string>();
            // Act
            var wordFinder = new WordFinder(matrix);
            var actual = wordFinder.Find(wordstream);

            // Assert

            Assert.That(actual, Is.EquivalentTo(expected));           
        }
        [Test]
        public void GetEmptySetOfStrings_Find_IEnumerableWithRepeatedStrings()
        {
            // Arrange
            // change matrix to avoid find wordstream inside
            var matrix = new List<string>() {
                "abcdd","fgvio","chtll","pqnsd","uvdxy"
            };
            // wind twice
            var wordstream = new List<string>()
            {
                "cold","wind","snow","chill", "wind"
            };
            var expected = new List<string>();
            // Act
            var wordFinder = new WordFinder(matrix);
            var actual = wordFinder.Find(wordstream);

            // Assert

            Assert.That(actual, Is.EquivalentTo(expected));           
        }        
    }
}