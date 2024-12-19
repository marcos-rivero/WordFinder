namespace WordFinder
{
    public class WordFinder
    {
        private readonly IEnumerable<string> _matrix;
        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }
        // Get top 10
        // get empty when no match
        // take care of repeated wordstream
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            try
            {
                // Remove duplicates from wordstream            
                IEnumerable<string> removeDuplicates = wordstream.Distinct().ToList();
                var dictionaryTop10 = new Dictionary<string, int>();
                if (_matrix != null && _matrix.Any() && _matrix.Count() == _matrix.First().Length) 
                {
                    // I will do a new list of string from vertical chars
                    var tmp = new List<string>();                    
                    for (int i = 0; i < _matrix.First().Length; i++)
                    {
                        var newWord = string.Empty;
                        foreach (string s in _matrix)
                        {
                            newWord += s[i];
                        }
                        tmp.Add(newWord);
                    }
                    
                    foreach (var item in removeDuplicates)
                    {   
                        var countHorizontally = _matrix.Count(s => s.Contains(item));
                        var countVertically = tmp.Count(s => s.Contains(item));
                        if(countHorizontally > 0 || countVertically > 0)
                        {
                            dictionaryTop10.Add(item, countHorizontally + countVertically);
                        }                        
                    }
                }
                if(dictionaryTop10.Count > 0)
                {
                    List<string> top10MostRepeated = dictionaryTop10.OrderByDescending(s => s.Value)
                        .Select(s => s.Key)
                        .Take(10)
                        .ToList();
                    return top10MostRepeated;
                }

                return Enumerable.Empty<string>();
            }
            catch(Exception e)
            {
                return Enumerable.Empty<string>();
            }            
        }

    }
}
