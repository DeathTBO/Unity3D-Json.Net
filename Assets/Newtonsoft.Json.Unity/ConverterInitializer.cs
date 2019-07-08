using System.Collections.Generic;
using UnityEngine;

namespace Newtonsoft.Json.Unity
{
    public static class ConverterInitializer
    {
        static bool initialized;
        
        //Initialize when the game starts
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            Initialize();
        }
        
        //Called when scripts are recompiled.
        //This is so Json.Net works in Editor Windows
        #if UNITY_EDITOR
        [UnityEditor.Callbacks.DidReloadScripts]
        static void OnScriptsReloaded()
        {
            Initialize();
        }
        #endif
        
        static void Initialize()
        {
            if (initialized)
                return;
            
            //These types have issues with serialization, because normalized/magnitude are properties
            //These properties return a new instance of the class, so during serialization
            //They cause an endless loop
            //These custom converters only save the x/y/z/w values
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter>
                {
                    new JsonVector2Converter(),
                    new JsonVector3Converter(),
                    new JsonVector4Converter(),
                    new JsonQuaternionConverter()
                }
            };

            initialized = true;
        }
    }
}
