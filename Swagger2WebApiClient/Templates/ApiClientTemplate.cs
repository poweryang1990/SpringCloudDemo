﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本: 15.0.0.0
//  
//     对此文件的更改可能导致不正确的行为，如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Swagger2WebApiClient.Templates
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Runtime.InteropServices.ComTypes;
    using System.Security;
    using System.Xml.Serialization;
    using Microsoft.CSharp;
    using Swagger2WebApiClient.Infrastructure;
    using Swagger2WebApiClient.Models;
    using Refit;
    using System;
    
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    
    #line 1 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public partial class ApiClientTemplate : ApiClientTemplateBase
    {
#line hidden
        /// <summary>
        /// Create the template output
        /// </summary>
        public virtual string TransformText()
        {
            this.Write("\r\n");
            
            #line 21 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
  
	var swaggerParser=new SwaggerParser(); 

            
            #line default
            #line hidden
            this.Write("using System;\r\nusing System.Collections.Generic;\r\nusing System.Net.Http;\r\nusing S" +
                    "ystem.Threading.Tasks;\r\nusing System.Linq;\r\nusing Newtonsoft.Json;\r\nusing Swagge" +
                    "r2WebApiClient.Infrastructure;\r\nusing Swagger2WebApiClient.Models;\r\nusing ");
            
            #line 32 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Config.Namespace));
            
            #line default
            #line hidden
            this.Write(".Models;\r\nusing ");
            
            #line 33 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Config.Namespace));
            
            #line default
            #line hidden
            this.Write(".Api;\r\nusing Refit;\r\n#region Models\r\nnamespace ");
            
            #line 36 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Config.Namespace));
            
            #line default
            #line hidden
            this.Write(".Models\r\n{\r\n");
            
            #line 38 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"

	var classDefinitions=ProxyDefinition.ClassDefinitions;
	foreach(var classDef in classDefinitions)
	{
		List<EnumDefinition> modelEnums = new List<EnumDefinition>();

            
            #line default
            #line hidden
            this.Write("\t/// <summary>\r\n\t/// \r\n\t/// </summary>\r\n\tpublic class ");
            
            #line 47 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(classDef.Name));
            
            #line default
            #line hidden
            this.Write("  ");
            
            #line 47 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(string.IsNullOrEmpty(classDef.Inherits) ? string.Empty : string.Format(": {0}", classDef.Inherits)));
            
            #line default
            #line hidden
            this.Write("\r\n\t{\r\n\t\t");
            
            #line 49 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 
		foreach(var prop in classDef.Properties) {
		
            
            #line default
            #line hidden
            this.Write("\r\n\t\tpublic ");
            
            #line 53 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prop.TypeName));
            
            #line default
            #line hidden
            this.Write(" ");
            
            #line 53 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(prop.Name));
            
            #line default
            #line hidden
            this.Write(" { get; set; }\r\n\t\t");
            
            #line 54 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 
				if (prop.EnumValues != null)
				{
				    modelEnums.Add(new EnumDefinition()
				    {
				        Name = prop.TypeName,
						Values = prop.EnumValues
				    });
				}
		
            
            #line default
            #line hidden
            this.Write("\t\t");
            
            #line 64 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
}
            
            #line default
            #line hidden
            this.Write("\r\n\t\t");
            
            #line 66 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 foreach(var modelEnum in modelEnums)
		 {
		var csharpCodeProvider = new CSharpCodeProvider();
		
            
            #line default
            #line hidden
            this.Write("\t\tpublic enum ");
            
            #line 70 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(csharpCodeProvider.CreateValidIdentifier(modelEnum.Name)));
            
            #line default
            #line hidden
            this.Write("\r\n\t\t{\r\n\t\t\t");
            
            #line 72 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 foreach(var value in modelEnum.Values.Distinct()){ 
            
            #line default
            #line hidden
            this.Write("\t\t\t");
            
            #line 73 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(swaggerParser.FixTypeName(value)));
            
            #line default
            #line hidden
            this.Write(",\r\n\t\t\t");
            
            #line 74 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\t\t}\r\n\t\t");
            
            #line 76 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 }
            
            #line default
            #line hidden
            this.Write("    }\r\n");
            
            #line 78 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 		
    }

            
            #line default
            #line hidden
            this.Write("\r\n}\r\n\r\n#endregion\r\n\r\n#region ApiClient\r\nnamespace ");
            
            #line 87 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(Config.Namespace));
            
            #line default
            #line hidden
            this.Write(".Api{\r\n\r\n");
            
            #line 89 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
  
	var proxies = ProxyDefinition.Operations.Select(i=>i.ProxyName).Distinct();
	foreach (var proxy in proxies)
	{

            
            #line default
            #line hidden
            this.Write("\t/// <summary>\r\n\t/// Web Api Client For ");
            
            #line 95 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(swaggerParser.FixTypeName(proxy)));
            
            #line default
            #line hidden
            this.Write("\r\n\t/// </summary>\r\n\tpublic interface I");
            
            #line 97 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(swaggerParser.FixTypeName(proxy)));
            
            #line default
            #line hidden
            this.Write("WebApi\r\n\t{\r\n\t");
            
            #line 99 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"

	List<EnumDefinition> proxyParamEnums = new List<EnumDefinition>();
	foreach (var operationDef in ProxyDefinition.Operations.Where(i=>i.ProxyName.Equals(proxy)))
	{ 
		string returnType = string.IsNullOrEmpty(operationDef.ReturnType) ? "Task" : string.Format("Task<{0}>", operationDef.ReturnType);
					var enums = operationDef.Parameters.Where(i => i.Type.EnumValues != null);
				    if (enums != null)
				    {
				        foreach (var enumParam in enums)
				        {
				            enumParam.Type.TypeName = operationDef.OperationId + enumParam.Type.Name;
				            proxyParamEnums.Add(new EnumDefinition()
				            {
								Name = enumParam.Type.TypeName,
								Values = enumParam.Type.EnumValues
				            });
				        }
				    }
		operationDef.Parameters=operationDef.Parameters.OrderByDescending(i=>i.IsRequired).ToList();
		string parameters = string.Join(", ", operationDef.Parameters.Select(
										x => (x.IsRequired == false) ? string.Format("{0}{1} {2} = {3}",swaggerParser.GetParameterType(x), swaggerParser.GetDefaultType(x), x.Type.GetCleanName(), swaggerParser.GetDefaultValue(x)) 
										 :  string.Format("{0}{1} {2}",swaggerParser.GetParameterType(x),swaggerParser.GetDefaultType(x), x.Type.GetCleanName())));
		var methodShow=string.Empty;
		switch (operationDef.Method.ToUpperInvariant())
		{
			case "GET":
				methodShow="Get";
				break;
			case "POST":
				methodShow="Post";
				break;
			case "DELETE":
				methodShow="Delete";
				break;
			case "PUT":
				methodShow="Put";
				break;
			default:
				break;
        }

	
            
            #line default
            #line hidden
            this.Write("\t/// <summary>\r\n    /// ");
            
            #line 142 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operationDef.Description ?? ""));
            
            #line default
            #line hidden
            this.Write("\r\n    /// </summary>\r\n\t");
            
            #line 144 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 foreach (var p in operationDef.Parameters) { 
            
            #line default
            #line hidden
            this.Write("    /// <param name=\"");
            
            #line 145 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Type.GetCleanName()));
            
            #line default
            #line hidden
            this.Write("\">");
            
            #line 145 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(p.Description ?? ""));
            
            #line default
            #line hidden
            this.Write("</param>\r\n\t");
            
            #line 146 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 }
            
            #line default
            #line hidden
            this.Write("    /// <returns></returns>\r\n\t[");
            
            #line 148 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(methodShow));
            
            #line default
            #line hidden
            this.Write("(\"");
            
            #line 148 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operationDef.Path));
            
            #line default
            #line hidden
            this.Write("\")]\r\n\t");
            
            #line 149 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(returnType));
            
            #line default
            #line hidden
            this.Write("  ");
            
            #line 149 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(operationDef.OperationId));
            
            #line default
            #line hidden
            this.Write("Async(");
            
            #line 149 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
            this.Write(this.ToStringHelper.ToStringWithCulture(parameters));
            
            #line default
            #line hidden
            this.Write(");\r\n\r\n\t");
            
            #line 151 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("}\r\n");
            
            #line 153 "E:\MyWorkSpace\SpringCloudDemo\Swagger2WebApiClient\Templates\ApiClientTemplate.tt"
 } 
            
            #line default
            #line hidden
            this.Write("\r\n}\r\n#endregion\r\n\r\n");
            return this.GenerationEnvironment.ToString();
        }
    }
    
    #line default
    #line hidden
    #region Base class
    /// <summary>
    /// Base class for this transformation
    /// </summary>
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.TextTemplating", "15.0.0.0")]
    public class ApiClientTemplateBase
    {
        #region Fields
        private global::System.Text.StringBuilder generationEnvironmentField;
        private global::System.CodeDom.Compiler.CompilerErrorCollection errorsField;
        private global::System.Collections.Generic.List<int> indentLengthsField;
        private string currentIndentField = "";
        private bool endsWithNewline;
        private global::System.Collections.Generic.IDictionary<string, object> sessionField;
        #endregion
        #region Properties
        /// <summary>
        /// The string builder that generation-time code is using to assemble generated output
        /// </summary>
        protected System.Text.StringBuilder GenerationEnvironment
        {
            get
            {
                if ((this.generationEnvironmentField == null))
                {
                    this.generationEnvironmentField = new global::System.Text.StringBuilder();
                }
                return this.generationEnvironmentField;
            }
            set
            {
                this.generationEnvironmentField = value;
            }
        }
        /// <summary>
        /// The error collection for the generation process
        /// </summary>
        public System.CodeDom.Compiler.CompilerErrorCollection Errors
        {
            get
            {
                if ((this.errorsField == null))
                {
                    this.errorsField = new global::System.CodeDom.Compiler.CompilerErrorCollection();
                }
                return this.errorsField;
            }
        }
        /// <summary>
        /// A list of the lengths of each indent that was added with PushIndent
        /// </summary>
        private System.Collections.Generic.List<int> indentLengths
        {
            get
            {
                if ((this.indentLengthsField == null))
                {
                    this.indentLengthsField = new global::System.Collections.Generic.List<int>();
                }
                return this.indentLengthsField;
            }
        }
        /// <summary>
        /// Gets the current indent we use when adding lines to the output
        /// </summary>
        public string CurrentIndent
        {
            get
            {
                return this.currentIndentField;
            }
        }
        /// <summary>
        /// Current transformation session
        /// </summary>
        public virtual global::System.Collections.Generic.IDictionary<string, object> Session
        {
            get
            {
                return this.sessionField;
            }
            set
            {
                this.sessionField = value;
            }
        }
        #endregion
        #region Transform-time helpers
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void Write(string textToAppend)
        {
            if (string.IsNullOrEmpty(textToAppend))
            {
                return;
            }
            // If we're starting off, or if the previous text ended with a newline,
            // we have to append the current indent first.
            if (((this.GenerationEnvironment.Length == 0) 
                        || this.endsWithNewline))
            {
                this.GenerationEnvironment.Append(this.currentIndentField);
                this.endsWithNewline = false;
            }
            // Check if the current text ends with a newline
            if (textToAppend.EndsWith(global::System.Environment.NewLine, global::System.StringComparison.CurrentCulture))
            {
                this.endsWithNewline = true;
            }
            // This is an optimization. If the current indent is "", then we don't have to do any
            // of the more complex stuff further down.
            if ((this.currentIndentField.Length == 0))
            {
                this.GenerationEnvironment.Append(textToAppend);
                return;
            }
            // Everywhere there is a newline in the text, add an indent after it
            textToAppend = textToAppend.Replace(global::System.Environment.NewLine, (global::System.Environment.NewLine + this.currentIndentField));
            // If the text ends with a newline, then we should strip off the indent added at the very end
            // because the appropriate indent will be added when the next time Write() is called
            if (this.endsWithNewline)
            {
                this.GenerationEnvironment.Append(textToAppend, 0, (textToAppend.Length - this.currentIndentField.Length));
            }
            else
            {
                this.GenerationEnvironment.Append(textToAppend);
            }
        }
        /// <summary>
        /// Write text directly into the generated output
        /// </summary>
        public void WriteLine(string textToAppend)
        {
            this.Write(textToAppend);
            this.GenerationEnvironment.AppendLine();
            this.endsWithNewline = true;
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void Write(string format, params object[] args)
        {
            this.Write(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Write formatted text directly into the generated output
        /// </summary>
        public void WriteLine(string format, params object[] args)
        {
            this.WriteLine(string.Format(global::System.Globalization.CultureInfo.CurrentCulture, format, args));
        }
        /// <summary>
        /// Raise an error
        /// </summary>
        public void Error(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Raise a warning
        /// </summary>
        public void Warning(string message)
        {
            System.CodeDom.Compiler.CompilerError error = new global::System.CodeDom.Compiler.CompilerError();
            error.ErrorText = message;
            error.IsWarning = true;
            this.Errors.Add(error);
        }
        /// <summary>
        /// Increase the indent
        /// </summary>
        public void PushIndent(string indent)
        {
            if ((indent == null))
            {
                throw new global::System.ArgumentNullException("indent");
            }
            this.currentIndentField = (this.currentIndentField + indent);
            this.indentLengths.Add(indent.Length);
        }
        /// <summary>
        /// Remove the last indent that was added with PushIndent
        /// </summary>
        public string PopIndent()
        {
            string returnValue = "";
            if ((this.indentLengths.Count > 0))
            {
                int indentLength = this.indentLengths[(this.indentLengths.Count - 1)];
                this.indentLengths.RemoveAt((this.indentLengths.Count - 1));
                if ((indentLength > 0))
                {
                    returnValue = this.currentIndentField.Substring((this.currentIndentField.Length - indentLength));
                    this.currentIndentField = this.currentIndentField.Remove((this.currentIndentField.Length - indentLength));
                }
            }
            return returnValue;
        }
        /// <summary>
        /// Remove any indentation
        /// </summary>
        public void ClearIndent()
        {
            this.indentLengths.Clear();
            this.currentIndentField = "";
        }
        #endregion
        #region ToString Helpers
        /// <summary>
        /// Utility class to produce culture-oriented representation of an object as a string.
        /// </summary>
        public class ToStringInstanceHelper
        {
            private System.IFormatProvider formatProviderField  = global::System.Globalization.CultureInfo.InvariantCulture;
            /// <summary>
            /// Gets or sets format provider to be used by ToStringWithCulture method.
            /// </summary>
            public System.IFormatProvider FormatProvider
            {
                get
                {
                    return this.formatProviderField ;
                }
                set
                {
                    if ((value != null))
                    {
                        this.formatProviderField  = value;
                    }
                }
            }
            /// <summary>
            /// This is called from the compile/run appdomain to convert objects within an expression block to a string
            /// </summary>
            public string ToStringWithCulture(object objectToConvert)
            {
                if ((objectToConvert == null))
                {
                    throw new global::System.ArgumentNullException("objectToConvert");
                }
                System.Type t = objectToConvert.GetType();
                System.Reflection.MethodInfo method = t.GetMethod("ToString", new System.Type[] {
                            typeof(System.IFormatProvider)});
                if ((method == null))
                {
                    return objectToConvert.ToString();
                }
                else
                {
                    return ((string)(method.Invoke(objectToConvert, new object[] {
                                this.formatProviderField })));
                }
            }
        }
        private ToStringInstanceHelper toStringHelperField = new ToStringInstanceHelper();
        /// <summary>
        /// Helper to produce culture-oriented representation of an object as a string
        /// </summary>
        public ToStringInstanceHelper ToStringHelper
        {
            get
            {
                return this.toStringHelperField;
            }
        }
        #endregion
    }
    #endregion
}
