using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using BookManager.Repositories.Interfaces;
using BookManager.Repositories;
using BookManager.Models;

namespace BookManager
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<IBookRepository, BookRepository>();
            container.RegisterType<IAuthorRepository, AuthorRepository>();

            return container;
        }
    }
}