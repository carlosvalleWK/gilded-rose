using GildedRose.Console.DataAccessLayer;
using GildedRose.Console.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class GildedRoseProcess : IGildedRoseProcess
    {
        private readonly IArticlesRepository _articlesRepository;

        public GildedRoseProcess(IArticlesRepository articlesRepository)
        {
            _articlesRepository = articlesRepository;
        }

        public void RunGildedRoseProcess()
        {
            System.Console.WriteLine("Gilded Rose process started");
            var articles = GetAllArticles();
            UpdateArticlesQuality(articles);
        }

        private IEnumerable<Article> GetAllArticles()
        {
            try
            {
                System.Console.WriteLine("Fetching all articles");
                return _articlesRepository.GetAllArticles();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void UpdateArticlesQuality(IEnumerable<Article> articles)
        {
            try
            {
                System.Console.WriteLine("Updating articles quality");
                foreach (Article article in articles)
                {
                    UpdateQuality(article);

                    article.SellIn--;

                    if (article.SellIn < 0)
                    {
                        UpdateQuality(article);
                    }
                    article.Price = Math.Round(article.Quality * 1.9M, 2);
                    System.Console.WriteLine($"Article Information :: {JsonConvert.SerializeObject(article)}");
                }
                System.Console.WriteLine("All articles have been updated");
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void UpdateQuality(Article article)
        {
            try
            {
                if (article.Name != "Aged Brie")
                {
                    if (article.Quality > 0)
                    {
                        article.Quality--;
                    }
                }
                else
                {
                    if (article.Quality < 50)
                    {
                        article.Quality++;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
