using System;
using System.Reflection;

namespace Tienda_Accesorios_Proyecto_SW.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}