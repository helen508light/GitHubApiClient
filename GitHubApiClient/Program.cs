using System;
using GitHubApiHandlerLibrary;

namespace GitHubApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositories = GithubApiHandler.ProcessRepositories().Result;
            if (repositories != null)
            {
                foreach (var repo in repositories)
                {
                    Console.WriteLine("repo name is: {0}", repo.Name);
                    Console.WriteLine("repo description is: {0}", repo.Description ?? "empty");
                    Console.WriteLine("repo url is: {0}", repo.GitHubHomeUrl);
                    Console.WriteLine("repo homepage is: {0}", repo.Homepage);
                    Console.WriteLine("repo watchers count is: {0}", repo.Watchers);
                    Console.WriteLine("repo last push is: {0}", repo.LastPush);
                    Console.WriteLine("----------------------------------------");
                }
                Console.WriteLine("total: {0}", repositories.Count);
                Repository r = GithubApiHandler.GetRepoWithMaxWatchersCount(repositories);
                Console.WriteLine("Repository with max watchers count is: {0}", GithubApiHandler.GetRepoWithMaxWatchersCount(repositories).Name);
                Console.WriteLine("----------------------------------------");
                var linkResult = GithubApiHandler.GetRepositoryByLinqCriteria(repositories);
                Console.WriteLine("Repositories sorted with Linq using criteria \"forksCount > 100 and not private and watchersCount > 100 \"");
                foreach (var lr in linkResult)
                {
                    Console.WriteLine("name: {0}, is private: {1}, watchers count: {2}, forks count: {3}", lr.Name, lr.isPrivate, lr.Watchers, lr.forksCount);
                }
                Console.WriteLine("----------------------------------------");

            }

            var userRepos = GithubApiHandler.GetReposByUserName("octocat").Result;
            if (userRepos != null)
            {
                Console.WriteLine("Repositories of user called OCTOCAT");
                foreach (var ur in userRepos)
                {
                    Console.WriteLine("repo name: {0}", ur.Name);
                }
            }
        }
    }
}
