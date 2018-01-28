// Copyright (c) Alexandre Mutel. All rights reserved. 
// Copyright (c) Yury Deshin. All rights reserved.
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
            _pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
        }

        [ScriptConstructor(Name = "Без параметров")]
        public static IRuntimeContextInstance Constructor()
        {
            return (IRuntimeContextInstance)new MarkdigMarkdownProcessor();
        }

        [ContextMethod("ПолучитьHtmlИзMarkdown", "GetHtmlFromMarkdown")]
        public string GetHtmlFromMarkdown(string markdown, bool useAdvancedExtensions = false)
        {
            MarkdownPipeline pipeline = null;

            if (useAdvancedExtensions)
                pipeline = _pipeline;

            return Markdown.ToHtml(markdown, pipeline);
        }

        [ContextMethod("ПолучитьСтрокуИзMarkdown", "GetStringFromMarkdown")]
        public string GetStringFromMarkdown(string markdown, bool useAdvancedExtensions = false)
        {
            MarkdownPipeline pipeline = null;

            if (useAdvancedExtensions)
                pipeline = _pipeline;

            return Markdown.ToPlainText(markdown, pipeline);
        }
    }
}
