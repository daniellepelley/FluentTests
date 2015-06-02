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

        public static void IsEqualTo<T>(this T source, T value, string message)
        {
            AssertionService.AreEqual(source, value, message);
        }

        public static void IsNotEqualTo<T>(this T source, T value)
        {
            AssertionService.AreNotEqual(source, value);
        }

        public static void IsNotEqualTo<T>(this T source, T value, string message)
        {
            AssertionService.AreNotEqual(source, value, message);
        }

        static AssertionExtensions()
        {

        }
    }
}
