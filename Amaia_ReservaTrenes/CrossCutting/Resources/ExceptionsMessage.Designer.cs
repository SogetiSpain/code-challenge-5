﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrossCutting.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ExceptionsMessage {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ExceptionsMessage() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("CrossCutting.Resources.ExceptionsMessage", typeof(ExceptionsMessage).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        ///   Looks up a localized string similar to El tren está completo.
        /// </summary>
        public static string CompletedReservationError {
            get {
                return ResourceManager.GetString("CompletedReservationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al conectar con el servidor.
        /// </summary>
        public static string ConnectionError {
            get {
                return ResourceManager.GetString("ConnectionError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al obtener los datos del servidor.
        /// </summary>
        public static string ConnectionGettingDataError {
            get {
                return ResourceManager.GetString("ConnectionGettingDataError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al borrarlas reservas del tren.
        /// </summary>
        public static string DeletingDataError {
            get {
                return ResourceManager.GetString("DeletingDataError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Introduzca un número válido.
        /// </summary>
        public static string InvalidNumberException {
            get {
                return ResourceManager.GetString("InvalidNumberException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El número ser asientos tiene que se mayor que cero.
        /// </summary>
        public static string LessThanZeroException {
            get {
                return ResourceManager.GetString("LessThanZeroException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Letra no reconocida, inténtelo otra vez.
        /// </summary>
        public static string LetterAskException {
            get {
                return ResourceManager.GetString("LetterAskException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El tren no dispone de vagones.
        /// </summary>
        public static string NoCoachError {
            get {
                return ResourceManager.GetString("NoCoachError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to El tren no existe, inténtelo de nuevo.
        /// </summary>
        public static string TrainChoiceError {
            get {
                return ResourceManager.GetString("TrainChoiceError", resourceCulture);
            }
        }
    }
}
