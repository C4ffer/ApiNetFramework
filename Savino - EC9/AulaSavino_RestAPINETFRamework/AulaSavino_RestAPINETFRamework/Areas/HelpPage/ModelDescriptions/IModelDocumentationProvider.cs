using System;
using System.Reflection;

namespace AulaSavino_RestAPINETFRamework.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}