using Shopping;

namespace TestShopping
{
    public static class ArticleGenerator
    {
        public static List<Article> Generate(int amountOfArticles)
        {
            {
                List<Article> articles = new List<Article>();
                for (int i = 1; i <= amountOfArticles; i++)
                {
                    articles.Add(new Article(i, "description" + i, i+1 * i));
                }
                return articles;
            }
        }
    }
}
