﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ResourceLibrary.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ResourceLibrary.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot; ?&gt;
        ///&lt;xsd:schema xmlns:xsd=&quot;http://www.w3.org/2001/XMLSchema&quot; elementFormDefault=&quot;qualified&quot; xmlns:jaxb=&quot;http://java.sun.com/xml/ns/jaxb&quot; jaxb:version=&quot;2.0&quot;&gt;
        ///  &lt;!--===============================================--&gt;
        ///  &lt;!--Базовый тип для узла без потомков и аттрибутов --&gt;
        ///  &lt;xsd:complexType name=&quot;Пробка&quot;&gt;
        ///        &lt;xsd:sequence  minOccurs=&quot;0&quot;&gt;
        ///        &lt;xsd:element name=&quot;ДырОтБуб&quot;/&gt;
        ///      &lt;/xsd:sequence&gt;
        ///  &lt;/xsd:complexType&gt;  
        ///  &lt;!-- Для создания универсальной схемы  [остаток строки не уместился]&quot;;.
        /// </summary>
        public static string EducationPlanCustomScheme {
            get {
                return ResourceManager.GetString("EducationPlanCustomScheme", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Поиск локализованного ресурса типа System.Byte[].
        /// </summary>
        public static byte[] StudentContract {
            get {
                object obj = ResourceManager.GetObject("StudentContract", resourceCulture);
                return ((byte[])(obj));
            }
        }
    }
}
