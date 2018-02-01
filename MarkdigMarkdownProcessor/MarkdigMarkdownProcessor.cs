// Copyright (c) Yury Deshin. All rights reserved.
// This file based on Markdig markdown processor library
// Copyright (c) Alexandre Mutel. All rights reserved. 
// This file is licensed under the BSD-Clause 2 license.  
// See the license.txt file in the project root for more information. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.HostedScript.Library;
using Markdig;
using MarkdigMarkdownProcessor;

namespace MarkdigMarkdownProcessor
{
    [ContextClass("MarkdownПроцессорMarkdig", "MarkdigMarkdownProcessor")]
    public class MarkdigMarkdownProcessor : AutoContext<MarkdigMarkdownProcessor>
    {
        private MarkdownPipeline _pipeline;

        public MarkdigMarkdownProcessor()
        {
            _pipeline = new MarkdownPipelineBuilder().Build();
        }

        [ScriptConstructor(Name = "Без параметров")]
        public static IRuntimeContextInstance Constructor()
        {
            return (IRuntimeContextInstance)new MarkdigMarkdownProcessor();
        }

        [ContextMethod("ПолучитьHtmlИзMarkdown", "GetHtmlFromMarkdown")]
        public string GetHtmlFromMarkdown(string markdown)
        {
            return Markdown.ToHtml(markdown, _pipeline);
        }

        /// <summary>
        /// Конфигурирует расширения. Расширения передаются строкой как extension1+extension2+extensionn. atributes должно быть последним т.к. модифицирует другие парсеры
        /// </summary>
        /// <param name="extensions">список расширений в виде строки, разделенной +</param>
        [ContextMethod("СконфигурироватьРасширения", "ConfigureExtensions")]
        public void ConfigureExtensions(string extensions = null)
        {
            _pipeline = new MarkdownPipelineBuilder().Configure(extensions).Build();
        }

        [ContextMethod("ПолучитьСтрокуИзMarkdown", "GetStringFromMarkdown")]
        public string GetStringFromMarkdown(string markdown)
        {
            return Markdown.ToPlainText(markdown, _pipeline);
        }
    }
}
