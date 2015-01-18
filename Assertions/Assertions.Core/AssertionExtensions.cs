using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Assertions.Core
{
    public static class AssertionExtensions
    {
        //TODO: Change this to private and auto assign it
        public static IAssertionService AssertionService;

        public static void IsEqualTo<T>(this T source, T value)
        {
            AssertionService.AreEqual(source, value);
        }

        static AssertionExtensions()
        {
            //var directoryName = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;

            //var importFile = 
            //    Directory.GetFiles(directoryName)
            //    .FirstOrDefault(x => x.StartsWith("Assertions.Test") && x.EndsWith(".dll"));

            //var type = Assembly.LoadFrom(importFile)
            //    .GetTypes()
            //    .FirstOrDefault(x => x.IsAssignableFrom(typeof (IAssertionService)));

            //assertionService = (IAssertionService)Activator.CreateInstance(type);
        }
    }
}
