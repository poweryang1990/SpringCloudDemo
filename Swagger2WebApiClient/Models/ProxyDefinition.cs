using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swagger2WebApiClient.Models
{
    public class ProxyDefinition
    {
        public ProxyDefinition()
        {
            this.ClassDefinitions = new List<ClassDefinition>();
            this.Operations = new List<Operation>();
        }

        public string Title { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }

        public List<ClassDefinition> ClassDefinitions { get; set; }
        public List<Operation> Operations { get; set; }
    }

    public class ClassDefinition
    {
        public ClassDefinition(string name)
        {
            this.Name = name;
            this.Properties = new List<TypeDefinition>();
        }

        public string Name { get; set; }
        public List<TypeDefinition> Properties { get; set; }
        public string Inherits { get; set; }
    }

    public class EnumDefinition
    {
        public string Name { get; set; }
        public string[] Values { get; set; }
    }
    public class Operation
    {
        public Operation(string returnType, string method, string path, List<Parameter> parameters, string operationId, string description, string proxyName)
        {
            this.Path = path;
            this.Method = method;
            this.Parameters = parameters;
            this.OperationId = operationId;
            this.Description = description;
            this.ReturnType = returnType;
            this.ProxyName = proxyName;
        }

        public string ProxyName { get; set; }
        public string Path { get; set; }
        public string Method { get; set; }
        public List<Parameter> Parameters { get; set; }
        public string OperationId { get; set; }
        public string Description { get; set; }
        public string ReturnType { get; set; }
    }

    public class Parameter
    {
        public TypeDefinition Type { get; set; }
        public ParameterIn ParameterIn { get; set; }
        public bool IsRequired { get; set; }
        public string Description { get; set; }
        public string CollectionFormat { get; set; }

        public Parameter(TypeDefinition type, ParameterIn parameterIn, bool isRequired, string description, string collectionFormat)
        {
            this.Type = type;
            this.ParameterIn = parameterIn;
            this.IsRequired = isRequired;
            this.Description = description;
            this.CollectionFormat = collectionFormat;
        }
    }

    public enum ParameterIn
    {
        Body,
        Path,
        Query,
        FormData
    }

    public class TypeDefinition
    {
        public TypeDefinition(string typeName, string name, string[] enumValues = null, bool isNullableType = false)
        {
            this.TypeName = typeName;
            this.Name = name;
            this.EnumValues = enumValues;
            this.IsNullableType = isNullableType;
        }

        public string Name { get; set; }
        public string TypeName { get; set; }
        public string[] EnumValues { get; set; }
        public bool IsNullableType { get; set; }

        public string GetCleanName()
        {
            return Name.Replace("$", "");
        }
    }


}
