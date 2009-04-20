using System;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Unity;
using Microsoft.Scripting.Hosting;
using Prismudio.Core;

namespace Prismudio.Modules.DynamicLanguageScripting
{
    public class DynamicLanguageModule : IModule
    {
        private readonly IUnityContainer container;
        private bool isInitialized;
        private ScriptRuntimeSetup scriptRuntimeSetup;

        public DynamicLanguageModule(IUnityContainer container)
        {
            this.container = container;
        }

        public ScriptRuntimeSetup ScriptRuntimeSetup
        {
            get
            {
                if (scriptRuntimeSetup == null)
                {
                    scriptRuntimeSetup = ScriptRuntimeSetup.ReadConfiguration();
#if SILVERLIGHT
                    scriptRuntimeSetup.LanguageSetups.Add(new LanguageSetup("IronPython.Runtime.PythonContext, IronPython, Version=2.0.5.0, Culture=neutral, PublicKeyToken=null", "IronPython 2.6 Alpha", "IronPython;Python;py".Split(';'), ".py".Split(';')));
                    scriptRuntimeSetup.LanguageSetups.Add(new LanguageSetup("IronRuby.Runtime.RubyContext, IronRuby, Version=2.0.5.0, Culture=neutral, PublicKeyToken=null", "IronRuby 1.0 Alpha", "IronRuby;Ruby;rb".Split(';'), ".rb".Split(';')));
#endif
                }
                return scriptRuntimeSetup;
            }
            set
            {
                if (isInitialized)
                {
                    throw new InvalidOperationException();
                }
                scriptRuntimeSetup = value;
            }
        }

        public void Initialize()
        {
            CreateScriptRuntime();

            container.RegisterType<ILanguageService, DynamicLanguageService>(new ContainerControlledLifetimeManager());

            isInitialized = true;
        }

        private void CreateScriptRuntime()
        {
            var runtime = new ScriptRuntime(ScriptRuntimeSetup);

            container.RegisterInstance(typeof(ScriptRuntime), runtime);
        }
    }

}