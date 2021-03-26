using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under invastigation: {investigatedClass}");

            foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);

            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] allPublicMethoods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            MethodInfo[] allNonPublicMethoods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var publicMethood in allNonPublicMethoods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethood.Name} have to be public!");
            }

            foreach (var nonPublicMethood in allNonPublicMethoods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonPublicMethood.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);

            MethodInfo[] allNonPublicMethoods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var methood in allNonPublicMethoods)
            {
                sb.AppendLine(methood.Name);
            }


            return sb.ToString().TrimEnd();
        }

        public string CollectGetterAndSetter(string investigatedClass)
        {
            Type classType = Type.GetType(investigatedClass);
            MethodInfo[] allMethoods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            foreach (var publicMethood in allMethoods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{publicMethood.Name} will return {publicMethood.ReturnType}");
            }

            foreach (var publicMethood in allMethoods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethood.Name} will set field of {publicMethood.GetParameters().First().ParameterType}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
