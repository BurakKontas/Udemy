using System.Reflection;

namespace Udemy.User.Application;

public static class ApplicationAssembly
{
    public static Assembly Assembly => typeof(ApplicationAssembly).Assembly;
}